using System;
using CurrencyConverterFrontend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterFrontend.ViewModels
{
    public class ConversionFormViewModel: BaseViewModel
    {

        public ConversionFormViewModel(BaseViewModel parent)
        {
            this.parent = parent;

            currency = new CurrencyModel();

            btnText = "Convert!";
            btnHeading = "Convert Currencies";
        }

        // Properties accessible from the view
        public CurrencyModel currency { get; set; }
        public String btnHeading { get; set; }
        public String btnText { get; set; }
    }
}
