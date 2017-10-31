using System.Windows.Input;

namespace CurrencyConverterFrontend.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
            this.parent = this;
            // The first view model is the home view model
            navigateTo(new ConversionFormViewModel(this));
        }

        public ICommand goToConversionForm
        {
            get
            {
                return new RelayCommand(param => navigateTo(new ConversionFormViewModel(this)), param => true);
            }
        }

        public ICommand goToRatesListing
        {
            get
            {
                return new RelayCommand(param => navigateTo(new RatesListViewModel(this)), param => true);
            }
        }

    }
}