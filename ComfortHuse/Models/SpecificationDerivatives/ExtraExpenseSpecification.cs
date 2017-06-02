using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comforthuse.Interfaces;

namespace Comforthuse.Models.SpecificationDerivatives
{
    public class ExtraExpenseSpecification : Specification, IExtraExpenseSpecification
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public decimal PricePerUnit { get; set; }

        public decimal TotalPrice => Amount * PricePerUnit;
    }
}
