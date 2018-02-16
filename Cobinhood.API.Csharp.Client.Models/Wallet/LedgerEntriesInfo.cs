using Cobinhood.API.Csharp.Client.Models.General;
using Newtonsoft.Json;
using System;
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
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonProperty("balance")]
        public string Balance { get; set; }
        [JsonProperty("trade_id")]
        public string TradeId { get; set; }
        [JsonProperty("deposit_id")]
        public string DepositId { get; set; }
        [JsonProperty("withdrawal_id")]
        public string WithdrawalId { get; set; }
        [JsonProperty("fiat_deposit_id")]
        public string FiatDepositId { get; set; }
        [JsonProperty("fiat_withdrawal_id")]
        public string FiatWithdrawalId { get; set; }
    }

    public class LedgerEntryResult
    {
        [JsonProperty("ledger")]
        public IEnumerable<Ledger> Ledger { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("total_page")]
        public int TotalPage { get; set; }
    }
}
