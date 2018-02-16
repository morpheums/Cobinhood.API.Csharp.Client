using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Test
{
    [TestClass]
    public class CobinhoodWebsocketTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static ApiClient apiClient = new ApiClient(apiKey);
        private static CobinhoodClient cobinhoodClient = new CobinhoodClient(apiClient);

        private void OrderMessageHandler(dynamic messageData)
        {
            var data = messageData;
        }

        [TestMethod]
        public void TestKlineEndpoint()
        {
            cobinhoodClient.ListenOrderEndpoint(OrderMessageHandler);
            Thread.Sleep(50000);
        }
    }
}
