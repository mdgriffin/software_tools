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

            rates = cx.GetExchangeRatesList();

            txtHeading = "Euro Rates";

            baseCurrency = "Euro (EUR)";
        }

        // Properties accessible from the view
        public Rates rates { get; set; }
        public String txtHeading { get; set; }

        public String baseCurrency { get; set; }
    }
}
