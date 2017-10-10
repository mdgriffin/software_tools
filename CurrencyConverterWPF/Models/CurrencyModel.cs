using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Models
{
    public class CurrencyModel: BaseModel, INotifyDataErrorInfo
    {
        public String _from;
        public String from
        {
            get
            {
                return this._from;
            }
            set
            {
                if (value != _from)
                {
                    this._from = value;
                    validateProp("from");
                    NotifyPropertyChanged("from");
                }
            }
        }

        public CurrencyModel(String from)
        {
            this._from = from;
        }

        public CurrencyModel() : this("") { }

        public override void validateAllProps()
        {
            validateProp("from");
        }

        public override void validateProp(String propertyName)
        {
            String errorMessage = "";

            switch (propertyName)
            {
                case "from":
                    if (Validator.isEmpty(from))
                    {
                        errorMessage = Validator.ERROR_IS_EMPTY;
                    } else if (!Validator.isPrice(from))
                    {
                        errorMessage = Validator.ERROR_IS_PRICE;
                    }
                    break;
            }
            if (errorMessage != "")
            {
                AddError(propertyName, errorMessage);
            }
            else
            {
                RemoveError(propertyName);
            }
        }
    }
}
