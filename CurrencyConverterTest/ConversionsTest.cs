using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyClassLib;
using System.Collections.Generic;

namespace CurrencyConverterTest
{
    [TestClass]
    public class ConversionsTest
    {
        [TestMethod]
        public void GetExchangeRatesListTest()
        {
            CurrencyConverter cc = new CurrencyConverter();

            Rates rates = cc.GetExchangeRatesList("EUR");

            Assert.IsNotNull(rates.AUD);
        }

        [TestMethod]
        public void GetExchangeRateTest()
        {
            CurrencyConverter cc = new CurrencyConverter();
            Double actualRate = cc.GetExchangeRate("EUR", "USD");
            double expectedRate = 0.5;

            Assert.AreEqual(expectedRate, actualRate);
        }

        [TestMethod]
        public void ConvertTest ()
        {
            CurrencyConverter cc = new CurrencyConverter();

            double valueToConvert = 125;
            double expectedValue = valueToConvert * 0.5;
            double actualValue = cc.Convert(valueToConvert, "USD", "EUR");

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
