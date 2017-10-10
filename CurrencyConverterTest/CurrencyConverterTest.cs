using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyClassLib;
using System.Collections.Generic;

namespace CurrencyConverterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CurrencyConverterTest()
        {
            CurrencyConverter cc = new CurrencyConverter();

            Dictionary<String, double> rates = cc.GetExchangeRates();

            Assert.AreEqual(rates.Count, 1);

        }
    }
}
