using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyClassLib
{
    public class ECBDataAccess: ICurrencyDataAccess
    {

        public CurrencyModel GetData ()
        {
            return GetData("EUR");
        }

        public CurrencyModel GetData (String baseCurrencyCode)
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(Envelope));

            var xmlResponse = new WebClient().DownloadString("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");

            StringReader sr = new StringReader(xmlResponse);

            // Deserialize xml into Envelope Model
            Envelope ev = (Envelope)ser.Deserialize(sr);

            // Convert the envelope model into the standard currency model
            return EnvelopeToCurrencyModel(ev, baseCurrencyCode);
        }

        private CurrencyModel EnvelopeToCurrencyModel (Envelope envelope, String baseCurrencyCode)
        {
            // Initialize currency model
            CurrencyModel currencyModel = new CurrencyModel();
            currencyModel.@base = baseCurrencyCode;
            currencyModel.date = envelope.Cube.Cube1.time.ToString("yyyy-MM-dd");
            currencyModel.rates = new Rates();
            double conversionFactor = 1;

            // Set the base currency to 1
            currencyModel.rates.GetType().GetProperty(baseCurrencyCode).SetValue(currencyModel.rates, (double)1, null);

            var cubeList = envelope.Cube.Cube1.Cube;

            if (!baseCurrencyCode.Equals("EUR"))
            {
                // USD to BGN     = (EURBGN / USDEUR)
                conversionFactor = (double)cubeList.Where(item => item.currency.Equals(baseCurrencyCode)).First().rate;

            }

            // foreach cube item in the list
            foreach (var cubeItem in cubeList)
            {
                currencyModel.rates.GetType().GetProperty(cubeItem.currency).SetValue(currencyModel.rates, (double)cubeItem.rate / conversionFactor, null);
            }

            return currencyModel;
        }

    }
}
