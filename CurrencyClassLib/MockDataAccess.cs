using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyClassLib
{
    public class MockDataAccess: ICurrencyDataAccess
    {

        public CurrencyModel GetData ()
        {
            CurrencyModel cm = new CurrencyModel();

            cm.@base = "EUR";
            cm.date = DateTime.Now.ToString("yyyy-MM-dd");
            cm.rates = new Rates();

            var rateProperties = cm.rates.GetType().GetProperties();//.ToList();

            foreach (var rateProperty in rateProperties)
            {
                // Set all the currency value to 1.5 for eacy testing
                cm.rates.GetType().GetProperty(rateProperty.Name).SetValue(cm.rates, 1.5);
            }

            // Set the base currency value
            cm.rates.EUR = 1;

            return cm;
        }
    }
}
