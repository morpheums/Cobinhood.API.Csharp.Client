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
        public string ChannelId { get; set; }
        public OrderBookResponseResult Snapshot { get; set; }
        public OrderBookResponseResult Update { get; set; }
    }

    public class OrderBookResponseResult
    {
        public List<Offer> Bids { get; set; }
        public List<Offer> Asks { get; set; }
    }
}
