using Cobinhood.API.Csharp.Client.Models.General;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cobinhood.API.Csharp.Client.Models.Wallet
{
    public class AllDepositsInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public AllDepositsResult Result { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class AllDepositsResult
    {
        [JsonProperty("deposits")]
        public IEnumerable<Deposit> Deposits { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("total_page")]
        public int TotalPage { get; set; }
    }
}
