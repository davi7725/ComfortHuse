using System;
using Comforthuse.Models;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class TilesExpenseViewModel : BaseExpenseViewModel
    {
        public TilesExpenseViewModel()
        {
            Name = "Tiles";
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
