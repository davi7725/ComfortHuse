using EmployeeGUI.Helpers;
using SimpleMVVMExample;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class BaseExpenseViewModel : ObservableObject, IPageViewModel
    {
        public string Name { get; protected set; }

        public virtual double Price { get; protected set; }
    }
}
