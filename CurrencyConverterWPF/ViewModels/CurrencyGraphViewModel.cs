using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using CurrencyClassLib;

namespace CurrencyConverterFrontend.ViewModels
{
    class CurrencyGraphViewModel : BaseViewModel
    {
        public CurrencyGraphViewModel(BaseViewModel parent)
        {
            this.parent = parent;

            txtHeading = "Currency Graph";

            DateTime startTime = DateTime.Parse("15-04-2005");
            DateTime endTime = DateTime.Parse("15-04-2006");
            

            List<List<Object>> currencyTimeSeries = TimeSeries.GetTimeSeries("USD", startTime, endTime);

            ChartValues<double> chartValues = new ChartValues<double>();
            String[] chartLabels = new String[currencyTimeSeries.Count];
            int index = 0;

            foreach (List<Object> timePoint in currencyTimeSeries)
            {
                chartLabels[index++] = (String)timePoint[0];
                chartValues.Add((double)timePoint[1]);
            }

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "USD",
                    Values = chartValues
                },
            };

            Labels = chartLabels;


            //YFormatter = value => value.ToString("C");
        }

        public String txtHeading { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        //public Func<double, string> YFormatter { get; set; }
    }
}
