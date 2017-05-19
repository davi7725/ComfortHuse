using System;
using Comforthuse.Models;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class MaterialInsideExpenseViewModel : BaseExpenseViewModel
    {
        public MaterialInsideExpenseViewModel()
        {
            Name = "Material Inside";
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
