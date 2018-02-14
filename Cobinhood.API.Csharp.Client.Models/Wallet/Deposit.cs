using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Models.Wallet
{
    public class Deposit
    {
        [JsonProperty("deposit_id")]
        public string DepositId { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }
        [JsonProperty("required_confirmations")]
        public int RequiredConfirmations { get; set; }
        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
        [JsonProperty("completed_at")]
        public long CompletedAt { get; set; }
        [JsonProperty("from_address")]
        public string FromAddress { get; set; }
        [JsonProperty("txhash")]
        public string TxHash { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonProperty("fee")]
        public string Fee { get; set; }
    }
}
