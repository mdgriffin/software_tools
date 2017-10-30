using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyClassLib
{
    public class CurrencyDataAccess
    {

        private static String baseUrl = "http://api.fixer.io/latest";

        public static String GetJSON()
        {
            var json = new WebClient().DownloadString(baseUrl);

            return json;
        }

        public static String GetJSON(String baseCurrencyCode)
        {
            var json = new WebClient().DownloadString(baseUrl + "?base=" + baseCurrencyCode);

            return json;
        }

    }
}
