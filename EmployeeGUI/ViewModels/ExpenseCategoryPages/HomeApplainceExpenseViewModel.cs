using System;
using Comforthuse.Models;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class HomeApplianceExpenseViewModel : BaseExpenseViewModel
    {
        public HomeApplianceExpenseViewModel()
        {
            Name = "Home Appliances";
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
