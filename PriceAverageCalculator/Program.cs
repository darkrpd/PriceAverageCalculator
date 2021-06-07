using Actors;
using Actors.Messages;
using Akka.Actor;
using Akka.Configuration;
using Akka.Routing;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PriceAverageCalculator
{
    class Program 
    {
        static void Main(string[] args)
        {
            var config = ConfigurationFactory.ParseString(File.ReadAllText("akka-main-config.hocon"));
            ActorSystem actorSystem = ActorSystem.Create("CurrencyApi", config);

            IActorRef pricesActor = actorSystem.ActorOf(Props.Create<PricesActor>().WithRouter(FromConfig.Instance), "prices");
            IActorRef consoleLogger = actorSystem.ActorOf(Props.Create<ConsoleLoggerActor>(), "logger");

            IActorRef apiActor = actorSystem.ActorOf(Props.Create<ApiActor>(pricesActor), "api");

            Console.WriteLine("Press any key to begin..");
            Console.ReadLine();

            ConsoleLoggerActor.CompletionSource = new TaskCompletionSource<bool>();

            apiActor.Tell(new TriggerRequest(consoleLogger));

            ConsoleLoggerActor.CompletionSource.Task.Wait();

            Console.WriteLine("");
            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();
        }

       
    }
}
