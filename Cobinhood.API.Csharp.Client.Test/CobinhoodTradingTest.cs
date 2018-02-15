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
            var order = cobinhoodClient.GetOrder("37f550a202aa6a3fe120f420637c894c").Result;
            Assert.AreEqual(order.Success, true);
        }

        [TestMethod]
        public void TestGetOrderTrades()
        {
            var orderTrades = cobinhoodClient.GetOrderTrades("37f550a202aa6a3fe120f420637c894c").Result;
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
            var newOrder = cobinhoodClient.PlaceOrder("COB", "ETH", OrderSide.Bid, OrderType.Market, "10").Result;
            Assert.AreEqual(newOrder.Success, true);
        }

        [TestMethod]
        public void TestMarketSellOrder()
        {
            var newOrder = cobinhoodClient.PlaceOrder("COB", "ETH", OrderSide.Ask, OrderType.Market, "10").Result;
            Assert.AreEqual(newOrder.Success, true);
        }

        [TestMethod]
        public void TestLimitBuyOrder()
        {
            var newOrder = cobinhoodClient.PlaceOrder("COB", "ETH", OrderSide.Bid, OrderType.Limit, "10", "0.00017").Result;
            Assert.AreEqual(newOrder.Success, true);
        }

        [TestMethod]
        public void TestLimitSellOrder()
        {
            var newOrder = cobinhoodClient.PlaceOrder("COB", "ETH", OrderSide.Ask, OrderType.Limit, "10", "0.0025").Result;
            Assert.AreEqual(newOrder.Success, true);
        }

        [TestMethod]
        public void TestModifyOrder()
        {
            var result = cobinhoodClient.ModifyOrder("37f550a202aa6a3fe120f420637c894c", "0.0001817", "10").Result;
            Assert.AreEqual(result.Success, true);
        }

        [TestMethod]
        public void TestCancelOrder()
        {
            var result = cobinhoodClient.CancelOrder("37f550a202aa6a3fe120f420637c894c").Result;
            Assert.AreEqual(result.Success, true);
        }

        [TestMethod]
        public void TestGetOrderHistory()
        {
            var result = cobinhoodClient.GetOrderHistory("COB", "ETH").Result;
            Assert.AreEqual(result.Success, true);
        }

        [TestMethod]
        public void TestGetTrade()
        {
            var trade = cobinhoodClient.GetTrade("09619448-e48a-3bd7-3d49-3a4194f9020b").Result;
            Assert.AreEqual(trade.Success, true);
        }

        [TestMethod]
        public void TestGetTradeHistory()
        {
            var result = cobinhoodClient.GetTradeHistory("COB", "ETH").Result;
            Assert.AreEqual(result.Success, true);
        }
    }
}
