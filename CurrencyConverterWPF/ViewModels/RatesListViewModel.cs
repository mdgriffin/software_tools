using CurrencyConverterFrontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyClassLib;

namespace CurrencyConverterFrontend.ViewModels
{
    class RatesListViewModel: BaseViewModel
    {
        public RatesListViewModel(BaseViewModel parent)
        {
            this.parent = parent;

            CurrencyExchanger cx = new CurrencyExchanger();

            currencyRates = cx.GetExchangeRatesList();

            txtHeading = "Current Rates";
        }

        // Properties accessible from the view
        public Rates currencyRates { get; set; }
        public String txtHeading { get; set; }
    }
}
