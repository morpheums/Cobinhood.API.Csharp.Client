using Newtonsoft.Json;

namespace Cobinhood.API.Csharp.Client.Models.General
{
    public class Error
    {
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
    }
}
