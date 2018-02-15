using Cobinhood.API.Csharp.Client.Models.General;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cobinhood.API.Csharp.Client.Models.Market
{
    public class RecentTradesInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public RecentTradesResult Result { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class Trade
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("size")]
        public string Size { get; set; }
        [JsonProperty("maker_side")]
        public string MakerSide { get; set; }
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }

    public class RecentTradesResult
    {
        [JsonProperty("trades")]
        public IList<Trade> Trades { get; set; }
    }



}
