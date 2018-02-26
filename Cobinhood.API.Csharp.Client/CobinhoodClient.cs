using Cobinhood.API.Csharp.Client.Domain.Abstract;
using Cobinhood.API.Csharp.Client.Domain.Interfaces;
using Cobinhood.API.Csharp.Client.Models.Enums;
using Cobinhood.API.Csharp.Client.Models.Market;
using Cobinhood.API.Csharp.Client.Utils;
using System;
using Cobinhood.API.Csharp.Client.Models.Chart;
using Cobinhood.API.Csharp.Client.Models.System;
using Cobinhood.API.Csharp.Client.Models.Trading;
using Cobinhood.API.Csharp.Client.Models.Wallet;
using System.Threading.Tasks;
using Cobinhood.API.Csharp.Client.Models.WebSocket;
using Cobinhood.API.Csharp.Client.Configuration;
using Newtonsoft.Json.Linq;
using AutoMapper;

namespace Cobinhood.API.Csharp.Client
{
    public class CobinhoodClient : CobinhoodClientAbstract, ICobinhoodClient
    {
        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="apiClient">API client to be used for API calls.</param>
        public CobinhoodClient(IApiClient apiClient) : base(apiClient)
        {
            MappingConfig.Initialize();
        }

        #region System
        /// <see cref="ICobinhoodClient.GetSystemTime"/>
        public async Task<SystemTime> GetSystemTime()
        {
            var result = await _apiClient.CallAsync<SystemTime>(ApiMethod.GET, EndPoints.GetSystemTime);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetSystemInformation"/>
        public async Task<SystemInformation> GetSystemInformation()
        {
            var result = await _apiClient.CallAsync<SystemInformation>(ApiMethod.GET, EndPoints.GetSystemInformation);

            return result;
        }
        #endregion

        #region Market
        /// <see cref="ICobinhoodClient.GetAllCurrencies"/>
        public async Task<CurrenciesInfo> GetAllCurrencies()
        {
            var result = await _apiClient.CallAsync<CurrenciesInfo>(ApiMethod.GET, EndPoints.GetAllCurrencies);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetAllTradingPairs"/>
        public async Task<TradingPairsInfo> GetAllTradingPairs()
        {
            var result = await _apiClient.CallAsync<TradingPairsInfo>(ApiMethod.GET, EndPoints.GetTradingStatistics);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetTradingStatics"/>
        public async Task<TradingStaticsInfo> GetTradingStatics()
        {
            var result = await _apiClient.CallAsync<TradingStaticsInfo>(ApiMethod.GET, EndPoints.GetTradingStatistics);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetOrderBook(string, string)"/>
        public async Task<OrderBookInfo> GetOrderBook(string quoteSymbol, string baseSymbol)
        {
            if (string.IsNullOrWhiteSpace(quoteSymbol))
            {
                throw new ArgumentException("QuoteSymbol cannot be empty. ", "quoteSymbol");
            }
            if (string.IsNullOrWhiteSpace(baseSymbol))
            {
                throw new ArgumentException("BaseSymbol cannot be empty. ", "baseSymbol");
            }

            var tradingPair = (quoteSymbol + "-" + baseSymbol).ToUpper();
            var finalEndpoint = EndPoints.GetOrderBook.Replace("<trading_pair_id>", tradingPair);
            var result = await _apiClient.CallAsync<JToken>(ApiMethod.GET, finalEndpoint);

            return Mapper.Map<OrderBookInfo>(result);
        }

        /// <see cref="ICobinhoodClient.GetTicker(string, string)"/>
        public async Task<TickerInfo> GetTicker(string quoteSymbol, string baseSymbol)
        {
            if (string.IsNullOrWhiteSpace(quoteSymbol))
            {
                throw new ArgumentException("QuoteSymbol cannot be empty. ", "quoteSymbol");
            }
            if (string.IsNullOrWhiteSpace(baseSymbol))
            {
                throw new ArgumentException("BaseSymbol cannot be empty. ", "baseSymbol");
            }

            var tradingPair = (quoteSymbol + "-" + baseSymbol).ToUpper();
            var finalEndpoint = EndPoints.GetTicker.Replace("<trading_pair_id>", tradingPair);
            var result = await _apiClient.CallAsync<TickerInfo>(ApiMethod.GET, finalEndpoint);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetRecentTrades(string, string)"/>
        public async Task<RecentTradesInfo> GetRecentTrades(string quoteSymbol, string baseSymbol)
        {
            if (string.IsNullOrWhiteSpace(quoteSymbol))
            {
                throw new ArgumentException("QuoteSymbol cannot be empty. ", "quoteSymbol");
            }
            if (string.IsNullOrWhiteSpace(baseSymbol))
            {
                throw new ArgumentException("BaseSymbol cannot be empty. ", "baseSymbol");
            }

            var tradingPair = (quoteSymbol + "-" + baseSymbol).ToUpper();
            var finalEndpoint = EndPoints.GetRecentTrades.Replace("<trading_pair_id>", tradingPair);
            var result = await _apiClient.CallAsync<RecentTradesInfo>(ApiMethod.GET, finalEndpoint);

            return result;
        }
        #endregion

        #region Charts
        /// <see cref="ICobinhoodClient.GetCandles(string, string, Timeframe, DateTime?, DateTime?)"/>
        public async Task<CandlesInfo> GetCandles(string quoteSymbol, string baseSymbol, Timeframe timeframe, DateTime? startTime = null, DateTime? endTime = null)
        {
            if (string.IsNullOrWhiteSpace(quoteSymbol))
            {
                throw new ArgumentException("QuoteSymbol cannot be empty. ", "quoteSymbol");
            }
            if (string.IsNullOrWhiteSpace(baseSymbol))
            {
                throw new ArgumentException("BaseSymbol cannot be empty. ", "baseSymbol");
            }

            var parameters = $"timeframe={timeframe.GetDescription()}"
                + (startTime.HasValue ? $"&start_time={startTime.Value.GetUnixTimeStamp()}" : "")
                + (endTime.HasValue ? $"&end_time={endTime.Value.GetUnixTimeStamp()}" : "");

            var tradingPair = (quoteSymbol + "-" + baseSymbol).ToUpper();
            var finalEndpoint = EndPoints.GetCandles.Replace("<trading_pair_id>", tradingPair);
            var result = await _apiClient.CallAsync<CandlesInfo>(ApiMethod.GET, finalEndpoint, parameters);

            return result;
        }
        #endregion

        #region Trading
        /// <see cref="ICobinhoodClient.GetOrder(string)"/>
        public async Task<OrderInfo> GetOrder(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                throw new ArgumentException("OrderId cannot be empty. ", "orderId");
            }

            var finalEndpoint = EndPoints.GetOrder.Replace("<order_id>", orderId);
            var result = await _apiClient.CallAsync<OrderInfo>(ApiMethod.GET, finalEndpoint);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetOrderTrades(string)"/>
        public async Task<OrderTradesInfo> GetOrderTrades(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                throw new ArgumentException("OrderId cannot be empty. ", "orderId");
            }

            var finalEndpoint = EndPoints.GetOrderTrades.Replace("<order_id>", orderId);
            var result = await _apiClient.CallAsync<OrderTradesInfo>(ApiMethod.GET, finalEndpoint);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetAllOrders(string, string, int?, int?)"/>
        public async Task<AllOrdersInfo> GetAllOrders(string quoteSymbol = "", string baseSymbol = "", int? limit = null, int? page = null)
        {
            var tradingPair = (quoteSymbol + "-" + baseSymbol).ToUpper();

            var parameters = (string.IsNullOrWhiteSpace(quoteSymbol) && string.IsNullOrWhiteSpace(quoteSymbol) ? "" : $"trading_pair_id={tradingPair}")
                + (limit.HasValue ? $"&limit={limit.Value}" : "")
                + (page.HasValue ? $"&page={page.Value}" : "");

            var result = await _apiClient.CallAsync<AllOrdersInfo>(ApiMethod.GET, EndPoints.GetAllOrders, parameters);

            return result;
        }

        /// <see cref="ICobinhoodClient.PlaceOrder(string, string, OrderSide, OrderType, string, string)"/>
        public async Task<PlacedOrderInfo> PlaceOrder(string quoteSymbol, string baseSymbol, OrderSide orderSide, OrderType orderType, string size, string price = "")
        {
            if (string.IsNullOrWhiteSpace(quoteSymbol))
            {
                throw new ArgumentException("QuoteSymbol cannot be empty. ", "quoteSymbol");
            }
            if (string.IsNullOrWhiteSpace(baseSymbol))
            {
                throw new ArgumentException("BaseSymbol cannot be empty. ", "baseSymbol");
            }
            if (orderType != OrderType.Market && string.IsNullOrEmpty(price))
            {
                throw new ArgumentException("Price cannot be empty. ", "price");
            }
            if (string.IsNullOrWhiteSpace(size))
            {
                throw new ArgumentException("Size cannot be empty. ", "size");
            }

            var tradingPair = (quoteSymbol + "-" + baseSymbol).ToUpper();
            var newOrder = new NewOrder()
            {
                trading_pair_id = tradingPair,
                side = orderSide.GetDescription(),
                type = orderType.GetDescription(),
                size = size,
                price = price,
            };

            var result = await _apiClient.CallAsync<PlacedOrderInfo>(ApiMethod.POST, EndPoints.PlaceOrder, "", newOrder);

            return result;
        }

        /// <see cref="ICobinhoodClient.ModifyOrder(string, string, string)"/>
        public async Task<Result> ModifyOrder(string orderId, string price, string size)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                throw new ArgumentException("OrderId cannot be empty. ", "orderId");
            }
            if (string.IsNullOrWhiteSpace(price))
            {
                throw new ArgumentException("Price cannot be empty. ", "price");
            }
            if (string.IsNullOrWhiteSpace(size))
            {
                throw new ArgumentException("Size cannot be empty. ", "size");
            }

            var parameters = $"price={price}" + $"&size={size}";
            var finalEndpoint = EndPoints.ModifyOrder.Replace("<order_id>", orderId);

            var result = await _apiClient.CallAsync<Result>(ApiMethod.PUT, finalEndpoint, parameters);

            return result;
        }

        /// <see cref="ICobinhoodClient.CancelOrder(string)"/>
        public async Task<Result> CancelOrder(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                throw new ArgumentException("OrderId cannot be empty. ", "orderId");
            }

            var finalEndpoint = EndPoints.CancelOrder.Replace("<order_id>", orderId);

            var result = await _apiClient.CallAsync<Result>(ApiMethod.DELETE, finalEndpoint);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetOrderHistory(string, string, int?, int?)"/>
        public async Task<OrderHistoryInfo> GetOrderHistory(string quoteSymbol = "", string baseSymbol = "", int? limit = null, int? page = null)
        {
            var tradingPair = (quoteSymbol + "-" + baseSymbol).ToUpper();

            var parameters = (string.IsNullOrWhiteSpace(tradingPair) ? "" : $"trading_pair_id={tradingPair}")
                + (limit.HasValue ? $"&limit={limit.Value}" : "")
                + (page.HasValue ? $"&page={page.Value}" : "");

            var result = await _apiClient.CallAsync<OrderHistoryInfo>(ApiMethod.GET, EndPoints.GetOrderHistory, parameters);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetTrade(string)"/>
        public async Task<TradeInfo> GetTrade(string tradeId)
        {
            if (string.IsNullOrWhiteSpace(tradeId))
            {
                throw new ArgumentException("TradeId cannot be empty. ", "tradeId");
            }

            var finalEndpoint = EndPoints.GetTrade.Replace("<trade_id>", tradeId);

            var result = await _apiClient.CallAsync<TradeInfo>(ApiMethod.GET, finalEndpoint);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetTradeHistory(string, string, int?, int?)"/>
        public async Task<TradeHistoryInfo> GetTradeHistory(string quoteSymbol, string baseSymbol, int? limit = null, int? page = null)
        {
            if (string.IsNullOrWhiteSpace(quoteSymbol))
            {
                throw new ArgumentException("QuoteSymbol cannot be empty. ", "quoteSymbol");
            }
            if (string.IsNullOrWhiteSpace(baseSymbol))
            {
                throw new ArgumentException("BaseSymbol cannot be empty. ", "baseSymbol");
            }

            var tradingPair = (quoteSymbol + "-" + baseSymbol).ToUpper();

            var parameters = $"trading_pair_id={tradingPair}"
                + (limit.HasValue ? $"&limit={limit.Value}" : "")
                + (page.HasValue ? $"&page={page.Value}" : "");

            var result = await _apiClient.CallAsync<TradeHistoryInfo>(ApiMethod.GET, EndPoints.GetTradeHistory, parameters);

            return result;
        }
        #endregion

        #region Wallet
        /// <see cref="ICobinhoodClient.GetWalletBalances"/>
        public async Task<WalletBalancesInfo> GetWalletBalances()
        {
            var result = await _apiClient.CallAsync<WalletBalancesInfo>(ApiMethod.GET, EndPoints.GetWalletBalances);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetLedgerEntries(string, int?, int?)"/>
        public async Task<LedgerEntriesInfo> GetLedgerEntries(string currency = "", int? limit = null, int? page = null)
        {
            var parameters = (string.IsNullOrWhiteSpace(currency) ? "" : $"currency={currency}")
                + (limit.HasValue ? $"&limit={limit.Value}" : "")
                + (page.HasValue ? $"&page={page.Value}" : "");

            var result = await _apiClient.CallAsync<LedgerEntriesInfo>(ApiMethod.GET, EndPoints.GetLedgerEntries, parameters);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetDepositAddresses(string)"/>
        public async Task<DepositAddressesInfo> GetDepositAddresses(string currency = "")
        {
            var parameters = (string.IsNullOrWhiteSpace(currency) ? "" : $"currency={currency}");

            var result = await _apiClient.CallAsync<DepositAddressesInfo>(ApiMethod.GET, EndPoints.GetDepositAddresses, parameters);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetWithdrawalAddresses(string)"/>
        public async Task<WithdrawalAddressesInfo> GetWithdrawalAddresses(string currency = "")
        {
            var parameters = (string.IsNullOrWhiteSpace(currency) ? "" : $"currency={currency}");

            var result = await _apiClient.CallAsync<WithdrawalAddressesInfo>(ApiMethod.GET, EndPoints.GetWithdrawalAddresses, parameters);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetWithdrawal(string)"/>
        public async Task<WithdrawalInfo> GetWithdrawal(string withdrawalId)
        {
            if (string.IsNullOrWhiteSpace(withdrawalId))
            {
                throw new ArgumentException("WithdrawalId cannot be empty. ", "withdrawalId");
            }

            var finalEndpoint = EndPoints.GetWithdrawal.Replace("<withdrawal_id>", withdrawalId);

            var result = await _apiClient.CallAsync<WithdrawalInfo>(ApiMethod.GET, finalEndpoint);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetAllWithdrawals(WithdrawalStatus, string, int?, int?)"/>
        public async Task<AllWithdrawalInfo> GetAllWithdrawals(string currency = "", WithdrawalStatus withdrawalStatus = WithdrawalStatus.All, int? limit = null, int? page = null)
        {
            var parameters = (string.IsNullOrWhiteSpace(currency) ? "" : $"currency={currency}")
                + (withdrawalStatus != WithdrawalStatus.All ? $"&status={withdrawalStatus.GetDescription()}" : "")
              + (limit.HasValue ? $"&limit={limit.Value}" : "")
              + (page.HasValue ? $"&page={page.Value}" : "");

            var result = await _apiClient.CallAsync<AllWithdrawalInfo>(ApiMethod.GET, EndPoints.GetAllWithdrawals, parameters);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetDeposit(string)"/>
        public async Task<DepositInfo> GetDeposit(string depositId)
        {
            if (string.IsNullOrWhiteSpace(depositId))
            {
                throw new ArgumentException("DepositId cannot be empty. ", "depositId");
            }

            var finalEndpoint = EndPoints.GetDeposit.Replace("<deposit_id>", depositId);

            var result = await _apiClient.CallAsync<DepositInfo>(ApiMethod.GET, finalEndpoint);

            return result;
        }

        /// <see cref="ICobinhoodClient.GetAllDeposits"/>
        public async Task<AllDepositsInfo> GetAllDeposits()
        {
            var result = await _apiClient.CallAsync<AllDepositsInfo>(ApiMethod.GET, EndPoints.GetAllDeposits);

            return result;
        }
        #endregion

        #region WebkSockets
        /// <see cref="ICobinhoodClient.ListenOrderEndpoint(ApiClientAbstract.MessageHandler{OrderResponse})"/>
        public void ListenOrderEndpoint(ApiClientAbstract.MessageHandler<OrderResponse> messageHandler)
        {
            var requestData = new WebSocketRequest()
            {
                Action = "subscribe",
                Type = "order"
            };
            _apiClient.SuscribeToWebSocket(messageHandler, requestData);
        }

        /// <see cref="ICobinhoodClient.ListenTradesEndpoint(string, string, ApiClientAbstract.MessageHandler{TradesResponse})"/>
        public void ListenTradesEndpoint(string quoteSymbol, string baseSymbol, ApiClientAbstract.MessageHandler<TradesResponse> messageHandler)
        {
            if (string.IsNullOrWhiteSpace(quoteSymbol))
            {
                throw new ArgumentException("QuoteSymbol cannot be empty. ", "quoteSymbol");
            }
            if (string.IsNullOrWhiteSpace(baseSymbol))
            {
                throw new ArgumentException("BaseSymbol cannot be empty. ", "baseSymbol");
            }

            var tradingPair = (quoteSymbol + "-" + baseSymbol).ToUpper();

            var requestData = new WebSocketRequest()
            {
                Action = "subscribe",
                Type = "trade",
                TradingPairId = tradingPair
            };

            _apiClient.SuscribeToWebSocket(messageHandler, requestData);
        }

        /// <see cref="ICobinhoodClient.ListenOrderBookEndpoint(string, string, ApiClientAbstract.MessageHandler{OrderBookResponse}, string)"/>
        public void ListenOrderBookEndpoint(string quoteSymbol, string baseSymbol, ApiClientAbstract.MessageHandler<OrderBookResponse> messageHandler, string precision = "PRECISION")
        {
            if (string.IsNullOrWhiteSpace(quoteSymbol))
            {
                throw new ArgumentException("QuoteSymbol cannot be empty. ", "quoteSymbol");
            }
            if (string.IsNullOrWhiteSpace(baseSymbol))
            {
                throw new ArgumentException("BaseSymbol cannot be empty. ", "baseSymbol");
            }

            var tradingPair = (quoteSymbol + "-" + baseSymbol).ToUpper();

            var requestData = new WebSocketRequest()
            {
                Action = "subscribe",
                Type = "order-book",
                TradingPairId = tradingPair,
                Precision = precision
            };

            _apiClient.SuscribeToWebSocket(messageHandler, requestData);
        }

        /// <see cref="ICobinhoodClient.ListenTickerEndpoint(string, string, ApiClientAbstract.MessageHandler{TickerResponse})"/>
        public void ListenTickerEndpoint(string quoteSymbol, string baseSymbol, ApiClientAbstract.MessageHandler<TickerResponse> messageHandler)
        {
            if (string.IsNullOrWhiteSpace(quoteSymbol))
            {
                throw new ArgumentException("QuoteSymbol cannot be empty. ", "quoteSymbol");
            }
            if (string.IsNullOrWhiteSpace(baseSymbol))
            {
                throw new ArgumentException("BaseSymbol cannot be empty. ", "baseSymbol");
            }

            var tradingPair = (quoteSymbol + "-" + baseSymbol).ToUpper();

            var requestData = new WebSocketRequest()
            {
                Action = "subscribe",
                Type = "ticker",
                TradingPairId = tradingPair
            };

            _apiClient.SuscribeToWebSocket(messageHandler, requestData);
        }

        /// <see cref="ICobinhoodClient.ListenCandleEndpoint(string, string, Timeframe, ApiClientAbstract.MessageHandler{CandleResponse})"/>
        public void ListenCandleEndpoint(string quoteSymbol, string baseSymbol, Timeframe timeframe, ApiClientAbstract.MessageHandler<CandleResponse> messageHandler)
        {
            if (string.IsNullOrWhiteSpace(quoteSymbol))
            {
                throw new ArgumentException("QuoteSymbol cannot be empty. ", "quoteSymbol");
            }
            if (string.IsNullOrWhiteSpace(baseSymbol))
            {
                throw new ArgumentException("BaseSymbol cannot be empty. ", "baseSymbol");
            }

            var tradingPair = (quoteSymbol + "-" + baseSymbol).ToUpper();

            var requestData = new WebSocketRequest()
            {
                Action = "subscribe",
                Type = "candle",
                TradingPairId = tradingPair,
                Timeframe = timeframe.GetDescription()
            };

            _apiClient.SuscribeToWebSocket(messageHandler, requestData);
        }

        public void UnsubscribeFromEndpoint(WebSocketType webSocketType)
        {
            var requestData = new WebSocketRequest()
            {
                ChannelId = webSocketType.GetDescription()
            };

            _apiClient.UnsuscribeFromWebSocket(requestData);
        }
        #endregion
    }
}
