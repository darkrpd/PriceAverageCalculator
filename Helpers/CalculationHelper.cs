using Models;

namespace Helpers
{
    public class CalculationHelper
    {
        public CalculationHelper()
        {
        }

        public  Currency CalculateAveragePrices(Currency currency)
        {

            CalculateAAPL(currency.AAPL);
            CalculateEURUSD(currency.EURUSD);
            CalculateMSFT(currency.MSFT);
            CalculateNKE(currency.NKE);
            CalculateSBUX(currency.SBUX);

            return currency;

        }
         

        private  void CalculateAAPL(AAPL aAPL)
        {
            foreach (var value in aAPL.values)
            {
                value.average = (decimal.Parse(value.high) + decimal.Parse(value.low)) / 2;
            }
        }

        private  void CalculateEURUSD(EURUSD eURUSD)
        {
            foreach (var value in eURUSD.values)
            {
                value.average = (decimal.Parse(value.high) + decimal.Parse(value.low)) / 2;
            }
        }

        private  void CalculateMSFT(MSFT mSFT)
        {
            foreach (var value in mSFT.values)
            {
                value.average = (decimal.Parse(value.high) + decimal.Parse(value.low)) / 2;
            }
        }

        private  void CalculateNKE(NKE nKE)
        {
            foreach (var value in nKE.values)
            {
                value.average = (decimal.Parse(value.high) + decimal.Parse(value.low)) / 2;
            }
        }

        private  void CalculateSBUX(SBUX sBUX)
        {
            foreach (var value in sBUX.values)
            {
                value.average = (decimal.Parse(value.high) + decimal.Parse(value.low)) / 2;
            }
        }
    }
}