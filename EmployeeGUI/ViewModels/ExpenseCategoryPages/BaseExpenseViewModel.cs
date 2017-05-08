using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeGUI.Helpers;
using SimpleMVVMExample;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class BaseExpenseViewModel : ObservableObject, IPageViewModel
    {
        public string Name { get; protected set; }
    }
}
