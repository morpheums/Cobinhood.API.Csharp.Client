using Newtonsoft.Json;

namespace Cobinhood.API.Csharp.Client.Models.Market
{
    public class SymbolPrice
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
