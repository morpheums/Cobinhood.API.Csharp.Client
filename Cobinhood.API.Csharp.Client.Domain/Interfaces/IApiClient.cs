using Cobinhood.API.Csharp.Client.Models.Enums;
using Cobinhood.API.Csharp.Client.Models.WebSocket;
using System.Threading.Tasks;
using static Cobinhood.API.Csharp.Client.Domain.Abstract.ApiClientAbstract;

namespace Cobinhood.API.Csharp.Client.Domain.Interfaces
{
    public interface IApiClient
    {
        /// <summary>
        /// Calls API Methods.
        /// </summary>
        /// <typeparam name="T">Type to which the response content will be converted.</typeparam>
        /// <param name="method">HTTPMethod (POST-GET-PUT-DELETE)</param>
        /// <param name="endpoint">Url endpoing.</param>
        /// <param name="isSigned">Specifies if the request needs a signature.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns></returns>
        Task<T> CallAsync<T>(ApiMethod method, string endpoint, bool isSigned = false, string parameters = null);
    }
}