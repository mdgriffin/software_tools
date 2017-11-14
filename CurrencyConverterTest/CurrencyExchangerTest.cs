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
            CurrencyExchanger cc = new CurrencyExchanger(new MockDataAccess());

            Rates rates = cc.GetExchangeRatesList("USD");

            Assert.IsNotNull(rates.AUD);
        }

        [TestMethod]
        public void ExhangeRatesChangeOnBaseCurrencyChange()
        {
            CurrencyExchanger cc = new CurrencyExchanger(new MockDataAccess());

            Rates initialRates = cc.GetExchangeRatesList("EUR");
            Rates changedRates = cc.GetExchangeRatesList("USD");

            Assert.AreNotEqual(initialRates.USD, changedRates.USD);
        }



        [TestMethod]
        public void GetExchangeRateTest()
        {
            CurrencyExchanger cc = new CurrencyExchanger(new MockDataAccess());
            Double actualRate = cc.GetExchangeRate("EUR", "JPY");
            double expectedRate = 1.5;

            Assert.AreEqual(expectedRate, actualRate, 0.01);
        }

        [TestMethod]
        public void ConvertTest()
        {
            CurrencyExchanger cc = new CurrencyExchanger(new MockDataAccess());

            double valueToConvert = 125;
            double expectedValue = valueToConvert * 1.5;
            double actualValue = cc.Convert(valueToConvert, "EUR", "USD");

            Assert.AreEqual(expectedValue, actualValue, 0.01);
        }
    }
}
