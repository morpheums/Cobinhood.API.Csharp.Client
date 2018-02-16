using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using WebSocketSharp;

namespace Cobinhood.API.Csharp.Client.Domain.Abstract
{
    public abstract class ApiClientAbstract
    {
        /// <summary>
        /// Secret used to authenticate within the API.
        /// </summary>
        public readonly string _apiUrl = "";

        /// <summary>
        /// Key used to authenticate within the API.
        /// </summary>
        public readonly string _apiKey = "";

        /// <summary>
        /// HttpClient to be used to call the API.
        /// </summary>
        public readonly HttpClient _httpClient;

        /// <summary>
        /// URL of the WebSocket Endpoint
        /// </summary>
        public readonly string _webSocketEndpoint = "";

        /// <summary>
        /// Used to store all the opened web sockets.
        /// </summary>
        public List<WebSocket> _openSockets;

        /// <summary>
        /// Delegate for the messages returned by the websockets.
        /// </summary>
        /// <typeparam name="T">Type used to parsed the response message.</typeparam>
        /// <param name="messageData">Websocket response data.</param>
        public delegate void MessageHandler<T>(T messageData);

        /// <summary>
        /// Defines the constructor of the Api Client.
        /// </summary>
        /// <param name="apiUrl">API base url.</param>
        /// <param name="webSocketEndpoint">Websocket url.</param>
        /// <param name="apiKey">Key used to authenticate within the API.</param>
        /// <param name="addDefaultHeaders">Specifies if default headers must be added.</param>
        public ApiClientAbstract(string apiKey, string apiUrl, string webSocketEndpoint, bool addDefaultHeaders = true)
        {
            _apiUrl = apiUrl;
            _apiKey = apiKey;
            _webSocketEndpoint = webSocketEndpoint;
            _openSockets = new List<WebSocket>();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_apiUrl)
            };

            if (addDefaultHeaders)
            {
                ConfigureHttpClient();
            }
        }

        /// <summary>
        /// Configures the HTTPClient.
        /// </summary>
        private void ConfigureHttpClient()
        {
            if (!string.IsNullOrEmpty(_apiKey))
            {
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", _apiKey);
            }

            _httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
