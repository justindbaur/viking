using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viking.Client.App.Common
{
    public class Item
    {
        public string Name { get; set; }
        public Type Page { get; set; }
        public Dictionary<string, object> Keys { get; set; }
    }
}
