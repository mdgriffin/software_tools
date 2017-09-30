using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.ViewModels
{
    public class ConversionFormViewModel: BaseViewModel
    {

        public ConversionFormViewModel(BaseViewModel parent)
        {
            this.parent = parent;

            btnText = "Convert!";
            btnHeading = "Convert Currencies";
        }

        // Properties accessible from the view
        public String btnHeading { get; set; }
        public String btnText { get; set; }
    }
}
