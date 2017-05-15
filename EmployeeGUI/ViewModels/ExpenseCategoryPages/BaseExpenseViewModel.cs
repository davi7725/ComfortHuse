using Comforthuse.Models;
using Comforthuse.Models.SpecificationDerivatives;
using Comforthuse.Utility;
using EmployeeGUI.Helpers;
using SimpleMVVMExample;
using System.Collections.Generic;
using Comforthuse.Interfaces;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public abstract class BaseExpenseViewModel : ObservableObject, IPageViewModel
    {
        public virtual ProductCategory Category { get; }

        public virtual string Name { get; protected set; }

        public virtual List<IExtraExpenseSpecification> ExtraExpenses { get; set; }

        public virtual List<ITechnicalSpecification> TechnicalSpecifications { get; set; }

        public virtual decimal Price { get; }
    }
}
