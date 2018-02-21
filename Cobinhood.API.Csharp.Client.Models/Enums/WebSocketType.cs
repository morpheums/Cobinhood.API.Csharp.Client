using System.ComponentModel;

namespace Cobinhood.API.Csharp.Client.Models.Enums
{
    public enum WebSocketType
    {
        [Description("order")]
        Order,
        [Description("trade")]
        Trade,
        [Description("order-book")]
        OrderBook,
        [Description("candle")]
        Candle,
        [Description("ping")]
        Ping
    }
}
