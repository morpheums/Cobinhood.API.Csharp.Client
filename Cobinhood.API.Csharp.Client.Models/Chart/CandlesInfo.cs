using Cobinhood.API.Csharp.Client.Models.General;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cobinhood.API.Csharp.Client.Models.Chart
{
    public class CandlesInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public CandlesResult Result { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class Candle
    {
        [JsonProperty("timeframe")]
        public string Timeframe { get; set; }
        [JsonProperty("trading_pair_id")]
        public string Trading_pair_id { get; set; }
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
        [JsonProperty("open")]
        public string Open { get; set; }
        [JsonProperty("close")]
        public string Close { get; set; }
        [JsonProperty("high")]
        public string High { get; set; }
        [JsonProperty("low")]
        public string Low { get; set; }
        [JsonProperty("volume")]
        public string Volume { get; set; }
    }

    public class CandlesResult
    {
        [JsonProperty("candles")]
        public IEnumerable<Candle> Candles { get; set; }
    }
}
