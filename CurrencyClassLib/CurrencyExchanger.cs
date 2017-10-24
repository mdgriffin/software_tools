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

        private CurrencyModel currencyModel;

        public CurrencyExchanger()
        {
            String currencyJson = CurrencyDataAccess.GetJSON();
            currencyModel = JsonConvert.DeserializeObject<CurrencyModel>(currencyJson);
        }


        public Rates GetExchangeRatesList(String baseCurrency)
        {
            return currencyModel.rates;
        }

        public double GetExchangeRate (String fromCurrency, String toCurrency)
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
