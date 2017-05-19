using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comforthuse.Models;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class OtherExpenseViewModel : BaseExpenseViewModel
    {
        public override IExpenseCategory ExpenseCategory
        {
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}