using System;
using CurrencyConverterFrontend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CurrencyClassLib;

namespace CurrencyConverterFrontend.ViewModels
{
    public class ConversionFormViewModel: BaseViewModel
    {

        public ConversionFormViewModel(BaseViewModel parent)
        {
            this.parent = parent;

            currency = new CurrencyFormModel();

            btnText = "Convert!";
            txtHeading = "Convert Currencies";
        }

        // Properties accessible from the view
        public CurrencyFormModel currency { get; set; }
        public String txtHeading { get; set; }
        public String btnText { get; set; }

        public ICommand convertCmd
        {
            get
            {
                return new RelayCommand(param => OnConvertClick(), param => true);
            }
        }


        public void OnConvertClick ()
        {
            //currency.from
            CurrencyExchanger cx = new CurrencyExchanger();

            //cx.Convert(currency.from, currency.fromCode, currency.toCode);

            if (!currency.HasErrors)
            {
                String fromCurrencyCode = currency.fromCode.Substring(currency.fromCode.Length - 4, 3);
                String toCurrencyCode = currency.toCode.Substring(currency.toCode.Length - 4, 3);

                currency.to = cx.Convert(Double.Parse(currency.from), fromCurrencyCode, toCurrencyCode).ToString();
            }
        }
    }
}
