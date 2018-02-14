using System.ComponentModel;

namespace Cobinhood.API.Csharp.Client.Models.Enums
{
    /// <summary>
    /// Different types of an order.
    /// </summary>
    public enum OrderType
    {
        [Description("market")]
        Market,
        [Description("limit")]
        Limit,
        [Description("stop")]
        Stop,
        [Description("stop_limit")]
        StopLimit
    }
}
