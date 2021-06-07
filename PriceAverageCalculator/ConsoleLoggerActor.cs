using Actors.Messages;
using Akka.Actor;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceAverageCalculator
{
    public class ConsoleLoggerActor : ReceiveActor
    {
        public static TaskCompletionSource<bool> CompletionSource;

        public ConsoleLoggerActor()
        {
            Receive<CalculationResponse>(response =>
            {
                var prices = JsonConvert.DeserializeObject<Currency>(response.JsonString);

                Console.WriteLine(response.JsonString);

                CompletionSource.SetResult(true);
            });

        }
    }
}
