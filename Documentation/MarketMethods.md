# Market Methods
## Get All Currencies
Returns info for all currencies available for trade.
### Example:
 
```c#
     var currencies = cobinhoodClient.GetAllCurrencies().Result;
```
### Method Signature:

```c#
    public async Task<CurrenciesInfo> GetAllCurrencies()
```

## Get All Trading Pairs
Get info for all trading pairs.
### Example:
 
```c#
    var trandingPairs = cobinhoodClient.GetAllTradingPairs().Result;
```
### Method Signature:

```c#
    public async Task<TradingPairsInfo> GetAllTradingPairs()
```

## Get Order Book
Get order book for the trading pair containing all asks/bids.
### Example:
 
```c#
    var orderBook = cobinhoodClient.GetOrderBook("ETH", "BTC").Result;
```
### Method Signature:

```c#
    public async Task<OrderBookInfo> GetOrderBook(string quoteSymbol, string baseSymbol)
```

## Get Trading Statistics
Gets Trading Statistics.
### Example:
 
```c#
    var tradingStatics = cobinhoodClient.GetTradingStatics().Result;
```
### Method Signature:

```c#
    public async Task<TradingStaticsInfo> GetTradingStatics()
```

## Get Ticker
Returns ticker for specified trading pair.
### Example:
 
```c#
    var ticker = cobinhoodClient.GetTicker("ETH", "BTC").Result;
```
### Method Signature:

```c#
    public async Task<TickerInfo> GetTicker(string quoteSymbol, string baseSymbol)
```

## Get Recent Trades
Returns most recent trades for the specified trading pair.
### Example:
 
```c#
    var recentTrades = cobinhoodClient.GetRecentTrades("ETH", "BTC").Result;
```
### Method Signature:

```c#
    public async Task<RecentTradesInfo> GetRecentTrades(string quoteSymbol, string baseSymbol)
```