using System;
using Comforthuse.Models;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class ExtraContructionViewModel : BaseExpenseViewModel
    {
        public ExtraContructionViewModel()
        {
            Name = "Extra Contruction";
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

