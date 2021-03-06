﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyClassLib
{
    public class FixerAPIAccess: ICurrencyDataAccess
    {

        private static String baseUrl = "http://api.fixer.io/latest";
        private static String baseCurrencyCode = "EUR";

        public CurrencyModel GetData()
        {
            var json = new WebClient().DownloadString(baseUrl);

            CurrencyModel currencyModel = JsonConvert.DeserializeObject<CurrencyModel>(json);

            currencyModel.rates.GetType().GetProperty(baseCurrencyCode).SetValue(currencyModel.rates, (double)1, null);

            return currencyModel;
        }

    }
}
