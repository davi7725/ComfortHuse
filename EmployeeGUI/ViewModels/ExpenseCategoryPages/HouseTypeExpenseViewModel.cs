using Comforthuse.Interfaces;
using Comforthuse.Models;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class HouseTypeExpenseViewModel : BaseExpenseViewModel
    {

        private IHouseTypeExpenses _houseTypeExpensesModel;

        public string HouseTypeDescription {
            get
            {
                return _houseTypeExpensesModel.HouseType.Description;
            }
        }

        public string HouseTypeName
        {
            get
            {
                return _houseTypeExpensesModel.HouseType.Name;
            }
        }

        public string HouseTypeTotalPrice
        {
            get
            {
                return _houseTypeExpensesModel.HouseType.TotalPrice.ToString();
            }
        }

        public string HouseTypeArea
        {
            get
            {
                return _houseTypeExpensesModel.HouseType.Area.ToString();
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
        
        public IHouseTypeExpenses HouseTypeExpensesModel
        {
            set
            {
                _houseTypeExpensesModel = value;
            }
        }
    }
}
