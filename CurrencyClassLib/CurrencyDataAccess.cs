﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyClassLib
{
    public class CurrencyDataAccess
    {

        public String GetJSON ()
        {
            String url = "http://api.fixer.io/";

            var json = new WebClient().DownloadString(url);

            return json;
        }


        /*
        public Rates GetRates (String baseCurrency)
        {

        }

        public Rates GetRates(String baseCurrency, DateTime date)
        {

        }
        */

    }
}
