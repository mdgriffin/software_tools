using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyClassLib
{
    public class CurrencyModel
    {
        public string @base { get; set; }
        public string date { get; set; }
        public Rates rates { get; set; }
    }
}
