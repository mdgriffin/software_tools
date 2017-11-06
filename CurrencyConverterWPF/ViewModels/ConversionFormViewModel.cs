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

            currency = new CurrencyFormModel("Euro (EUR)", "0", "US Dollar (USD)", "0");

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

                using (var ctx = new CurrencyEntityModel())
                {

                    //Can perform CRUD operation using ctx here..
                    //Conversion conv = ctx.Conversions.Find(1);
                    Conversion conv = new Conversion
                    {
                        SourceCurrency = fromCurrencyCode,
                        DestinationCurrency = toCurrencyCode,
                        Amount = Decimal.Parse(currency.from),
                        ConvertedAmount = Decimal.Parse(currency.from)
                    };

                    ctx.Conversions.Add(conv);
                    ctx.SaveChanges();
                }

            }

        }
    }
}
