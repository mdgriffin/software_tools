using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterFrontend.ViewModels
{
    class ConversionHistoryViewModel : BaseViewModel
    {

        public ConversionHistoryViewModel(BaseViewModel parent)
        {
            this.parent = parent;

            txtHeading = "Currency Conversion History";

            using (var ctx = new CurrencyEntityModel())
            {
                //int numConversions =  ctx.Conversions.Count();

                ctx.Conversions.Load();
                Conversions = ctx.Conversions.ToList();
            }
        }

        public String txtHeading { get; set; }
        public List<Conversion> Conversions { get; set; }
    }
}
