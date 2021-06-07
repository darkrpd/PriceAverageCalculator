using System;
using Akka.Actor;

namespace Actors.Messages
{
    public class StartCalculation
    {
        private readonly IActorRef _client;

        public StartCalculation( IActorRef client)
        {
            _client = client;
        }

        public IActorRef Client
        {
            get { return _client; }
        }
    }
}