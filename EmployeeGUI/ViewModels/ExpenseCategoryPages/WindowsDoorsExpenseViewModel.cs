using System;
using Comforthuse.Models;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class WindowsDoorsExpenseViewModel : BaseExpenseViewModel
    {
        public WindowsDoorsExpenseViewModel()
        {
            Name = "Windows and doors";
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
