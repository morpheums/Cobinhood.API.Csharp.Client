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
using AutoMapper;
using Newtonsoft.Json.Linq;
using System.Linq;
using Cobinhood.API.Csharp.Client.Configuration;

namespace Cobinhood.API.Csharp.Client
{
    public class ApiClient : ApiClientAbstract, IApiClient
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <see cref="ApiClientAbstract(string, string, string, string, bool)"/>
        public ApiClient(string apiKey, string apiUrl = @"https://api.cobinhood.com", string webSocketEndpoint = @"wss://feed.cobinhood.com/ws", bool addDefaultHeaders = true) : base(apiKey, apiUrl, webSocketEndpoint, addDefaultHeaders)
        {
            NlogConfig.Configure();
        }

        /// <see cref="IApiClient.CallAsync{T}(ApiMethod, string, bool, string)"/>
        public async Task<T> CallAsync<T>(ApiMethod method, string endpoint, string parameters = null, object data = null)
        {
            try
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


                var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

                // Get the result
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                // Serialize and return result
                return JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error has occurred!");
                throw ex;
            }
        }

        public void SuscribeToWebSocket<T>(MessageHandler<T> messageDelegate, object data = null)
        {
            try
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
                    var responseData = JsonConvert.DeserializeObject<JToken>(e.Data);
                    var eventData = Mapper.Map<T>(responseData);
                    messageDelegate(eventData);
                };

                ws.OnClose += (sender, e) =>
                {
                    _openSockets.Remove(ws);
                };

                ws.OnError += (sender, e) =>
                {
                    _openSockets.Remove(ws);
                    logger.Error(e.Exception, "An error has occurred!");
                    throw e.Exception;
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
            catch (Exception ex)
            {
                logger.Error(ex, "An error has occurred!");
                throw ex;
            }
        }
    }
}
