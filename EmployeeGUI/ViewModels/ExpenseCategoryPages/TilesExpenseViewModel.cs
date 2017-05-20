using Comforthuse.Models;
using System;

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
