using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
