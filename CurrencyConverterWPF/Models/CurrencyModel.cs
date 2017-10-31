using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterFrontend.Models
{
    public class CurrencyModel: BaseModel, INotifyDataErrorInfo
    {
        private String _from;
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

        private String _to;
        public String to
        {
            get
            {
                return this._to;
            }
            set
            {
                if (value != _to)
                {
                    this._from = value;
                    validateProp("to");
                    NotifyPropertyChanged("to");
                }
            }
        }

        private String _fromCode;
        public String fromCode
        {
            get
            {
                return this._fromCode;
            }
            set
            {
                if (value != _fromCode)
                {
                    this._from = value;
                    validateProp("fromCode");
                    NotifyPropertyChanged("fromCode");
                }
            }
        }

        private String _toCode;
        public String toCode
        {
            get
            {
                return this._toCode;
            }
            set
            {
                if (value != _toCode)
                {
                    this._from = value;
                    validateProp("toCode");
                    NotifyPropertyChanged("toCode");
                }
            }
        }

        public CurrencyModel(String fromCode, String from, String toCode, String to)
        {
            this._fromCode = fromCode;
            this._from = from;
            this._toCode = toCode;
            this._to = to;
        }

        public CurrencyModel() : this("", "", "", "") { }

        public override void validateAllProps()
        {
            validateProp("from");
            validateProp("to");
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
                case "to":
                    if (Validator.isEmpty(to))
                    {
                        errorMessage = Validator.ERROR_IS_EMPTY;
                    }
                    else if (!Validator.isPrice(to))
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
