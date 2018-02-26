using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Models.WebSocket
{
    public class TradesResponse
    {
        public string ChannelId { get; set; }
        public List<TradesResponseResult> Snapshot { get; set; }
        public List<TradesResponseResult> Update { get; set; }

        public class TradesResponseResult
        {
            public string TradeId { get; set; }
            public string Timestamp { get; set; }
            public string Price { get; set; }
            public string Size { get; set; }
            public string MakerSide { get; set; }
        }
    }
}
