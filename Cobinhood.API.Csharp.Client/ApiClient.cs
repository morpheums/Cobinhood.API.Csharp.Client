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
        /// <see cref="ApiClientAbstract(string, string, string, string, bool)"/>
        public ApiClient(string apiKey, string apiUrl = @"https://api.cobinhood.com", string webSocketEndpoint = @"wss://feed.cobinhood.com/ws", bool addDefaultHeaders = true) : base(apiKey, apiUrl, webSocketEndpoint, addDefaultHeaders)
        {
        }

        /// <see cref="IApiClient.CallAsync{T}(ApiMethod, string, bool, string)"/>
        public async Task<T> CallAsync<T>(ApiMethod method, string endpoint, string parameters = null, object data = null)
        {
            var finalEndpoint = endpoint + (string.IsNullOrWhiteSpace(parameters) ? "" : $"?{parameters}");

            if (method != ApiMethod.GET)
            {
                _httpClient.DefaultRequestHeaders.Remove("nonce");
                _httpClient.DefaultRequestHeaders.Add("nonce", DateTime.Now.GetUnixTimeStamp());
            }

            var request = new HttpRequestMessage(Utilities.CreateHttpMethod(method.ToString()), finalEndpoint);

            if (data != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(data));
            }

            try
            {
                var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

                // Get the result
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                // Serialize and return result
                return JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
