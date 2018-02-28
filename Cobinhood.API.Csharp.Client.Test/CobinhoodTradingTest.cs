using Cobinhood.API.Csharp.Client.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Cobinhood.API.Csharp.Client.Test
{
    [TestClass]
    public class CobinhoodTradingTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static ApiClient apiClient = new ApiClient(apiKey);
        private static CobinhoodClient cobinhoodClient = new CobinhoodClient(apiClient);

        [TestMethod]
        public void TestGetOrder()
        {
            var order = cobinhoodClient.GetOrder("6142677c-c211-40e2-bf44-ca96884120eb").Result;
            Assert.AreEqual(order.Success, true);
        }

        [TestMethod]
        public void TestGetOrderTrades()
        {
            var orderTrades = cobinhoodClient.GetOrderTrades("6142677c-c211-40e2-bf44-ca96884120eb").Result;
            Assert.AreEqual(orderTrades.Success, true);
        }

        [TestMethod]
        public void TestGetAllOrders()
        {
            var orders = cobinhoodClient.GetAllOrders().Result;
            Assert.AreEqual(orders.Success, true);
        }

        [TestMethod]
        public void TestMarketBuyOrder()
        {
            var newOrder = cobinhoodClient.PlaceOrder("COB", "ETH", OrderSide.Bid, OrderType.Market, "1000").Result;
            Assert.AreEqual(newOrder.Success, true);
        }

        [TestMethod]
        public void TestMarketSellOrder()
        {
            var newOrder = cobinhoodClient.PlaceOrder("ETH", "BTC", OrderSide.Ask, OrderType.Market, "0.048").Result;
            Assert.AreEqual(newOrder.Success, true);
        }

        [TestMethod]
        public void TestLimitBuyOrder()
        {
            var newOrder = cobinhoodClient.PlaceOrder("COB", "BTC", OrderSide.Bid, OrderType.Limit, "200", "0.000022").Result;
            Assert.AreEqual(newOrder.Success, true);
        }

        [TestMethod]
        public void TestLimitSellOrder()
        {
            var newOrder = cobinhoodClient.PlaceOrder("COB", "BTC", OrderSide.Ask, OrderType.Limit, "200", "0.000030").Result;
            Assert.AreEqual(newOrder.Success, true);
        }

        [TestMethod]
        public void TestModifyOrder()
        {
            var result = cobinhoodClient.ModifyOrder("1d193afc-0c81-4e1e-b338-37be7f2270d6", "0.0000600", "200").Result;
            Assert.AreEqual(result.Success, true);
        }

        [TestMethod]
        public void TestCancelOrder()
        {
            var result = cobinhoodClient.CancelOrder("f29922c5-918d-4bcd-9d0a-5d646078bd27").Result;
            Assert.AreEqual(result.Success, true);
        }

        [TestMethod]
        public void TestGetOrderHistory()
        {
            var orderHistory = cobinhoodClient.GetOrderHistory("ETH", "BTC").Result;
            Assert.AreEqual(orderHistory.Success, true);
        }

        [TestMethod]
        public void TestGetTrade()
        {
            var trade = cobinhoodClient.GetTrade("2051e763-3d16-4aa3-831d-af6a0f92b84a").Result;
            Assert.AreEqual(trade.Success, true);
        }

        [TestMethod]
        public void TestGetTradeHistory()
        {
            var tradeHistory = cobinhoodClient.GetTradeHistory("ETH", "BTC").Result;
            Assert.AreEqual(tradeHistory.Success, true);
        }
    }
}
