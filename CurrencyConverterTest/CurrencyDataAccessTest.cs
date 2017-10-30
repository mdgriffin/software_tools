using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyClassLib;

namespace CurrencyConverterTest
{
    [TestClass]
    public class CurrencyDataAccessTest
    {
        [TestMethod]
        public void TestGetJSON()
        {
            String jsonData = CurrencyDataAccess.GetJSON();

            Assert.IsTrue(jsonData.Length > 0);
        }

        [TestMethod]
        public void TestGetJSONForCurrency()
        {
            String jsonData = CurrencyDataAccess.GetJSON("EUR");

            Assert.IsTrue(jsonData.Length > 0);
        }
    }
}
