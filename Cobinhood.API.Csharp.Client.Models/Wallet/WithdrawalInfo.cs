using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Models.Wallet
{
    public class WithdrawalInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public WithdrawalResult Result { get; set; }
    }

    public class WithdrawalResult
    {
        [JsonProperty("withdrawal")]
        public Withdrawal Withdrawal { get; set; }
    }
}
