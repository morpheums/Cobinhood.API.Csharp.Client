using Cobinhood.API.Csharp.Client.Models.General;
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
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class AllWithdrawalResult
    {
        [JsonProperty("withdrawals")]
        public IEnumerable<Withdrawal> Withdrawals { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("total_page")]
        public int TotalPage { get; set; }
    }
}
