using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyClassLib;
using System.Collections.Generic;

namespace CurrencyConverterTest
{
    [TestClass]
    public class CurrencyExchangerTest
    {
        [TestMethod]
        public void GetExchangeRatesListTest()
        {
            CurrencyExchanger cc = new CurrencyExchanger();

            Rates rates = cc.GetExchangeRatesList("USD");

            Assert.IsNotNull(rates.AUD);
        }

        [TestMethod]
        public void ExhangeRatesChangeOnBaseCurrencyChange()
        {
            CurrencyExchanger cc = new CurrencyExchanger();

            Rates initialRates = cc.GetExchangeRatesList("USD");
            Rates changedRates = cc.GetExchangeRatesList("EUR");

            Assert.AreNotEqual(initialRates.USD, changedRates.USD);
        }



        [TestMethod]
        public void GetExchangeRateTest()
        {
            CurrencyExchanger cc = new CurrencyExchanger();
            Double actualRate = cc.GetExchangeRate("EUR", "JPY");
            double expectedRate = 0.5;

            Assert.AreEqual(expectedRate, actualRate);
        }

        [TestMethod]
        public void ConvertTest()
        {
            CurrencyExchanger cc = new CurrencyExchanger();

            double valueToConvert = 125;
            double expectedValue = valueToConvert * 0.5;
            double actualValue = cc.Convert(valueToConvert, "USD", "EUR");

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
