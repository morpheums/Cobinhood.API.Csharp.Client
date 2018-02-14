using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cobinhood.API.Csharp.Client.Models.Wallet
{
    public class AllWithdrawalInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public AllWithdrawalResult Result { get; set; }
    }

    public class AllWithdrawalResult
    {
        public IEnumerable<Withdrawal> Withdrawals { get; set; }
    }
}
