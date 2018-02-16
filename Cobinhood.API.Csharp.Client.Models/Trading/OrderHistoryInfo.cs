using Cobinhood.API.Csharp.Client.Models.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Cobinhood.API.Csharp.Client.Models.Trading
{
    public class OrderHistoryInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public OrderHistoryResult Result { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class OrderHistory
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("trading_pair")]
        public string TradingPair { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("side")]
        public string Side { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("size")]
        public string Size { get; set; }
        [JsonProperty("filled")]
        public string Filled { get; set; }
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
        [JsonProperty("eq_price")]
        public string EqPrice { get; set; }
        [JsonProperty("completed_at")]
        public DateTime Completed_at { get; set; }
    }

    public class OrderHistoryResult
    {
        [JsonProperty("orders")]
        public IEnumerable<OrderHistory> OrderHistory { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("total_page")]
        public int TotalPage { get; set; }
    }
}
