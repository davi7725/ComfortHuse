using System;
using Comforthuse.Models;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class FloorExpenseViewModel : BaseExpenseViewModel
    {
        public FloorExpenseViewModel()
        {
            Name = "Floors";
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
