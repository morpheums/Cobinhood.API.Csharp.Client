using Newtonsoft.Json;

namespace Cobinhood.API.Csharp.Client.Models.Trading
{
    public class TradeInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public TradeInfoResult Result { get; set; }
    }
    
    public class TradeInfoResult
    {
        [JsonProperty("trade")]
        public TradeDetail Trade { get; set; }
    }
}
