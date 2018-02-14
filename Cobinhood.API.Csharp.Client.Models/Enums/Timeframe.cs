using System.ComponentModel;

namespace Cobinhood.API.Csharp.Client.Models.Enums
{
    public enum Timeframe
    {
        [Description("1m")]
        TIMEFRAME_1_MINUTE,
        [Description("5m")]
        TIMEFRAME_5_MINUTES,
        [Description("15m")]
        TIMEFRAME_15_MINUTES,
        [Description("30m")]
        TIMEFRAME_30_MINUTES,
        [Description("1h")]
        TIMEFRAME_1_HOUR,
        [Description("3h")]
        TIMEFRAME_3_HOURS,
        [Description("6h")]
        TIMEFRAME_6_HOURS,
        [Description("12h")]
        TIMEFRAME_12_HOUR,
        [Description("1D")]
        TIMEFRAME_1_DAY,
        [Description("7D")]
        TIMEFRAME_7_DAYS,
        [Description("14D")]
        TIMEFRAME_14_DAYS,
        [Description("1M")]
        TIMEFRAME_1_MONTH
    }
}
