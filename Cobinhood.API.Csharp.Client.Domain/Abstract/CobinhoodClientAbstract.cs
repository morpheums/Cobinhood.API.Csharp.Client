using Cobinhood.API.Csharp.Client.Domain.Interfaces;

namespace Cobinhood.API.Csharp.Client.Domain.Abstract
{
    public abstract class CobinhoodClientAbstract
    {
        /// <summary>
        /// Client to be used to call the API.
        /// </summary>
        public readonly IApiClient _apiClient;

        /// <summary>
        /// Defines the constructor of the Cobinhood client.
        /// </summary>
        /// <param name="apiClient">API client to be used for API calls.</param>
        public CobinhoodClientAbstract(IApiClient apiClient) {
            _apiClient = apiClient;
        }
    }
}
