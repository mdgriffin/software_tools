using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyClassLib
{
    public interface ICurrencyDataAccess
    {

        CurrencyModel GetData();

        CurrencyModel GetData(String baseCurrencyCode);
    }
}
