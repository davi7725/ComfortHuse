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

        protected List<IExtraExpenseSpecification> _extras;

        protected List<ITechnicalSpecification> _tecnSpecifications;

        public abstract decimal Price { get;}
        public Category Category { get; }

        public List<IExtraExpenseSpecification> ExtraExpenses
        {
            get { return _extras; }
            set { _extras = value; }
        }

        public List<ITechnicalSpecification> TechnicalSpecifications { get; set; }

        public List<ProductType> ListOfProductTypes { get; set; }

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
    }
}