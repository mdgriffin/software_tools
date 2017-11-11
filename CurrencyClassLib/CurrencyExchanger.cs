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
        private ICurrencyDataAccess CurrencyDataProvider;

        public CurrencyExchanger(ICurrencyDataAccess DataProvider)
        {
            CurrencyDataProvider = DataProvider;

            if (currencyModel == null)
            {
                // Set the Currency Model with the default currency
                currencyModel = CurrencyDataProvider.GetData();
            }
        }

        public Rates GetExchangeRatesList()
        {
            // The default currency
            return GetExchangeRatesList("EUR");
        }

        public Rates GetExchangeRatesList(String baseCurrencyCode)
        {

            Rates rates;

            if (!currencyModel.@base.Equals(baseCurrencyCode))
            {
                // create a new rates list
                rates = new Rates();
                double conversionFactor = GetExchangeRate("EUR", baseCurrencyCode);

                foreach(var rate in currencyModel.rates.GetType().GetProperties())
                {
                    // foreach rate, set the new rate based on the base currency
                    rates.GetType().GetProperty(rate.Name).SetValue(rates, (double)rate.GetValue(currencyModel.rates, null) / conversionFactor);
                }
            } else
            {
                // If the currency is the same as the default base
                rates = currencyModel.rates;
            }

            return rates;
        }

        public double GetExchangeRate(String baseCurrencyCode, String toCurrencyCode)
        {
            // Using reflection to get the value of property from the property name as a String
            double conversionFactor = (double)currencyModel.rates.GetType().GetProperty(baseCurrencyCode).GetValue(currencyModel.rates, null);

            return (double)currencyModel.rates.GetType().GetProperty(toCurrencyCode).GetValue(currencyModel.rates, null) / conversionFactor;

        }

        public double Convert(double value, String fromCurrency, String toCurrency)
        {
            double rate = GetExchangeRate(fromCurrency, toCurrency);

            return (double)decimal.Round((decimal)(value * rate), 2, MidpointRounding.AwayFromZero);
        }

    }
}
