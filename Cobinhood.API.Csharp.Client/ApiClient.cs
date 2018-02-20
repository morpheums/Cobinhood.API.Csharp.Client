using Cobinhood.API.Csharp.Client.Domain.Abstract;
using Cobinhood.API.Csharp.Client.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Cobinhood.API.Csharp.Client.Utils;
using Cobinhood.API.Csharp.Client.Models.Enums;
using WebSocketSharp;
using System.Collections.Generic;

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

        public void SuscribeToWebSocket<T>(MessageHandler<T> messageDelegate, object data = null)
        {
            var finalEndpoint = _webSocketEndpoint;

            var ws = new WebSocket(finalEndpoint)
            {
                CustomHeaders = new Dictionary<string, string>
                {
                    {"authorization", _apiKey},
                    {"nonce", DateTime.Now.GetUnixTimeStamp()}
                }
            };

            ws.OnMessage += (sender, e) =>
            {
                dynamic eventData = JsonConvert.DeserializeObject<T>(e.Data);
                messageDelegate(eventData);
            };

            ws.OnClose += (sender, e) =>
            {
                _openSockets.Remove(ws);
            };

            ws.OnError += (sender, e) =>
            {
                _openSockets.Remove(ws);
            };

            ws.Connect();

            if (data != null)
            {
                var serializedData = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

                var finalData = serializedData;

                ws.Send(finalData);

            }

            _openSockets.Add(ws);
        }

        public void UnsuscribeFromWebSocket<T>(object data)
        {
            throw new NotImplementedException();
        }
    }
}
