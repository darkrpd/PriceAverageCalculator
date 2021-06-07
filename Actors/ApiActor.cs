using Actors.Messages;
using Akka.Actor;
using Akka.Routing;
using System;

namespace Actors
{

    public class ApiActor : ReceiveActor
    {
        public ApiActor(IActorRef pricesActor)
        {
            var calculationActor = Context.ActorOf(Props.Create<CalculationActor>(pricesActor).WithRouter(FromConfig.Instance), "calculation");

            Receive<TriggerRequest>(message =>
            {
                calculationActor.Tell(new StartCalculation(message.Client));
            });

        }
        
    }
   
}
