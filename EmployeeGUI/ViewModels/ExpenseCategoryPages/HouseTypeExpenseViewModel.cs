using Comforthuse.Interfaces;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class HouseTypeExpenseViewModel : BaseExpenseViewModel
    {

        private IHouseTypeExpenses _houseTypeExpensesModel;

        public HouseTypeExpenseViewModel()
        {
            Name = "House Type";
        }

        public IHouseTypeExpenses HouseTypeExpenses
        {
            set { _houseTypeExpensesModel = value; }
        }
    }
}
