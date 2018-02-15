using Cobinhood.API.Csharp.Client.Models.General;
using Newtonsoft.Json;

namespace Cobinhood.API.Csharp.Client.Models.System
{
    public class SystemInformation
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("result")]
        public SystemInformationResult Result { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class Info
    {
        [JsonProperty("phase")]
        public string Phase { get; set; }
        [JsonProperty("revision")]
        public string Revision { get; set; }
    }

    public class SystemInformationResult
    {
        [JsonProperty("info")]
        public Info Info { get; set; }
    }


}
