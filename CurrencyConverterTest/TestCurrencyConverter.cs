using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyConverterTest
{
    [TestClass]
    public class TestCurrencyConverter
    {

        [TestMethod]
        public void TestGetChangeRates()
        {
            CurrencyConverterTest cc = new CurrencyConverter();

            List<CurrencyModel> rates = cc.GetExchangeRates();


            Assert.AreEqual(10, rates.length);
        }
    }
}
