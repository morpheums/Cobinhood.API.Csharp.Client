# Chart Methods
## Get Candles
Get charting candles.
### Example:
 
```c#
    var candles = cobinhoodClient.GetCandles("ETH","BTC", Timeframe.TIMEFRAME_15_MINUTES).Result;
```
### Method Signature:

```c#
    public async Task<CandlesInfo> GetCandles(string quoteSymbol, string baseSymbol, Timeframe timeframe, DateTime? startTime = null, DateTime? endTime = null)
```