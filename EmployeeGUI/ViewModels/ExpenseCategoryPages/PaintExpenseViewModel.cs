using System;
using Comforthuse.Models;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class PaintExpenseViewModel : BaseExpenseViewModel
    {
        public PaintExpenseViewModel()
        {
            Name = "Paint";
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
