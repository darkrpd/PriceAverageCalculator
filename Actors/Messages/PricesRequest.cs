namespace Actors.Messages
{
    public class PricesRequest
    {
        private readonly StartCalculation _responseStartCalculation;

        public PricesRequest(StartCalculation responseStartCalculation)
        {
            _responseStartCalculation = responseStartCalculation;
        }

        public StartCalculation ResponseStartCalculation
        {
            get { return _responseStartCalculation; }
        }

    }
}