using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Models.Wallet
{
    public class AllDepositsInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public AllDepositsResult Result { get; set; }
    }

    public class AllDepositsResult
    {
        [JsonProperty("deposits")]
        public Deposit Deposits { get; set; }
    }
}
