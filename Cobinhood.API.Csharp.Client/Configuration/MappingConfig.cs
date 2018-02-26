using AutoMapper;
using Cobinhood.API.Csharp.Client.Models.General;
using Cobinhood.API.Csharp.Client.Models.Market;
using Cobinhood.API.Csharp.Client.Models.System;
using Cobinhood.API.Csharp.Client.Models.WebSocket;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cobinhood.API.Csharp.Client.Models.WebSocket.OrderResponse;
using static Cobinhood.API.Csharp.Client.Models.WebSocket.TickerResponse;
using static Cobinhood.API.Csharp.Client.Models.WebSocket.TradesResponse;

namespace Cobinhood.API.Csharp.Client.Configuration
{
    public static class MappingConfig
    {
        #region Resolvers
        private static Error ErrorResolver(JToken source)
        {
            if (source != null)
            {
                var result = new Error()
                {
                    ErrorCode = source["error_code"].ToString()
                };

                return result;
            }
            else
            {
                return null;
            }
        }

        private static OrderBookResult OrderBookResolver(JToken source)
        {
            if (source != null)
            {
                var result = new OrderBookResult();
                var orderBookResult = new Orderbook
                {
                    Sequence = int.Parse(source["sequence"].ToString()),
                    Bids = new List<Offer>(),
                    Asks = new List<Offer>()
                };

                // Populating bids
                var bids = (JArray)source["bids"];
                foreach (var item in bids)
                {
                    var bid = new Offer()
                    {
                        Price = item[0].ToString(),
                        Count = item[1].ToString(),
                        Size = item[2].ToString()
                    };

                    orderBookResult.Bids.Add(bid);
                }

                // Populating Asks
                var asks = (JArray)source["asks"];
                foreach (var item in asks)
                {
                    var ask = new Offer()
                    {
                        Price = item[0].ToString(),
                        Count = item[1].ToString(),
                        Size = item[2].ToString()
                    };

                    orderBookResult.Asks.Add(ask);
                }

                result.Orderbook = orderBookResult;

                return result;
            }
            else
            {
                return null;
            }
        }

        private static OrderBookResponseResult OrderBookResponseResolver(JToken source)
        {
            if (source != null)
            {
                var result = new OrderBookResponseResult()
                {
                    Bids = new List<Offer>(),
                    Asks = new List<Offer>()
                };

                // Populating bids
                var bids = (JArray)source["bids"];
                foreach (var item in bids)
                {
                    var bid = new Offer()
                    {
                        Price = item[0].ToString(),
                        Size = item[1].ToString(),
                        Count = item[2].ToString()
                    };

                    result.Bids.Add(bid);
                }

                // Populating Asks
                var asks = (JArray)source["asks"];
                foreach (var item in asks)
                {
                    var ask = new Offer()
                    {
                        Price = item[0].ToString(),
                        Size = item[1].ToString(),
                        Count = item[2].ToString()
                    };

                    result.Asks.Add(ask);
                }

                return result;
            }
            else
            {
                return null;
            }
        }

        private static List<TradesResponseResult> TradesResponseResolver(JArray source)
        {
            if (source != null)
            {
                var result = new List<TradesResponseResult>();

                foreach (var item in source)
                {
                    result.Add(new TradesResponseResult()
                    {
                        TradeId = item[0].ToString(),
                        Timestamp = item[1].ToString(),
                        Price = item[2].ToString(),
                        Size = item[3].ToString(),
                        MakerSide = item[4].ToString()
                    });
                }

                return result;
            }
            else
            {
                return null;
            }
        }

        private static TickerResponseResult TickerResponseResolver(JToken source)
        {
            if (source != null)
            {
                var result = new TickerResponseResult()
                {
                    LastTradeId = source[0].ToString(),
                    Price = source[1].ToString(),
                    HighestBid = source[2].ToString(),
                    LowestAsk = source[3].ToString(),
                    Volume24H = source[4].ToString(),
                    High24H = source[5].ToString(),
                    Low24H = source[6].ToString(),
                    Open24H = source[7].ToString(),
                    Timestamp = source[8].ToString(),
                };

                return result;
            }
            else
            {
                return null;
            }
        }

