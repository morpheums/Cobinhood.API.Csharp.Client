using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Models.WebSocket
{
    public class CandleResponse
    {
        public bool Success { get; set; }
        public string ChannelId { get; set; }
        public string Event { get; set; }
        public string Type { get; set; }
        public string TradingPairId { get; set; }
        public string Timeframe { get; set; }

        public List<CandleResponseResult> Snapshot { get; set; }
        public List<CandleResponseResult> Update { get; set; }

        public ErrorResponse Error { get; set; }
    }

    public class CandleResponseResult
    {
        public string Time { get; set; }
        public string Open { get; set; }
        public string Close { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Volume { get; set; }
    }
}
