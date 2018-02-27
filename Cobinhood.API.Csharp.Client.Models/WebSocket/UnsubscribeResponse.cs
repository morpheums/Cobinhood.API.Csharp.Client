using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Models.WebSocket
{
    public class UnsubscribeResponse
    {
        public bool Success { get; set; }
        public string Event { get; set; }
        public string ChannelId { get; set; }
        public ErrorResponse Error { get; set; }
    }
}