        private static List<CandleResponseResult> CandleResponseResolver(JToken source)
        {
            if (source != null)
            {
                if (source[0].HasValues)
                {
                    var result = new List<CandleResponseResult>();

                    foreach (var item in source)
                    {
                        result.Add(new CandleResponseResult()
                        {
                            Time = item[0].ToString(),
                            Open = item[1].ToString(),
                            Close = item[2].ToString(),
                            High = item[3].ToString(),
                            Low = item[4].ToString(),
                            Volume = item[5].ToString(),
                        });
                    }

                    return result;
                }
                else
                {
                    var result = new List<CandleResponseResult>();

                        result.Add(new CandleResponseResult()
                        {
                            Time = source[0].ToString(),
                            Open = source[1].ToString(),
                            Close = source[2].ToString(),
                            High = source[3].ToString(),
                            Low = source[4].ToString(),
                            Volume = source[5].ToString(),
                        });

                    return result;
                }
            }
            else
            {
                return null;
            }
        }

        private static OrderResponseResult OrderResponseResolver(JToken source)
        {
            if (source != null)
            {
                var result = new OrderResponseResult()
                {
                    OrderId = source[0].ToString(),
                    TradingPairId = source[1].ToString(),
                    Status = source[2].ToString(),
                    Side = source[3].ToString(),
                    Type = source[4].ToString(),
                    Price = source[5].ToString(),
                    Size = source[6].ToString(),
                    FilledSize = source[7].ToString(),
                    Timestamp = source[8].ToString(),
                };

                return result;
            }
            else
            {
                return null;
            }
        }
        #endregion

        public static void Initialize()
        {
            // Order Book
            Mapper.Initialize(configuration =>
            {
                configuration.CreateMap<JToken, OrderBookInfo>()
                    .ForMember(o => o.Success, cfg => { cfg.MapFrom(jo => jo["success"]); })
                    .ForMember(o => o.Error, cfg => { cfg.ResolveUsing(jo => ErrorResolver(jo["error"])); })
                    .ForMember(o => o.Result, cfg => cfg.ResolveUsing(jo => OrderBookResolver(jo["result"]["orderbook"])));

                configuration.CreateMap<JToken, OrderResponse>()
                     .ForMember(o => o.ChannelId, cfg => { cfg.MapFrom(jo => jo["channel_id"]); })
                     .ForMember(o => o.Snapshot, cfg => { cfg.ResolveUsing(jo => OrderResponseResolver(jo["snapshot"])); })
                     .ForMember(o => o.Update, cfg => cfg.ResolveUsing(jo => OrderResponseResolver(jo["update"])));

                configuration.CreateMap<JToken, OrderBookResponse>()
                     .ForMember(o => o.ChannelId, cfg => { cfg.MapFrom(jo => jo["channel_id"]); })
                     .ForMember(o => o.Snapshot, cfg => { cfg.ResolveUsing(jo => OrderBookResponseResolver(jo["snapshot"])); })
                     .ForMember(o => o.Update, cfg => cfg.ResolveUsing(jo => OrderBookResponseResolver(jo["update"])));

                configuration.CreateMap<JToken, TradesResponse>()
                    .ForMember(o => o.ChannelId, cfg => { cfg.MapFrom(jo => jo["channel_id"]); })
                    .ForMember(o => o.Snapshot, cfg => { cfg.ResolveUsing(jo => TradesResponseResolver((JArray)jo["snapshot"])); })
                    .ForMember(o => o.Update, cfg => cfg.ResolveUsing(jo => TradesResponseResolver((JArray)jo["update"])));

                configuration.CreateMap<JToken, TickerResponse>()
                     .ForMember(o => o.ChannelId, cfg => { cfg.MapFrom(jo => jo["channel_id"]); })
                     .ForMember(o => o.Snapshot, cfg => { cfg.ResolveUsing(jo => TickerResponseResolver(jo["snapshot"])); })
                     .ForMember(o => o.Update, cfg => cfg.ResolveUsing(jo => TickerResponseResolver(jo["update"])));

                configuration.CreateMap<JToken, CandleResponse>()
                    .ForMember(o => o.ChannelId, cfg => { cfg.MapFrom(jo => jo["channel_id"]); })
                    .ForMember(o => o.Snapshot, cfg => { cfg.ResolveUsing(jo => CandleResponseResolver(jo["snapshot"])); })
                    .ForMember(o => o.Update, cfg => cfg.ResolveUsing(jo => CandleResponseResolver(jo["update"])));
            });
        }
    }
}
