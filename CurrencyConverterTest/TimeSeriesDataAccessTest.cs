using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyClassLib;

namespace CurrencyConverterTest
{
    [TestClass]
    public class TimeSeriesDataAccessTest
    {
        [TestMethod]
        public void TestGetJSON()
        {
            String jsonData = TimeSeriesDataAccess.GetJSON("USD");

            Assert.IsTrue(jsonData.Length > 0);
        }
    }
}
