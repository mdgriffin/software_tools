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

            // Set the default base currency code
            selectedCurrency = "US Dollar (USD)";

            // Set the default heading
            txtHeading = "Dollar Rates";
        }

        public String txtHeading { get; set; }
        private String _selectedCurrency;
        public String selectedCurrency {
            get
            {
                return _selectedCurrency;
            }
            set
            {
                if (value != _selectedCurrency)
                {
                    _selectedCurrency = value;
                    NotifyPropertyChanged("selectedCurrency");
                    generateGraph();
                }
            }
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public ChartValues<double> chartValues { get; set; }
        public String[] chartLabels { get; set; }


        public void generateGraph ()
        {
            DateTime startTime = DateTime.Parse("15-04-2005");
            DateTime endTime = DateTime.Parse("15-04-2006");

            List<List<Object>> currencyTimeSeries = TimeSeries.GetTimeSeries(selectedCurrency.Substring(selectedCurrency.Length - 4, 3), startTime, endTime);

            if (chartLabels == null || chartValues == null)
            {
                chartLabels = new String[currencyTimeSeries.Count];
                chartValues = new ChartValues<double>();
            }
            
            int index = 0;

            chartValues.Clear();

            foreach (List<Object> timePoint in currencyTimeSeries)
            {
                chartLabels[index++] = (String)timePoint[0];
                chartValues.Add((double)timePoint[1]);
            }

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = selectedCurrency,
                    Values = chartValues
                },
            };

            Labels = chartLabels;


            YFormatter = value => value.ToString("C");
        }
    }
}
