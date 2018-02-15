using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Cobinhood.API.Csharp.Client.Test
{
    [TestClass]
    public class CobinhoodSystemTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static ApiClient apiClient = new ApiClient(apiKey);
        private static CobinhoodClient cobinhoodClient = new CobinhoodClient(apiClient);

        [TestMethod]
        public void TestGetSystemTime()
        {
            var systemTime = cobinhoodClient.GetSystemTime().Result;
            Assert.AreEqual(systemTime.Success, true);
        }

        [TestMethod]
        public void TestGetSystemInformation()
        {
            var systemInfo = cobinhoodClient.GetSystemInformation().Result;
            Assert.AreEqual(systemInfo.Success, true);
        }
    }
}
