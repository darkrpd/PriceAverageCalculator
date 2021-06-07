using Actors;
using Akka.Actor;
using Akka.Configuration;
using Akka.Routing;
using System;
using System.IO;

namespace ApiService
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ConfigurationFactory.ParseString(File.ReadAllText("akka-config.hocon"));
            ActorSystem actorSystem = ActorSystem.Create("CurrencyApi", config);

            IActorRef pricesActor = actorSystem.ActorOf(Props.Create<PricesActor>().WithRouter(FromConfig.Instance), "prices");

            IActorRef apiActor = actorSystem.ActorOf(Props.Create<ApiActor>(pricesActor), "api");

            Console.ReadLine();
        }
    }
}
