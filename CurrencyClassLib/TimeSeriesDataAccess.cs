using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyClassLib
{
    public class TimeSeriesDataAccess
    {
        private const String BASE_URL = "https://www.quandl.com/api/v3/datasets/ECB/";
        private const String API_KEY = "7KWFxr5nhMn4NDm4jtNC";

        public static String GetJSON(String currencyCode, DateTime startDate, DateTime endDate)
        {
            String fullUrl = String.Format(
                "{0}EUR{1}.json?order=asc&start_date={2}&end_date={3}&collapse=weekly&api_key={4}",
                BASE_URL,
                currencyCode,
                startDate.ToString("dd-MM-yyyy"),
                endDate.ToString("dd-MM-yyyy"),
                API_KEY
            );

            var json = new WebClient().DownloadString(fullUrl);

            return json;
        }
    }
}
