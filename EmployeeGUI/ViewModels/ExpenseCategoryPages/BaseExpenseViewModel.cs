using Comforthuse.Models;
using Comforthuse.Utility;
using EmployeeGUI.Helpers;
using SimpleMVVMExample;
using System.Collections.Generic;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public abstract class BaseExpenseViewModel : ObservableObject, IPageViewModel
    {
        public virtual ProductCategory Category { get; }

        public virtual string Name { get; protected set; }

        public virtual List<IExpenseSpecification> ExtraExpenses { get; }

        public virtual List<ITechnicalSpecification> TechnicalSpecifications { get; set; }

        public virtual decimal Price { get; }
    }
}
