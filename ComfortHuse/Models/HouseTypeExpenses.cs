using System.Collections.Generic;

namespace Comforthuse.Models
{
    public class HouseTypeExpenses : IExpenseCategory
    {
        public float Price { get; set; }
        public HouseTypeExpenses HouseType { get; set; }
        public bool HouseExpansion { get; set; }

        private List<ExpenseSpecification> _extras = new List<ExpenseSpecification>();
        private List<TechnicalSpecification> _tecnSpecifications = new List<TechnicalSpecification>();
        public ProductCategory Category { get; set; }
    }
}