using Cobinhood.API.Csharp.Client.Models.General;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cobinhood.API.Csharp.Client.Models.Wallet
{
    public class LedgerEntriesInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public LedgerEntryResult Result { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class Ledger
    {
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("trade_id")]
        public string TradeId { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonProperty("balance")]
        public string Balance { get; set; }
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }

    public class LedgerEntryResult
    {
        [JsonProperty("ledger")]
        public IEnumerable<Ledger> Ledger { get; set; }
    }
}
