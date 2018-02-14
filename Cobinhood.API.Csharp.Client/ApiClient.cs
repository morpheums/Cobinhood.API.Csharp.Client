using Cobinhood.API.Csharp.Client.Domain.Abstract;
using Cobinhood.API.Csharp.Client.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Cobinhood.API.Csharp.Client.Utils;
using Cobinhood.API.Csharp.Client.Models.Enums;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Cobinhood.API.Csharp.Client
{
    public class ApiClient : ApiClientAbstract, IApiClient
    {
        /// <see cref="ApiClientAbstract(string, string, string, bool)"/>
        public ApiClient(string apiKey, string apiUrl = @"https://api.cobinhood.com", string webSocketEndpoint = @"wss://feed.cobinhood.com/ws", bool addDefaultHeaders = true) : base(apiKey, apiUrl, webSocketEndpoint, addDefaultHeaders)
        {
        }

        /// <see cref="IApiClient.CallAsync{T}(ApiMethod, string, bool, string)"/>
        public async Task<T> CallAsync<T>(ApiMethod method, string endpoint, string parameters = null)
        {
            var finalEndpoint = endpoint + (string.IsNullOrWhiteSpace(parameters) ? "" : $"?{parameters}");

            _httpClient.DefaultRequestHeaders.Add("nonce", DateTime.Now.GetUnixTimeStamp());

            var request = new HttpRequestMessage(Utilities.CreateHttpMethod(method.ToString()), finalEndpoint);
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                // Api return is OK
                response.EnsureSuccessStatusCode();

                // Get the result
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                // Serialize and return result
                return JsonConvert.DeserializeObject<T>(result);
            }

            // We received an error
            if (response.StatusCode == HttpStatusCode.GatewayTimeout)
            {
                throw new Exception("Api Request Timeout.");
            }

            // Get te error code and message
            var e = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            // Error Values
            var eCode = 0;
            string eMsg = "";
            if (e.IsValidJson())
            {
                try
                {
                    var i = JObject.Parse(e);

                    eCode = i["code"]?.Value<int>() ?? 0;
                    eMsg = i["msg"]?.Value<string>();
                }
                catch { }
            }

            throw new Exception(string.Format("Api Error Code: {0} Message: {1}", eCode, eMsg));
        }
    }
}
