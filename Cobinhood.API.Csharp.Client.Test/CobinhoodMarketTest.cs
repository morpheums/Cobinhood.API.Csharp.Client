using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Cobinhood.API.Csharp.Client.Test
{
    [TestClass]
    public class CobinhoodMarketTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static ApiClient apiClient = new ApiClient(apiKey);
        private static CobinhoodClient cobinhoodClient = new CobinhoodClient(apiClient);

        [TestMethod]
        public void TestGetAllCurrencies()
        {
            var currencies = cobinhoodClient.GetAllCurrencies().Result;
            Assert.AreEqual(currencies.Success, true);
        }

        [TestMethod]
        public void TestGetAllTradingPairs()
        {
            var trandingPairs = cobinhoodClient.GetAllTradingPairs().Result;
            Assert.AreEqual(trandingPairs.Success, true);
        }

        [TestMethod]
        public void TestGetTradingStatics()
        {
            var tradingStatics = cobinhoodClient.GetTradingStatics().Result;
            Assert.AreEqual(tradingStatics.Success, true);
        }

        [TestMethod]
        public void TestGetOrderBook()
        {
            var orderBook = cobinhoodClient.GetOrderBook("ETH", "BTC").Result;
            Assert.AreEqual(orderBook.Success, true);
        }

        [TestMethod]
        public void TestGetTicker()
        {
            var ticker = cobinhoodClient.GetTicker("ETH", "BTC").Result;
            Assert.AreEqual(ticker.Success, true);
        }

        [TestMethod]
        public void TestGetRecentTrades()
        {
            var recentTrades = cobinhoodClient.GetRecentTrades("ETH", "BTC").Result;
            Assert.AreEqual(recentTrades.Success, true);
        }
    }
}
