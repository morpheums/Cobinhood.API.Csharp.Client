using Cobinhood.API.Csharp.Client.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Cobinhood.API.Csharp.Client.Test
{
    [TestClass]
    public class CobinhoodChartTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static ApiClient apiClient = new ApiClient(apiKey);
        private static CobinhoodClient cobinhoodClient = new CobinhoodClient(apiClient);

        [TestMethod]
        public void TestGetCandles()
        {
            var candles = cobinhoodClient.GetCandles("ETH","BTC", Timeframe.TIMEFRAME_15_MINUTES).Result;
            Assert.AreEqual(candles.Success, true);
        }
    }
}
