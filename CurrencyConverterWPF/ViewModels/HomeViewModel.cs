using CurrencyConverterFrontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CurrencyConverterFrontend.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(BaseViewModel parent)
        {
            this.parent = parent;

            // Set the public properties for the view
            //numCustomers = CustomerModel.getNumCustomers();
        }

        // The public properties accessible from the view
        //public int numCustomers { get; set; }
    }
}