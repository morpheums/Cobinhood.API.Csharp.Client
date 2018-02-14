using Newtonsoft.Json;

namespace Cobinhood.API.Csharp.Client.Models.Trading
{
    public class TradeDetail
    {
        [JsonProperty("trading_pair_id")]
        public string TradingPairId { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("maker_side")]
        public string MakerSide { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("size")]
        public string Size { get; set; }
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
