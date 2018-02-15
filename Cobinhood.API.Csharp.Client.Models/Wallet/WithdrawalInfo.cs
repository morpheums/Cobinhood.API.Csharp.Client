using Cobinhood.API.Csharp.Client.Models.General;
using Newtonsoft.Json;

namespace Cobinhood.API.Csharp.Client.Models.Wallet
{
    public class WithdrawalInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public WithdrawalResult Result { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class WithdrawalResult
    {
        [JsonProperty("withdrawal")]
        public Withdrawal Withdrawal { get; set; }
    }
}
