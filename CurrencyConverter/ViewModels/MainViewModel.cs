using System.Windows.Input;

namespace CurrencyConverter.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
            this.parent = this;
            // The first view model is the home view model
            navigateTo(new ConversionFormViewModel(this));
        }

        public ICommand doSomething
        {
            get
            {
                return new RelayCommand(param => System.Windows.MessageBox.Show("Do Something"), param => true);
            }
        }

        public ICommand doSomethingElse
        {
            get
            {
                return new RelayCommand(param => System.Windows.MessageBox.Show("Do Something Else"), param => true);
            }
        }

        /*
        public ICommand goToSettings
        {
            get
            {
                return new RelayCommand(param => navigateTo(new SettingsViewModel(this)), param => true);
            }
        }
        */

    }
}