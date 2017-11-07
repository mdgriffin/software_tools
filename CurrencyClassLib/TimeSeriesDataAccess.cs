using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyClassLib
{
    class TimeSeriesDataAccess
    {
        private const String API_KEY = "7KWFxr5nhMn4NDm4jtNC";
        private const String BASE_URL = "https://www.quandl.com/api/v3/datasets/ECB/";

        public static String GetJSON(String baseCurrencyCode, String destinationCurrencyCode)
        {
            String arguments = String.Format(
                "{0}{1}?start_date={2}&end_date={3}&collapse=weekly&api_key={4}",
                baseCurrencyCode,
                destinationCurrencyCode,
                "01-05-2005",
                "01-05-2006",
                API_KEY
            );

            var json = new WebClient().DownloadString(BASE_URL + arguments);

            return json;
        }
    }
}
