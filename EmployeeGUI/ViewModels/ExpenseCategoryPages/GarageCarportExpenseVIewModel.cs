using System;
using Comforthuse.Models;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class GarageCarportExpenseViewModel : BaseExpenseViewModel
    {
        public GarageCarportExpenseViewModel()
        {
            Name = "Garage Type";
        }

        public override IExpenseCategory ExpenseCategory
        {
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
