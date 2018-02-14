using Newtonsoft.Json;

namespace Cobinhood.API.Csharp.Client.Models.Trading
{
    public class OrderInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public OrderInfoResult Result { get; set; }
    }

    public class Order
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("trading_pair")]
        public string TradingPair { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("side")]
        public string Side { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("size")]
        public string Size { get; set; }
        [JsonProperty("filled")]
        public string Filled { get; set; }
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }

    public class OrderInfoResult
    {
        [JsonProperty("order")]
        public Order Order { get; set; }
    }
}
