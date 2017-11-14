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

            MockDataAccess mda = new MockDataAccess();
            CurrencyModel cm = mda.GetData();

            Assert.AreEqual("EUR", cm.@base);
        }

    }
}
