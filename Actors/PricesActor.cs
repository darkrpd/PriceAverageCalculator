using Actors.Messages;
using Akka.Actor;
using Helpers;
using Models;
using System;
using System.Threading;

namespace Actors
{
    public class PricesActor : ReceiveActor
    {
        private readonly ApiHelper _apiHelper;

        public PricesActor()
        {
            _apiHelper = new ApiHelper();

            Receive<PricesRequest>(request =>
            {
                IActorRef actorRef = Sender;
                StartCalculation startCalculation = request.ResponseStartCalculation;

                Thread.Sleep(50);

                Currency prices = _apiHelper.GetPrices();

                actorRef.Tell(new PricesResponse(startCalculation, prices));
            });
        }

    }
}
