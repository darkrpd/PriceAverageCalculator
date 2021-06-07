using Akka.Actor;

namespace Actors.Messages
{
    public class TriggerRequest
    {
        private readonly IActorRef _client;

        public TriggerRequest(IActorRef client)
        {
            _client = client;
        }

        public IActorRef Client
        {
            get { return _client; }
        }
    }
}