using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Models.Trading
{
    public class NewOrder
    {
        public string trading_pair_id { get; set; }
        public string side { get; set; }
        public string type { get; set; }
        public string price { get; set; }
        public string size { get; set; }
    }
}
