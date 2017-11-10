using System.Windows.Input;

namespace CurrencyConverterFrontend.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
            this.parent = this;
            // The first view model is the conversion view model
            navigateTo(new ConversionFormViewModel(this));
        }

        private string _SpinnerVisibility;
        public string SpinnerVisibilty
        {
            get
            {
                // if not initialized set to default value
                if (string.IsNullOrEmpty(_SpinnerVisibility))
                {
                    _SpinnerVisibility = "Hidden";
                }
                return _SpinnerVisibility;
            }
            set
            {
                if (value != _SpinnerVisibility)
                {
                    _SpinnerVisibility = value;
                    NotifyPropertyChanged("SpinnerVisibility");
                }
            }
        }

        private bool _IsLoading;
        public bool IsLoading {
            get
            {
                return _IsLoading;
            }
            set
            {
                if (value != _IsLoading)
                {
                    _IsLoading = value;
                    SpinnerVisibilty = (value ? "Visible" : "Hidden");
                }
            }
        }

        public ICommand GoToConversionForm
        {
            get
            {
                return new RelayCommand(param => navigateTo(new ConversionFormViewModel(this)), param => true);
            }
        }

        public ICommand GoToRatesListing
        {
            get
            {
                return new RelayCommand(param => navigateTo(new RatesListViewModel(this)), param => true);
            }
        }

        public ICommand GoToConversionHistory
        {
            get
            {
                return new RelayCommand(param => navigateTo(new ConversionHistoryViewModel(this)), param => true);
            }
        }

        public ICommand GoToCurrencyGraph
        {
            get
            {
                return new RelayCommand(param => navigateTo(new CurrencyGraphViewModel(this)), param => true);
            }
        }

    }
}