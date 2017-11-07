using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterFrontend.ViewModels
{
    class CurrencyGraphViewModel : BaseViewModel
    {
        public CurrencyGraphViewModel(BaseViewModel parent)
        {
            this.parent = parent;

            txtHeading = "Currency Graph";
        }

        public String txtHeading { get; set; }
    }
}
