using Cobinhood.API.Csharp.Client.Models.Market;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Models.WebSocket
{
    public class OrderBookResponse
    {
        public bool Success { get; set; }
        public string ChannelId { get; set; }
        public string Event { get; set; }
        public string Type { get; set; }
        public string TradingPairId { get; set; }
        public string Precision { get; set; }

        public OrderBookResponseResult Snapshot { get; set; }
        public OrderBookResponseResult Update { get; set; }

        public ErrorResponse Error { get; set; }
    }

    public class OrderBookResponseResult
    {
        public List<Offer> Bids { get; set; }
        public List<Offer> Asks { get; set; }
    }
}
