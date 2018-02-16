using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Models.WebSocket
{
    public class WebSocketRequest
    {
        [JsonProperty("action")]
        [DefaultValue("")]
        public string Action { get; set; }

        [JsonProperty("type")]
        [DefaultValue("")]
        public string Type { get; set; }

        [JsonProperty("trading_pair_id")]
        [DefaultValue("")]
        public string TradingPairId { get; set; }

        [JsonProperty("timeframe")]
        [DefaultValue("")]
        public string Timeframe { get; set; }

        [JsonProperty("channel_id")]
        [DefaultValue("")]
        public string ChannelId { get; set; }

        [JsonProperty("precision")]
        [DefaultValue("")]
        public string Precision { get; set; }
    }
}
