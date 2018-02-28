# Trading Methods
## Get Order
Get information for a single order.
### Example:
 
```c#
    var order = cobinhoodClient.GetOrder("6142677c-c211-40e2-bf44-ca96884120eb").Result;
```
### Method Signature:

```c#
    public async Task<OrderInfo> GetOrder(string orderId)
```

## Get Trades of An Order
Get all trades originating from the specific order.
### Example:
 
```c#
    var orderTrades = cobinhoodClient.GetOrderTrades("6142677c-c211-40e2-bf44-ca96884120eb").Result;
```
### Method Signature:

```c#
    public async Task<OrderTradesInfo> GetOrderTrades(string orderId)
```

## Get All Orders
List all current orders for user.
### Example:
 
```c#
    var orders = cobinhoodClient.GetAllOrders().Result;
```
### Method Signature:

```c#
    public async Task<AllOrdersInfo> GetAllOrders(string quoteSymbol = "", string baseSymbol = "", int? limit = null, int? page = null)
```

## Place Order
Place orders to ask or bid.
### Example:
 
Post new order (LIMIT)
```c#
    var buyOrder = cobinhoodClient.PlaceOrder("COB", "BTC", OrderSide.Bid, OrderType.Limit, "200", "0.000022").Result;
    var sellOrder = cobinhoodClient.PlaceOrder("COB", "BTC", OrderSide.Ask, OrderType.Limit, "200", "0.000030").Result;
```
Post new order (MARKET)
```c#
    var buyOrder = cobinhoodClient.PlaceOrder("COB", "ETH", OrderSide.Bid, OrderType.Market, "1000").Result;
    var sellOrder = cobinhoodClient.PlaceOrder("ETH", "BTC", OrderSide.Ask, OrderType.Market, "0.048").Result;
```
### Method Signature:

```c#
    public async Task<PlacedOrderInfo> PlaceOrder(string quoteSymbol, string baseSymbol, OrderSide orderSide, OrderType orderType, string size, string price = "")
```

## Modify Order
Modify a single order.
### Example:
 
```c#
    var result = cobinhoodClient.ModifyOrder("1d193afc-0c81-4e1e-b338-37be7f2270d6", "0.0000600", "200").Result;
```
### Method Signature:

```c#
    public async Task<Result> ModifyOrder(string orderId, string price, string size)
```

## Cancel Order
Cancel a single order.
### Example:
 
```c#
    var result = cobinhoodClient.CancelOrder("f29922c5-918d-4bcd-9d0a-5d646078bd27").Result;
```
### Method Signature:

```c#
    public async Task<Result> CancelOrder(string orderId)
```

## Get Order History
Returns order history for the current user.
### Example:
 
```c#
    var orderHistory = cobinhoodClient.GetOrderHistory("ETH", "BTC").Result;
```
### Method Signature:

```c#
    public async Task<OrderHistoryInfo> GetOrderHistory(string quoteSymbol = "", string baseSymbol = "", int? limit = null, int? page = null)
```

## Get Trade
Get trade information. A user only can get their own trade.
### Example:
 
```c#
    var trade = cobinhoodClient.GetTrade("2051e763-3d16-4aa3-831d-af6a0f92b84a").Result;
```
### Method Signature:

```c#
    public async Task<TradeInfo> GetTrade(string tradeId)
```

## Get Trade History
Returns trade history for the current user.
### Example:
 
```c#
    var tradeHistory = cobinhoodClient.GetTradeHistory("ETH", "BTC").Result;
```
### Method Signature:

```c#
    public async Task<TradeHistoryInfo> GetTradeHistory(string quoteSymbol, string baseSymbol, int? limit = null, int? page = null)
```