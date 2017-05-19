using System;
using Comforthuse.Models;
using Comforthuse.Utility;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class MaterialsOutsideExpenseViewModel : BaseExpenseViewModel
    {
        private IMaterialOutsideExpenses _materialOutsideExpenses;
        public MaterialsOutsideExpenseViewModel()
        {
            Name = "Materials Outside";
        }

        public override IExpenseCategory ExpenseCategory
        {
            set
            {
                _materialOutsideExpenses = (IMaterialOutsideExpenses)value;
            }
        }
    }
}
