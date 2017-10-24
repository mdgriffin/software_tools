using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyClassLib
{
    public class CurrencyExchanger
    {

        private static CurrencyModel currencyModel;

        public CurrencyExchanger ()
        {
            if (currencyModel == null)
            {
                // Need to specifiy base currency
                String currencyJson = CurrencyDataAccess.GetJSON();
                currencyModel = JsonConvert.DeserializeObject<CurrencyModel>(currencyJson);
            }
        }

        public Rates GetExchangeRatesList(String baseCurrency)
        {
            /*
            if (currencyModel.@base.Equals(baseCurrency))
            {
                return currencyModel.rates;
            }
            */

            return currencyModel.rates;

        }

        public double GetExchangeRate (String fromCurrencyCode, String toCurrencyCode)
        {
            return 0.5;
        }

        public double Convert (double value, String fromCurrency, String toCurrency)
        {
            double rate = GetExchangeRate(fromCurrency, toCurrency);

            return value * rate;
        }

    }
}
