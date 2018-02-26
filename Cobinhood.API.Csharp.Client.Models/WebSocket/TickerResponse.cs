using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Models.WebSocket
{
    public class TickerResponse
    {
        public string ChannelId { get; set; }
        public TickerResponseResult Snapshot { get; set; }
        public TickerResponseResult Update { get; set; }

        public class TickerResponseResult
        {
            public string LastTradeId { get; set; }
            public string Price { get; set; }
            public string HighestBid { get; set; }
            public string LowestAsk { get; set; }
            public string Volume24H { get; set; }
            public string High24H { get; set; }
            public string Low24H { get; set; }
            public string Open24H { get; set; }
            public string Timestamp { get; set; }
        }
    }
}
