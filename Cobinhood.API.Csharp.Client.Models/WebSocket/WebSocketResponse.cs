using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Models.WebSocket
{
    public class WebSocketResponse
    {
        [JsonProperty("event")]
        public string Event { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
        [JsonProperty("trading_pair_id")]
        public string TradingPairId { get; set; }
        [JsonProperty("timeframe")]
        public string Timeframe { get; set; }
        [JsonProperty("precision")]
        public string Precision { get; set; }
    }

}
