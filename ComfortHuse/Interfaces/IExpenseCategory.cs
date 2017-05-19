using Comforthuse.Models.SpecificationDerivatives;
using Comforthuse.Utility;
using System.Collections.Generic;
using Comforthuse.Interfaces;

namespace Comforthuse.Models
{
    public interface IExpenseCategory
    {
        Category Category { get; }
        decimal Price { get; }
        List<ITechnicalSpecification> TechnicalSpecifications { get; set; }
        List<IExtraExpenseSpecification> ExtraExpenses { get; set; }
    }
}
