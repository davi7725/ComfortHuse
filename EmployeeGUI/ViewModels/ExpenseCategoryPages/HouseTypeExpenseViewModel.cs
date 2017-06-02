using Comforthuse.Interfaces;
using Comforthuse.Models;
using EmployeeGUI.Helpers;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class HouseTypeExpenseViewModel : BaseExpenseViewModel
    {

        private IHouseTypeExpenses _houseTypeExpensesModel;

        public string HouseTypeDescription
        {
            get
            {
                return _houseTypeExpensesModel.HouseType.Description;
            }
            set
            {
                _houseTypeExpensesModel.HouseType.Description = value;
            }

        }

        public string HouseTypeName
        {
            get
            {
                return _houseTypeExpensesModel.HouseType.Name;
            }
            set
            {
                _houseTypeExpensesModel.HouseType.Name = value;
            }
        }

        public string HouseTypeTotalPrice
        {
            get
            {
                if (_houseTypeExpensesModel.HouseType.TotalPrice == null)
                {
                    return "";
                }
                else
                {
                    return _houseTypeExpensesModel.HouseType.TotalPrice.ToString();
                }
            }
            set
            {
                decimal totalprice;
                if (decimal.TryParse(value, out totalprice))
                {
                    _houseTypeExpensesModel.HouseType.TotalPrice = totalprice;
                }
                else
                {
                    if (value != "")
                    {
                        MessageHandling.DisplayErrorMessage("Can only contain numbers");
                    }
                    else
                    {
                        _houseTypeExpensesModel.HouseType.TotalPrice = 0;
                    }
                }
            }
        }

        public string HouseTypeArea
        {
            get
            {
                return _houseTypeExpensesModel.HouseType.Area.ToString();
            }
            set
            {
                int housetypearea;

                if (int.TryParse(value, out housetypearea))
                {
                    _houseTypeExpensesModel.HouseType.Area = housetypearea;
                }
                else
                {
                    if (value != "")
                    {
                        MessageHandling.DisplayErrorMessage("Can only contain numbers");
                    }
                    else
                    {
                        _houseTypeExpensesModel.HouseType.Area = 0;
                    }
                }
            }

        }
        public string HouseTypeUnitPrice
        {
            get
            {
                return _houseTypeExpensesModel.HouseType.UnitPrice.ToString();
            }
        }



        public HouseTypeExpenseViewModel()
        {
            Name = "House Type";
        }

        public override IExpenseCategory ExpenseCategory
        {

            set
            {
                _houseTypeExpensesModel = (IHouseTypeExpenses)value;
                TechnicalSpecifications = _houseTypeExpensesModel.TechnicalSpecifications;
                ExtraExpenses = _houseTypeExpensesModel.ExtraExpenses;
            }
        }
    }
}
