using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyClassLib
{
    public class CurrencyConverter
    {

        public CurrencyConverter()
        {
        }


        public Dictionary<String, double> GetExchangeRatesList(String baseCurrency)
        {
            Dictionary<String, double> rates = new Dictionary<String, double>();

            rates.Add("EUR", 0.75);
            rates.Add("USD", 0.9);

            return rates;
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
