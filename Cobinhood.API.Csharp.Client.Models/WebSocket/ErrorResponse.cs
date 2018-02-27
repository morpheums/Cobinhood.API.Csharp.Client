using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Models.WebSocket
{
    public class ErrorResponse
    {
        public string Event { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
