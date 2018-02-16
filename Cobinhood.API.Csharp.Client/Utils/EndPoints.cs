namespace Cobinhood.API.Csharp.Client.Utils
{
    /// <summary>
    /// Public class to store all end points.
    /// </summary>
    public static class EndPoints
    {
        #region System Endpoints
        public static readonly string GetSystemTime = "/v1/system/time";
        public static readonly string GetSystemInformation = "/v1/system/info";
        #endregion

        #region Market Endpoints
        public static readonly string GetAllCurrencies = "/v1/market/currencies";
        public static readonly string GetAllTradingPairs = "/v1/market/trading_pairs";
        public static readonly string GetTradingStatistics = "/v1/market/stats";
        public static readonly string GetOrderBook = "/v1/market/orderbooks/<trading_pair_id>";
        public static readonly string GetTicker = "/v1/market/tickers/<trading_pair_id>";
        public static readonly string GetRecentTrades = "/v1/market/trades/<trading_pair_id>";
        #endregion

        #region Chart Endpoints
        public static readonly string GetCandles = "/v1/chart/candles/<trading_pair_id>";
        #endregion

        #region Trading Endpoints
        public static readonly string GetOrder = "/v1/trading/orders/<order_id>";
        public static readonly string GetOrderTrades = "/v1/trading/orders/<order_id>/trades";
        public static readonly string GetAllOrders = "/v1/trading/orders";
        public static readonly string PlaceOrder = "/v1/trading/orders";
        public static readonly string ModifyOrder = "/v1/trading/orders/<order_id>";
        public static readonly string CancelOrder = "/v1/trading/orders/<order_id>";
        public static readonly string GetOrderHistory = "/v1/trading/order_history";
        public static readonly string GetTrade = "/v1/trading/trades/<trade_id>";
        public static readonly string GetTradeHistory = "/v1/trading/trades";
        #endregion

        #region Wallet Endpoints
        public static readonly string GetWalletBalances = "/v1/wallet/balances";
        public static readonly string GetLedgerEntries = "/v1/wallet/ledger";
        public static readonly string GetDepositAddresses = "/v1/wallet/deposit_addresses";
        public static readonly string GetWithdrawalAddresses = "/v1/wallet/withdrawal_addresses";
        public static readonly string GetWithdrawal = "/v1/wallet/withdrawals/<withdrawal_id>";
        public static readonly string GetAllWithdrawals = "/v1/wallet/withdrawals";
        public static readonly string GetDeposit = "/v1/wallet/deposits/<deposit_id>";
        public static readonly string GetAllDeposits = "/v1/wallet/deposits";
        #endregion
    }
}
