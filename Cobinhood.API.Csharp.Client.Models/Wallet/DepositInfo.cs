using Cobinhood.API.Csharp.Client.Models.General;
using Newtonsoft.Json;

namespace Cobinhood.API.Csharp.Client.Models.Wallet
{
    public class DepositInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public DepositResult Result { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class DepositResult
    {
        [JsonProperty("deposit")]
        public Deposit Deposit { get; set; }
    }
}
