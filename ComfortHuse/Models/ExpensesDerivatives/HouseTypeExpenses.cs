using Comforthuse.Interfaces;
using Comforthuse.Models;

namespace Comforthuse.Utility
{
    public class HouseTypeExpenses : Expenses, IHouseTypeExpenses
    {
        public override decimal Price { get
            {
                if(HouseType.TotalPrice == null)
                {
                    return this.PriceExtraExpenses;
                }
                else
                return (decimal)HouseType.TotalPrice + this.PriceExtraExpenses;
            }
        }
        public IHouseType HouseType { get; set; }
        public bool HouseExpansion { get; set; }
       
    }

}