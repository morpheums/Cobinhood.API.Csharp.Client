using Cobinhood.API.Csharp.Client.Models.Chart;
using Cobinhood.API.Csharp.Client.Models.Enums;
using Cobinhood.API.Csharp.Client.Models.Market;
using Cobinhood.API.Csharp.Client.Models.System;
using Cobinhood.API.Csharp.Client.Models.Trading;
using Cobinhood.API.Csharp.Client.Models.Wallet;
using System;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Domain.Interfaces
{
    public interface ICobinhoodClient
    {
        #region System
        /// <summary>
        /// Get the reference system time as Unix timestamp.
        /// </summary>
        /// <returns></returns>
        Task<SystemTime> GetSystemTime();

        /// <summary>
        /// Get system information.
        /// </summary>
        /// <returns></returns>
        Task<SystemInformation> GetSystemInformation();
        #endregion

        #region Market
        /// <summary>
        /// Returns info for all currencies available for trade.
        /// </summary>
        /// <returns></returns>
        Task<CurrenciesInfo> GetAllCurrencies();

        /// <summary>
        /// Get info for all trading pairs.
        /// </summary>
        /// <returns></returns>
        Task<TradingPairsInfo> GetAllTradingPairs();

        /// <summary>
        /// Get order book for the trading pair containing all asks/bids.
        /// </summary>
        /// <param name="quoteSymbol">Quote symbol to look for.</param>
        /// <param name="baseSymbol">Base symbol to look for.</param>
        /// <returns></returns>
        Task<OrderBookInfo> GetOrderBook(string quoteSymbol, string baseSymbol);

        /// <summary>
        /// Returns ticker for specified trading pair.
        /// </summary>
        /// <param name="quoteSymbol">Quote symbol to look for.</param>
        /// <param name="baseSymbol">Base symbol to look for.</param>
        /// <returns></returns>
        Task<TickerInfo> GetTicker(string quoteSymbol, string baseSymbol);

        /// <summary>
        /// Returns most recent trades for the specified trading pair.
        /// </summary>
        /// <param name="quoteSymbol">Quote symbol to look for.</param>
        /// <param name="baseSymbol">Base symbol to look for.</param>
        /// <returns></returns>
        Task<RecentTradesInfo> GetRecentTrades(string quoteSymbol, string baseSymbol);
        #endregion

        #region Charts
        /// <summary>
        /// Get charting candles.
        /// </summary>
        /// <param name="quoteSymbol">Quote symbol to look for.</param>
        /// <param name="baseSymbol">Base symbol to look for.</param>
        /// <returns></returns>
        Task<CandlesInfo> GetCandles(string quoteSymbol, string baseSymbol, Timeframe timeframe, DateTime? startTime = null, DateTime? endTime = null);
        #endregion

        #region Trading
        /// <summary>
        /// Get information for a single order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<OrderInfo> GetOrder(string orderId);

        /// <summary>
        /// Get all trades originating from the specific order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<OrderTradesInfo> GetOrderTrades(string orderId);

        /// <summary>
        /// List all current orders for user.
        /// </summary>
        /// <param name="quoteSymbol">Quote symbol to look for.</param>
        /// <param name="baseSymbol">Base symbol to look for.</param>
        /// <param name="limit">Limits number of orders per page.</param>
        /// <param name="page">Page number to retrieve.</param>
        /// <returns></returns>
        Task<AllOrdersInfo> GetAllOrders(string quoteSymbol = "", string baseSymbol = "", int? limit = null, int? page = null);

        /// <summary>
        /// Place orders to ask or bid.
        /// </summary>
        /// <param name="quoteSymbol">Quote symbol to look for.</param>
        /// <param name="baseSymbol">Base symbol to look for.</param>
        /// <param name="orderSide">Order side.</param>
        /// <param name="orderType">Order type.</param>
        /// <param name="price">Quote price.</param>
        /// <param name="size">Base amount.</param>
        /// <returns></returns>
        Task<PlacedOrderInfo> PlaceOrder(string quoteSymbol, string baseSymbol, OrderSide orderSide, OrderType orderType, string size, string price = "");

        /// <summary>
        /// Modify a single order.
        /// </summary>
        /// <param name="orderId">Order id.</param>
        /// <param name="price">Quote price.</param>
        /// <param name="size">Base amount.</param>
        /// <returns></returns>
        Task<Result> ModifyOrder(string orderId, string price, string size);

        /// <summary>
        /// Cancel a single order.
        /// </summary>
        /// <param name="orderId">Order id.</param>
        /// <returns></returns>
        Task<Result> CancelOrder(string orderId);

        /// <summary>
        /// Returns order history for the current user.
        /// </summary>
        /// <param name="quoteSymbol">Quote symbol to look for.</param>
        /// <param name="baseSymbol">Base symbol to look for.</param>
        /// <param name="limit">Limits number of orders per page.</param>
        /// <param name="page">Page number to retrieve.</param>
        /// <returns></returns>
        Task<OrderHistoryInfo> GetOrderHistory(string quoteSymbol = "", string baseSymbol = "", int? limit = null, int? page = null);

        /// <summary>
        /// Get trade information. A user only can get their own trade.
        /// </summary>
        /// <param name="tradeId">Trade id.</param>
        /// <returns></returns>
        Task<TradeInfo> GetTrade(string tradeId);

        /// <summary>
        /// Returns trade history for the current user.
        /// </summary>
        /// <param name="quoteSymbol">Quote symbol to look for.</param>
        /// <param name="baseSymbol">Base symbol to look for.</param>
        /// <param name="limit">Limits number of orders per page.</param>
        /// <param name="page">Page number to retrieve.</param>
        /// <returns></returns>
        Task<TradeHistoryInfo> GetTradeHistory(string quoteSymbol, string baseSymbol, int? limit = null, int? page = null);
        #endregion

        #region Wallet
        /// <summary>
        /// Get balances of the current user.
        /// </summary>
        /// <returns></returns>
        Task<WalletBalancesInfo> GetWalletBalances();

        /// <summary>
        /// Get balance history for the current user.
        /// </summary>
        /// <param name="currency">Currency to look for.</param>
        /// <param name="limit">Limits number of orders per page.</param>
        /// <param name="page">Page number to retrieve.</param>
        /// <returns></returns>
        Task<LedgerEntriesInfo> GetLedgerEntries(string currency = "", int? limit = null, int? page = null);

        /// <summary>
        /// Get Wallet Deposit Addresses.
        /// </summary>
        /// <param name="currency">Currency to look for.</param>
        /// <returns></returns>
        Task<DepositAddressesInfo> GetDepositAddresses(string currency = "");

        /// <summary>
        /// Get Wallet Withdrawal Addresses.
        /// </summary>
        /// <param name="currency">Currency to look for.</param>
        /// <returns></returns>
        Task<WithdrawalAddressesInfo> GetWithdrawalAddresses(string currency = "");

        /// <summary>
        /// Get Withdrawal Information.
        /// </summary>
        /// <param name="withdrawalId">Withdrawal id.</param>
        /// <returns></returns>
        Task<WithdrawalInfo> GetWithdrawal(string withdrawalId);

        /// <summary>
        /// Get All Withdrawals.
        /// </summary>
        /// <param name="withdrawalStatus">Status of withdrawal.</param>
        /// <param name="currency">Currency to look for.</param>
        /// <param name="limit">Limits number of orders per page.</param>
        /// <param name="page">Page number to retrieve.</param>
        /// <returns></returns>
        Task<AllWithdrawalInfo> GetAllWithdrawals(string currency = "", WithdrawalStatus withdrawalStatus = WithdrawalStatus.All, int? limit = null, int? page = null);

        /// <summary>
        /// Get Deposit Information.
        /// </summary>
        /// <param name="depositId">Deposit id.</param>
        /// <returns></returns>
        Task<DepositInfo> GetDeposit(string depositId);

        /// <summary>
        /// Get All Deposits.
        /// </summary>
        /// <returns></returns>
        Task<AllDepositsInfo> GetAllDeposits();
        #endregion
    }
}
