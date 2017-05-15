using Comforthuse.Interfaces;
using Comforthuse.Models;

namespace Comforthuse.Utility
{
    public class HouseTypeExpenses : Expenses, IHouseTypeExpenses
    {
        public override decimal Price { get
            {
                return HouseType.TotalPrice + this.PriceExtraExpenses;
            }
        }
        public HouseType HouseType { get; set; }
        public bool HouseExpansion { get; set; }
    }

}