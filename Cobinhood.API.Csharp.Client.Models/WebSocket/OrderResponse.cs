using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Models.WebSocket
{
    public class OrderResponse
    {
        public bool Success { get; set; }
        public string ChannelId { get; set; }
        public string Event { get; set; }
        public string Type { get; set; }

        public OrderResponseResult Snapshot { get; set; }
        public OrderResponseResult Update { get; set; }

        public ErrorResponse Error { get; set; }

        public class OrderResponseResult
        {
            public string OrderId { get; set; }
            public string TradingPairId { get; set; }
            public string Status { get; set; }
            public string Side { get; set; }
            public string Type { get; set; }
            public string Price { get; set; }
            public string Size { get; set; }
            public string FilledSize { get; set; }
            public string Timestamp { get; set; }
        }
    }
}
