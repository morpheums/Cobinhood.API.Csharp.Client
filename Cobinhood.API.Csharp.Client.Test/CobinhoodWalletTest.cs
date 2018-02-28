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
            var walletBalances = cobinhoodClient.GetWalletBalances().Result;
            Assert.AreEqual(walletBalances.Success, true);
        }

        [TestMethod]
        public void TestGetLedgerEntries()
        {
            var ledgerEntries = cobinhoodClient.GetLedgerEntries("ETH").Result;
            Assert.AreEqual(ledgerEntries.Success, true);
        }

        [TestMethod]
        public void TestGetDepositAddresses()
        {
            var depositAddrresses = cobinhoodClient.GetDepositAddresses().Result;
            Assert.AreEqual(depositAddrresses.Success, true);
        }

        [TestMethod]
        public void TestGetWithdrawalAddresses()
        {
            var withdrawalAddresses = cobinhoodClient.GetWithdrawalAddresses("ETH").Result;
            Assert.AreEqual(withdrawalAddresses.Success, true);
        }

        [TestMethod]
        public void TestGetWithdrawal()
        {
            var withdrawalInfo = cobinhoodClient.GetWithdrawal("62056df2d4cf8fb9b15c7238b89a1438").Result;
            Assert.AreEqual(withdrawalInfo.Success, true);
        }

        [TestMethod]
        public void TestGetAllWithdrawals()
        {
            var withdrawalsInfo = cobinhoodClient.GetAllWithdrawals("ETH").Result;
            Assert.AreEqual(withdrawalsInfo.Success, true);
        }

        [TestMethod]
        public void TestGetDeposit()
        {
            var depositInfo = cobinhoodClient.GetDeposit("00227f3d-02d7-47cb-8cbc-7768ee04815f").Result;
            Assert.AreEqual(depositInfo.Success, true);
        }

        [TestMethod]
        public void TestGetAllDeposits()
        {
            var depositsInfo = cobinhoodClient.GetAllDeposits().Result;
            Assert.AreEqual(depositsInfo.Success, true);
        }
    }
}
