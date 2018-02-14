using System.ComponentModel;

namespace Cobinhood.API.Csharp.Client.Models.Enums
{
    /// <summary>
    /// Different sides of an order.
    /// </summary>
    public enum OrderSide
    {
        [Description("bid")]
        Bid,
        [Description("ask")]
        Ask
    }
}
