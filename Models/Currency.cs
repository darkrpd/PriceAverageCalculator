using Newtonsoft.Json;
using System.Collections.Generic;

namespace Models
{

    public class Meta
    {
        public string symbol { get; set; }
        public string interval { get; set; }
        public string currency { get; set; }
        public string exchange_timezone { get; set; }
        public string exchange { get; set; }
        public string type { get; set; }
        public string currency_base { get; set; }
        public string currency_quote { get; set; }
    }

    public class Value
    {
        public string datetime { get; set; }
        public string open { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public decimal? average { get; set; }
        public string close { get; set; }
        public string volume { get; set; }
    }

    public class AAPL
    {
        public Meta meta { get; set; }
        public List<Value> values { get; set; }
        public string status { get; set; }
    }

    public class MSFT
    {
        public Meta meta { get; set; }
        public List<Value> values { get; set; }
        public string status { get; set; }
    }

    public class EURUSD
    {
        public Meta meta { get; set; }
        public List<Value> values { get; set; }
        public string status { get; set; }
    }

    public class SBUX
    {
        public Meta meta { get; set; }
        public List<Value> values { get; set; }
        public string status { get; set; }
    }

    public class NKE
    {
        public Meta meta { get; set; }
        public List<Value> values { get; set; }
        public string status { get; set; }
    }


    public class Currency
    {
        public AAPL AAPL { get; set; }
        public MSFT MSFT { get; set; }

        [JsonProperty("EUR/USD")]
        public EURUSD EURUSD { get; set; }
        public SBUX SBUX { get; set; }
        public NKE NKE { get; set; }
    }


}
