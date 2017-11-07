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
            String jsonData = TimeSeriesDataAccess.GetJSON("USD", DateTime.ParseExact("25-04-2005", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateTime.ParseExact("25-04-2006", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture));

            Assert.IsTrue(jsonData.Length > 0);
        }
    }
}
