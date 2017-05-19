namespace Comforthuse.Models
{
    public class ProductOption
    {
        public ProductOption(int productOptionId, string name, decimal priceF, decimal priceS, string unit, bool isStandard, int productType)
        {
            ProductId = productOptionId;
            Name = name;
            PriceFyn = priceF;
            PriceSjaelland = priceS;
            UnitType = unit;
            Standard = isStandard;
            ProductType = productType;
            //ProductType = ProductTypeRepository.Instance.Load(productType);
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal PriceFyn { get; set; }
        public decimal PriceSjaelland { get; set; }
        public string UnitType { get; set; }
        public bool Standard { get; set; }
        public int ProductType { get; set; }

    }
}
