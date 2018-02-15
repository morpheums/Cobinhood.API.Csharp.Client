using Cobinhood.API.Csharp.Client.Models.General;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cobinhood.API.Csharp.Client.Models.Market
{
    public class TradingPairsInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public TradingPairsResult Result { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class TradingPair
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("base_currency_id")]
        public string BaseCurrencyId { get; set; }
        [JsonProperty("quote_currency_id")]
        public string QuoteCurrencyId { get; set; }
        [JsonProperty("base_min_size")]
        public string BaseMinSize { get; set; }
        [JsonProperty("base_max_size")]
        public string BaseMaxSize { get; set; }
        [JsonProperty("quote_increment")]
        public string QuoteIncrement { get; set; }
    }

    public class TradingPairsResult
    {
        [JsonProperty("trading_pairs")]
        public IEnumerable<TradingPair> TradingPairs { get; set; }
    }


}
