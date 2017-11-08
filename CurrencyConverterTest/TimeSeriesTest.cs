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
            List<List<TimePoint>> timeSeries = TimeSeries.GetTimeSeries("USD", DateTime.ParseExact("25-04-2005", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateTime.ParseExact("25-04-2006", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture));

            int expectedNumTimePoints = 52;
            int actualNumTimePoints = 51;// timeSeries.Length;

            Assert.AreEqual(expectedNumTimePoints, actualNumTimePoints);
        }
    }
}
