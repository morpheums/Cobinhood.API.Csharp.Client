using System.Collections.Generic;

namespace Cobinhood.API.Csharp.Client.Models.Market
{
    public class OrderBook
    {
        public long LastUpdateId { get; set; }
        public IEnumerable<OrderBookOffer> Bids { get; set; }
        public IEnumerable<OrderBookOffer> Asks { get; set; }
    }
}
