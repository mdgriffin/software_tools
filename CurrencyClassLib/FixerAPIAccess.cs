using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyClassLib
{
    public class FixerAPIAccess: ICurrencyDataAccess
    {

        private static String baseUrl = "http://api.fixer.io/latest";

        public CurrencyModel GetData()
        {
            var json = new WebClient().DownloadString(baseUrl);

            return JsonConvert.DeserializeObject<CurrencyModel>(json);
        }

        public CurrencyModel GetData(String baseCurrencyCode)
        {
            var json = new WebClient().DownloadString(baseUrl + "?base=" + baseCurrencyCode);
            return JsonConvert.DeserializeObject<CurrencyModel>(json);
        }

    }
}
