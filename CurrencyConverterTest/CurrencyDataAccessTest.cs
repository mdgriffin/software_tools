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

            CurrencyDataAccess cd = new CurrencyDataAccess();

            String jsonData = cd.GetJSON();

            Assert.AreEqual(jsonData.Length, 0);
        }
    }
}
