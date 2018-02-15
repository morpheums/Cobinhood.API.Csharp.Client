using Cobinhood.API.Csharp.Client.Models.General;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cobinhood.API.Csharp.Client.Models.Wallet
{
    public class WithdrawalAddressesInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public WithdrawalAddressResult Result { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class WithdrawalAddress
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
    }

    public class WithdrawalAddressResult
    {
        [JsonProperty("withdrawal_addresses")]
        public IEnumerable<WithdrawalAddress> WithdrawalAddresses { get; set; }
    }
}
