using Models;

namespace Actors.Messages
{
    public class PricesResponse
    {
        private readonly StartCalculation _startRecommendation;
        private readonly Currency _prices;

        public PricesResponse(StartCalculation startRecommendation, Currency prices)
        {
            _startRecommendation = startRecommendation;
            _prices = prices;
        }

        public StartCalculation Recommendation
        {
            get { return _startRecommendation; }
        }

        public Currency Prices
        {
            get { return  _prices; }
        }
    }
}