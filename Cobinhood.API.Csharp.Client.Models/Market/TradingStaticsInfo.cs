using Cobinhood.API.Csharp.Client.Models.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Models.Market
{
    public class TradingStaticsInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public Dictionary<string, TradingStaticDetail> Result { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class TradingStaticsResult
    {
      public IEnumerable<TradingStaticDetail> TradingStaticDetails { get; set; }
    }

    public class TradingStaticDetail
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("last_price")]
        public string LastPrice { get; set; }
        [JsonProperty("lowest_ask")]
        public string LowestAsk { get; set; }
        [JsonProperty("highest_bid")]
        public string HighestBid { get; set; }
        [JsonProperty("base_volume")]
        public string BaseVolume { get; set; }
        [JsonProperty("quote_volume")]
        public string QuoteVolume { get; set; }
        [JsonProperty("is_frozen")]
        public bool IsFrozen { get; set; }
        [JsonProperty("high_24hr")]
        public string High24hr { get; set; }
        [JsonProperty("low_24hr")]
        public string Low24hr { get; set; }
        [JsonProperty("percent_changed_24hr")]
        public string PercentChanged24hr { get; set; }
    }
}
