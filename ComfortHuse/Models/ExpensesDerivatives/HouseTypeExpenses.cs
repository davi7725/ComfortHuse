using Comforthuse.Interfaces;

namespace Comforthuse.Utility
{
    public class HouseTypeExpenses : Expenses, IHouseTypeExpenses
    {
        public override decimal Price { get; }
        public HouseTypeExpenses HouseType { get; set; }
        public bool HouseExpansion { get; set; }
    }

}