using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Models.Wallet
{
    public class WalletBalancesInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public WalletBalancesResult Result { get; set; }
    }

    public class Balance
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("total")]
        public string Total { get; set; }
        [JsonProperty("on_order")]
        public string OnOrder { get; set; }
        [JsonProperty("locked")]
        public bool Locked { get; set; }
    }

    public class WalletBalancesResult
    {
        [JsonProperty("balances")]
        public IEnumerable<Balance> Balances { get; set; }
    }
}
