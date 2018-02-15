using Cobinhood.API.Csharp.Client.Models.General;
using Newtonsoft.Json;

namespace Cobinhood.API.Csharp.Client.Models.Market
{

    public class TickerInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public TickerInfoResult Result { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class Ticker
    {
        [JsonProperty("trading_pair_id")]
        public string TradingPairId { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty("24h_high")]
        public string High24h { get; set; }
        [JsonProperty("24h_low")]
        public string Low24h { get; set; }
        [JsonProperty("24h_open")]
        public string Open24h { get; set; }
        [JsonProperty("24h_volume")]
        public string Volume24h { get; set; }
        [JsonProperty("last_trade_price")]
        public string LastTradePrice { get; set; }
        [JsonProperty("highest_bid")]
        public string HighestBid { get; set; }
        [JsonProperty("lowest_ask")]
        public string LowestAsk { get; set; }
    }

    public class TickerInfoResult
    {
        [JsonProperty("ticker")]
        public Ticker Ticker { get; set; }
    }
}
