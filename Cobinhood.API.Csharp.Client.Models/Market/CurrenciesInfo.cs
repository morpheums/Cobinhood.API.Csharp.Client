using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cobinhood.API.Csharp.Client.Models.Market
{
    public class CurrenciesInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("result")]
        public CurrenciesResult Result { get; set; }
    }

    public class Currency
    {
        [JsonProperty("currency")]
        public string Ticker { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("min_unit")]
        public string MinUnit { get; set; }
        [JsonProperty("deposit_fee")]
        public string DepositFee { get; set; }
        [JsonProperty("withdrawal_fee")]
        public string WithdrawalFee { get; set; }
    }

    public class CurrenciesResult
    {
        [JsonProperty("currencies")]
        public IEnumerable<Currency> Currencies { get; set; }
    }
}
