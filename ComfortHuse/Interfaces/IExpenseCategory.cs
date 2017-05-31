using Comforthuse.Interfaces;
using System.Collections.Generic;

namespace Comforthuse.Models
{
    public interface IExpenseCategory
    {
        Category Category { get; }
        decimal Price { get; }
        List<ITechnicalSpecification> TechnicalSpecifications { get; set; }
        List<IProductType> ProductTypes { get; set; }
        List<IExtraExpenseSpecification> ExtraExpenses { get; set; }
    }

}
