using CurrencyConverterFrontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyClassLib;
using System.Windows;

namespace CurrencyConverterFrontend.ViewModels
{
    class RatesListViewModel: BaseViewModel
    {
        public RatesListViewModel(BaseViewModel parent)
        {
            this.parent = parent;

            cx = new CurrencyExchanger();

            baseCurrency = "Euro (EUR)";
        }

        private CurrencyExchanger cx;

        // Properties accessible from the view
        private Rates _rates;
        public Rates rates {
            get
            {
                return _rates;
            }
            set
            {
                if (value != _rates)
                {
                    _rates = value;
                    NotifyPropertyChanged("rates");
                }
            }
        }
        private String _txtHeading;
        public String txtHeading {
            get
            {
                return _txtHeading;
            }
            set
            {
                if (value != _txtHeading)
                {
                    _txtHeading = value;
                    NotifyPropertyChanged("txtHeading");
                }
            }
        }

        private String _baseCurrency;
        public String baseCurrency {
            get
            {
                return _baseCurrency;
            }
            set
            {
                if (value != baseCurrency)
                {
                    _baseCurrency = value;
                    NotifyPropertyChanged("baseCurrency");
                    OnSetBaseCurrency();
                }
                
            }
        }

        private void OnSetBaseCurrency ()
        {
            txtHeading = "Rates For " + baseCurrency.Substring(0, baseCurrency.Length - 5);
            String baseCurrencyCode = baseCurrency.Substring(baseCurrency.Length - 4, 3);
            rates = cx.GetExchangeRatesList(baseCurrencyCode);
        }
    }
}
