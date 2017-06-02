using Comforthuse.Interfaces;
using Comforthuse.Models;
using System.Collections.Generic;

namespace Comforthuse.Utility
{
    public abstract class Expenses : IExpenseCategory
    {
        public abstract decimal Price { get; }
        public Category Category { get; }

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
        public List<IProductOption> ProductOptions { get; set; }

        public List<IProductType> ProductTypes
        {
            get; set;
        }
    }
}