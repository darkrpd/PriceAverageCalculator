using Actors.Messages;
using Akka.Actor;
using Akka.Routing;
using Helpers;
using Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Actors
{
    public class CalculationActor : ReceiveActor, IWithUnboundedStash
    {
        private readonly IActorRef _pricesActor;

        private ICancelable _startAttempts;

        public IStash Stash { get; set; }

        private readonly CalculationHelper _calculationHelper;

        public CalculationActor(IActorRef pricesActor)
        {
            _pricesActor = pricesActor;

            _calculationHelper = new CalculationHelper();

            StartCalculationRequest();
        }

        private void StartCalculationRequest()
        {
            Stash?.UnstashAll();

            HandleCheckRecommendationSystemAvailable();

            Receive<StartCalculation>(calculation =>
            {
                Thread.Sleep(50);

                _pricesActor.Tell(new PricesRequest(calculation));
            });

            Receive<PricesResponse>(response =>
            {

                Currency prices = response.Prices;

                var json = JsonConvert.SerializeObject(_calculationHelper.CalculateAveragePrices(prices));

                Thread.Sleep(50);

                IActorRef sender = response.Recommendation.Client;

                sender.Tell(new CalculationResponse(json));
            });
        }


        protected override void PreStart()
        {
            _startAttempts = Context.System.Scheduler.ScheduleTellRepeatedlyCancelable(TimeSpan.Zero, TimeSpan.FromSeconds(5), Self, new CheckIfServicesAvailable(), ActorRefs.NoSender);
       
        }

        protected override void PostStop()
        {
            _startAttempts.Cancel();
        }

        private void HandleCheckRecommendationSystemAvailable()
        {
            ReceiveAsync<CheckIfServicesAvailable>(async attempt =>
            {
                Task<Routees> pricesRoutees = _pricesActor.Ask<Routees>(new GetRoutees());

                Routees[] routeeses = await Task.WhenAll(pricesRoutees);

                bool systemHealty = routeeses.All(routees => routees.Members.Any());

                if (systemHealty)
                {
                    Become(StartCalculationRequest);
                }
                else
                {
                    Become(StopCalculationRequest);
                }
            });
        }

        private void StopCalculationRequest()
        {
            HandleCheckRecommendationSystemAvailable();

            Receive<StartCalculation>(calculation =>
            {
                Stash.Stash();
            });
        }
      
    }
}