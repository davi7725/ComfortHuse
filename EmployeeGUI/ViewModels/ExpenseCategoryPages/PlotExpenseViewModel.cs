using System;
using Comforthuse.Models;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class PlotExpenseViewModel : BaseExpenseViewModel
    {
        public PlotExpenseViewModel()
        {
            Name = "Plot";
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
