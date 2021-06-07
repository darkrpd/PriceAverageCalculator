using Models;
using Newtonsoft.Json;
using System;
using System.Net;

namespace Helpers
{
    public  class ApiHelper
    {
        public ApiHelper()
        {
        }

        public  Currency GetPrices()
        {
            var URL = new UriBuilder("https://api.twelvedata.com/time_series?symbol=AAPL,MSFT,EUR/USD,SBUX,NKE&interval=1min&apikey=demo&source=docs");

            var client = new WebClient();
            client.Headers.Add("Accepts", "application/json");

            string json = client.DownloadString(URL.ToString());

            var deserializedProduct = JsonConvert.DeserializeObject<Currency>(json);

            return deserializedProduct;

        }
    }
}
