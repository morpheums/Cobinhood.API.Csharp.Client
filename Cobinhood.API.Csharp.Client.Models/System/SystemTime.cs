using Cobinhood.API.Csharp.Client.Models.General;
using Newtonsoft.Json;

namespace Cobinhood.API.Csharp.Client.Models.System
{
    public class SystemTime
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public SystemTimeResult Result { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class SystemTimeResult
    {
        [JsonProperty("time")]
        public long Time { get; set; }
    }
}
