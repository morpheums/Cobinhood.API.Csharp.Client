using Newtonsoft.Json;

namespace Cobinhood.API.Csharp.Client.Models.UserStream
{
    public class UserStreamInfo
    {
        [JsonProperty("listenKey")]
        public string ListenKey { get; set; }
    }
}
