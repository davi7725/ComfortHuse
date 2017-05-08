using Comforthuse.Models;
using System.Collections.Generic;

namespace Comforthuse.Utility
{


    public interface IExpenseSpecification
    {
    }

    public abstract class Expenses : IExpenseCategory
    {
        public abstract decimal Price { get; }
        public ProductCategory Category { get; }

        public List<IExpenseSpecification> ExtraExpenses
        {
            get { return _extras; }
        }

        public List<ITechnicalSpecification> TechnicalSpecifications { get; internal set; }

        protected decimal PriceExtraExpenses
        {
            get
            {
                decimal price = 0;
                foreach (ExpenseSpecification exp in _extras)
                {
                    price += exp.Price;
                }
                return price;
            }
        }

        protected List<IExpenseSpecification> _extras = new List<IExpenseSpecification>();

        protected List<ITechnicalSpecification> _tecnSpecifications = new List<ITechnicalSpecification>();
    }
}