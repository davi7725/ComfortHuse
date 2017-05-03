namespace Comforthuse.Models
{
    public class ProductOption
    {
        public ProductType Product { get; }
        public int Varenumber { get; set; }
        public bool Standard { get; set; }
        public string Description { get; set; }
        public string PriceFyn { get; set; }
        public string UnitType { get; set; }
        public string PriceSjaelland { get; set; }

    }
}
