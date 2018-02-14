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
    }

    public class Candle
    {
        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }
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
        [JsonProperty("Candles")]
        public IList<Candle> Candles { get; set; }
    }
}
