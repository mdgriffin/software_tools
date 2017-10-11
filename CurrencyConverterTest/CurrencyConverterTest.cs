using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyClassLib;
using System.Collections.Generic;

namespace CurrencyConverterTest
{
    [TestClass]
    public class CurrencyConverterTest
    {
        [TestMethod]
        public void GetExchangeRatesTest()
        {
            CurrencyConverter cc = new CurrencyConverter();

            Dictionary<String, double> rates = cc.GetExchangeRates("EUR");

            Assert.AreEqual(rates.Count, 2);

        }


        [TestMethod]
        public void GetExchangeRateTest()
        {
            CurrencyConverter cc = new CurrencyConverter();
            Double exchangeRate = cc.GetExchangeRate("EUR", "USD");

            Assert.AreEqual(exchangeRate, 0.5);
        }
    }
}
