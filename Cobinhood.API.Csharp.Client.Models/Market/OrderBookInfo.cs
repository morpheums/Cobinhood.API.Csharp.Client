using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cobinhood.API.Csharp.Client.Models.Market
{
    public class OrderBookInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public OrderBookResult Result { get; set; }
    }

    public class Orderbook
    {
        [JsonProperty("sequence")]
        public int Sequence { get; set; }
        [JsonProperty("bids")]
        public IList<IList<string>> Bids { get; set; }
        [JsonProperty("asks")]
        public IList<IList<string>> Asks { get; set; }
    }

    public class OrderBookResult
    {
        [JsonProperty("orderbook")]
        public Orderbook Orderbook { get; set; }
    }
}
