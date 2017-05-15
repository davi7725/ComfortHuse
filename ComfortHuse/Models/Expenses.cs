using Comforthuse.Models;
using Comforthuse.Models.SpecificationDerivatives;
using Comforthuse.Interfaces;
using System.Collections.Generic;

namespace Comforthuse.Utility
{


    public interface IExpenseSpecification
    {
    }

    public abstract class Expenses : IExpenseCategory
    {
        public abstract decimal Price { get;}
        public ProductCategory Category { get; }

        public List<IExtraExpenseSpecification> ExtraExpenses
        {
            get { return _extras; }
            set { _extras = value; }
        }

        public List<ITechnicalSpecification> TechnicalSpecifications { get; set; }

        public decimal PriceExtraExpenses
        {
            get
            {
                decimal price = 0;
                foreach (IExtraExpenseSpecification exp in _extras)
                {
                    price += exp.TotalPrice;
                }
                return price;
            }
        }

        protected List<IExtraExpenseSpecification> _extras;

        protected List<ITechnicalSpecification> _tecnSpecifications;
    }
}