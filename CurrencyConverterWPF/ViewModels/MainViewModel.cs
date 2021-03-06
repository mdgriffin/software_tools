﻿using System.Windows.Input;

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