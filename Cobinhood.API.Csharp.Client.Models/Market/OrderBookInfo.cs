using Cobinhood.API.Csharp.Client.Models.General;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cobinhood.API.Csharp.Client.Models.Market
{
    public class OrderBookInfo
    {
        public bool Success { get; set; }
        public OrderBookResult Result { get; set; }
        public Error Error { get; set; }
    }

    public class Orderbook
    {
        public int Sequence { get; set; }
        public List<Offer> Bids { get; set; }
        public List<Offer> Asks { get; set; }
    }

    public class OrderBookResult
    {
        public Orderbook Orderbook { get; set; }
    }

    public class Offer
    {
        public string Price { get; set; }
        public string Count { get; set; }
        public string Size { get; set; }
    }
}
