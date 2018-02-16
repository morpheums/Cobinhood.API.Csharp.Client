using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Cobinhood.API.Csharp.Client.Test
{
    [TestClass]
    public class CobinhoodWalletTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static ApiClient apiClient = new ApiClient(apiKey);
        private static CobinhoodClient cobinhoodClient = new CobinhoodClient(apiClient);

        [TestMethod]
        public void TestGetWalletBalances()
        {
            var result = cobinhoodClient.GetWalletBalances().Result;
            Assert.AreEqual(result.Success, true);
        }

        [TestMethod]
        public void TestGetLedgerEntries()
        {
            var result = cobinhoodClient.GetLedgerEntries("ETH").Result;
            Assert.AreEqual(result.Success, true);
        }

        [TestMethod]
        public void TestGetDepositAddresses()
        {
            var result = cobinhoodClient.GetDepositAddresses().Result;
            Assert.AreEqual(result.Success, true);
        }

        [TestMethod]
        public void TestGetWithdrawalAddresses()
        {
            var result = cobinhoodClient.GetWithdrawalAddresses("ETH").Result;
            Assert.AreEqual(result.Success, true);
        }

        [TestMethod]
        public void TestGetWithdrawal()
        {
            var result = cobinhoodClient.GetWithdrawal("62056df2d4cf8fb9b15c7238b89a1438").Result;
            Assert.AreEqual(result.Success, true);
        }

        [TestMethod]
        public void TestGetAllWithdrawals()
        {
            var result = cobinhoodClient.GetAllWithdrawals("ETH").Result;
            Assert.AreEqual(result.Success, true);
        }

        [TestMethod]
        public void TestGetDeposit()
        {
            var result = cobinhoodClient.GetDeposit("00227f3d-02d7-47cb-8cbc-7768ee04815f").Result;
            Assert.AreEqual(result.Success, true);
        }

        [TestMethod]
        public void TestGetAllDeposits()
        {
            var result = cobinhoodClient.GetAllDeposits().Result;
            Assert.AreEqual(result.Success, true);
        }
    }
}
