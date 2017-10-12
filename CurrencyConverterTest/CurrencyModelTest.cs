using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyConverterFrontend.Models;

namespace CurrencyConverterTest
{
    [TestClass]
    public class CurrencyModelTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            String expectedResult = "USD";
            CurrencyModel currency = new CurrencyModel(expectedResult);
            String actualResult = currency.from;

            Assert.Equals(expectedResult, actualResult);
        }
    }
}
