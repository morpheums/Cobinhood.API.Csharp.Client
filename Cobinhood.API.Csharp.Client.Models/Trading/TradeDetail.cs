using Newtonsoft.Json;

namespace Cobinhood.API.Csharp.Client.Models.Trading
{
    public class TradeDetail
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("maker_side")]
        public string MakerSide { get; set; }
        [JsonProperty("ask_order_id")]
        public string AskOrderId { get; set; }
        [JsonProperty("bid_order_id")]
        public string BidOrderId { get; set; }
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("size")]
        public string Size { get; set; }
    }
}
