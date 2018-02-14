using Newtonsoft.Json;

namespace Cobinhood.API.Csharp.Client.Models.System
{
    public class SystemTime
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public SystemTimeResult Result { get; set; }
    }

    public class SystemTimeResult
    {
        [JsonProperty("time")]
        public long Time { get; set; }
    }
}
