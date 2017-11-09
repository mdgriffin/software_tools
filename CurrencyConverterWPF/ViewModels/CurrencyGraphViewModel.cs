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

            // The minimum and maximum dates that can be selected
            dateRangeMin = "1/01/2000";
            dateRangeMax = DateTime.Today.ToString("M/dd/yyyy");
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
        public String dateRangeMin { get; set; }
        public String dateRangeMax { get; set; }

        // nullable type to ensure that if has not been set it will null
        private DateTime? _dateRangeStart;
        public DateTime dateRangeStart {
            get
            {
                // if not defined set with default value
                if (_dateRangeStart == null)
                {
                    _dateRangeStart = DateTime.Today.AddYears(-1);
                }
                return _dateRangeStart.Value;
            }
            set
            {
                if (value != _dateRangeStart)
                {
                    _dateRangeStart = value;
                }
                
            }
        }

        // nullable type to ensure that if has not been set it will null
        private DateTime? _dateRangeEnd;
        public DateTime dateRangeEnd
        {
            get
            {
                // if not defined set with default value
                if (_dateRangeEnd == null)
                {
                    _dateRangeEnd = DateTime.Today;
                }
                return _dateRangeEnd.Value;
            }
            set
            {
                if (value != _dateRangeEnd)
                {
                    _dateRangeEnd = value;
                }

            }
        }


        public void generateGraph ()
        {
            List<List<Object>> currencyTimeSeries = TimeSeries.GetTimeSeries(selectedCurrency.Substring(selectedCurrency.Length - 4, 3), dateRangeStart, dateRangeEnd);

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
