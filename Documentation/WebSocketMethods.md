# Websocket Methods
## Order
After receiving the response, you will start receiving any order updates that occurs in your account.
### Example:
 
```c#
    private void OrderMessageHandler(OrderResponse messageData)
    {
        var data = messageData;
    }

    public void TestOrderWebsocket()
    {
        cobinhoodClient.ListenOrderEndpoint(OrderMessageHandler);
    }
```
### Method Signature:

```c#
    public void ListenOrderEndpoint(ApiClientAbstract.MessageHandler<OrderResponse> messageHandler)
```

## Trades
After receiving the response, you will start receiving recent trade, followed by any trade that occurs at COBINHOOD.
### Example:
 
```c#
    private void TradeMessageHandler(TradesResponse messageData)
    {
        var data = messageData;
    }

    public void TestTradesWebsocket()
    {
        cobinhoodClient.ListenTradesEndpoint("ETH", "BTC", TradeMessageHandler);
    }
```
### Method Signature:

```c#
    public void ListenTradesEndpoint(string quoteSymbol, string baseSymbol, ApiClientAbstract.MessageHandler<TradesResponse> messageHandler)
```

## Order book
After receiving the response, you will receive a snapshot of the book, followed by updates upon any changes to the book.
### Example:
 
```c#
    private void OrderBookMessageHandler(OrderBookResponse messageData)
    {
        var data = messageData;
    }

    public void TestOrderBookWebsocket()
    {
        cobinhoodClient.ListenOrderBookEndpoint("ETH", "BTC", OrderBookMessageHandler);
    }
```
### Method Signature:

```c#
    public void ListenOrderBookEndpoint(string quoteSymbol, string baseSymbol, ApiClientAbstract.MessageHandler<OrderBookResponse> messageHandler, string precision = "PRECISION")
```

## Ticker
After receiving the response, you will receive a snapshot of the ticker, followed by updates upon any changes to the tickers.
### Example:
 
```c#
    private void TickerMessageHandler(TickerResponse messageData)
    {
        var data = messageData;
    }

    public void TestTickerWebsocket()
    {
        cobinhoodClient.ListenTickerEndpoint("ETH", "BTC", TickerMessageHandler);
    }
```
### Method Signature:

```c#
    public void ListenTickerEndpoint(string quoteSymbol, string baseSymbol, ApiClientAbstract.MessageHandler<TickerResponse> messageHandler)
```

## Candle
After receiving the response, you will receive a snapshot of the candle data, followed by updates upon any changes to the chart. Updates to the most recent timeframe interval are emitted.
### Example:
 
```c#
    private void CandleMessageHandler(CandleResponse messageData)
    {
        var data = messageData;
    }

    public void TestCandleWebsocket()
    {
        cobinhoodClient.ListenCandleEndpoint("ETH", "BTC", Models.Enums.Timeframe.TIMEFRAME_15_MINUTES, CandleMessageHandler);
    }
```
### Method Signature:

```c#
    public void ListenCandleEndpoint(string quoteSymbol, string baseSymbol, Timeframe timeframe, ApiClientAbstract.MessageHandler<CandleResponse> messageHandler)
```

## Unsubscribe
Send unsubscribe action to unsubscribe channel.
### Example:
 
```c#
    private void UnsubscribeMessageHandler(UnsubscribeResponse messageData) {
        var data = messageData;
    }

    public void Unsubscribe() {
        cobinhoodClient.UnsubscribeFromEndpoint("candle.ETH-BTC.15m", UnsubscribeMessageHandler);
    }
```
### Method Signature:

```c#
    public void UnsubscribeFromEndpoint(string channelId, ApiClientAbstract.MessageHandler<UnsubscribeResponse> messageHandler)
```