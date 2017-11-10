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
                SetCurrencyModel("USD");
            }
        }

        private void SetCurrencyModel(String baseCurrencyCode)
        {
            currencyModel = CurrencyDataProvider.GetData(baseCurrencyCode);
        }

        public Rates GetExchangeRatesList()
        {
            // The default currency
            return GetExchangeRatesList("EUR");
        }

        public Rates GetExchangeRatesList(String baseCurrencyCode)
        {
            if (!currencyModel.@base.Equals(baseCurrencyCode))
            {
                SetCurrencyModel(baseCurrencyCode);
            }

            return currencyModel.rates;
        }

        public double GetExchangeRate(String baseCurrencyCode, String toCurrencyCode)
        {
            if (!currencyModel.@base.Equals(baseCurrencyCode))
            {
                SetCurrencyModel(baseCurrencyCode);
            }

            // Using reflection to get the value of property from the property name as a String
            return (double)currencyModel.rates.GetType().GetProperty(toCurrencyCode).GetValue(currencyModel.rates, null);

        }

        public double Convert(double value, String fromCurrency, String toCurrency)
        {
            double rate = GetExchangeRate(fromCurrency, toCurrency);

            return (double)decimal.Round((decimal)(value * rate), 2, MidpointRounding.AwayFromZero);
        }

    }
}
