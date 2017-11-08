using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyClassLib;
using System.Collections.Generic;

namespace CurrencyConverterTest
{
    [TestClass]
    public class TimeSeriesTest
    {
        [TestMethod]
        public void GetTimeSeriesTest()
        {
            List<List<Object>> timeSeries = TimeSeries.GetTimeSeries("USD", DateTime.ParseExact("25-04-2005", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateTime.ParseExact("25-04-2006", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture));

            int expectedNumTimePoints = 53;
            int actualNumTimePoints = timeSeries.Count;

            Assert.AreEqual(expectedNumTimePoints, actualNumTimePoints);
        }
    }
}
