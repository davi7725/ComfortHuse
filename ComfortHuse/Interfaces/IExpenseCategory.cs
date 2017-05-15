using Comforthuse.Models.SpecificationDerivatives;
using Comforthuse.Utility;
using System.Collections.Generic;

namespace Comforthuse.Models
{
    public interface IExpenseCategory
    {
        ProductCategory Category { get; }
        decimal Price { get; }
        List<ITechnicalSpecification> TechnicalSpecifications { get; set; }
        List<IExtraExpenseSpecification> ExtraExpenses { get; set; }
    }
}
