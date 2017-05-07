using Comforthuse.Models;
using SimpleMVVMExample;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class HouseTypeViewModel : IPageViewModel
    {

        private string _name = "";
        public HouseTypeViewModel(IExpenseCategory expenseCategory)
        {
            // if(expenseCategory.Category == 0) 

        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

    }
}
