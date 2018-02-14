using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Models.Wallet
{
    public class DepositAddressesInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public DepositAddressResult Result { get; set; }
    }

    public class DepositAddress
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class DepositAddressResult
    {
        [JsonProperty("deposit_addresses")]
        public IEnumerable<DepositAddress> DepositAddresses { get; set; }
    }
}
