namespace Comforthuse.Models
{
    public class ProductOption
    {
        public ProductType Product { get; }
        public int ProductNumber { get; set; }
        public bool Standard { get; set; }
        public string Description { get; set; }
        public double PriceFyn { get; set; }
        public int UnitType { get; set; }
        public double PriceSjaelland { get; set; }

    }
}
