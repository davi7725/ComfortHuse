using System;
using Comforthuse.Models;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class PowerExpenseViewModel : BaseExpenseViewModel
    {
        public PowerExpenseViewModel()
        {
            Name = "Power";
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
