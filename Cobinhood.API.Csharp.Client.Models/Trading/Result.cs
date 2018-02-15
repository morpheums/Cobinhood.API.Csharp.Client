using Cobinhood.API.Csharp.Client.Models.General;
using Newtonsoft.Json;

namespace Cobinhood.API.Csharp.Client.Models.Trading
{
    public class Result
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
    }
}
