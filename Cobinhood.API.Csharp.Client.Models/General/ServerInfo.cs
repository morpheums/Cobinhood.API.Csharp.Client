using Newtonsoft.Json;

namespace Cobinhood.API.Csharp.Client.Models.General
{
    public class ServerInfo
    {
        [JsonProperty("serverTIme")]
        public long ServerTime { get; set; }
    }
}
