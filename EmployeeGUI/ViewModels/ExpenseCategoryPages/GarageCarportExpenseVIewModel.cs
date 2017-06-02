using Comforthuse.Models;
using Comforthuse.Utility;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class GarageCarportExpenseViewModel : BaseExpenseViewModel
    {
        private ICarportGarageExpenses _carportGarageExpenses;
        public GarageCarportExpenseViewModel()
        {
            Name = "Garage Type";
        }


        public override IExpenseCategory ExpenseCategory
        {
            set
            {
                _carportGarageExpenses = (ICarportGarageExpenses)value;
                TechnicalSpecifications = _carportGarageExpenses.TechnicalSpecifications;
                ExtraExpenses = _carportGarageExpenses.ExtraExpenses;
                ProductTypes = _carportGarageExpenses.ProductTypes;
            }
        }


    }
}
