using Comforthuse.Interfaces;
using Comforthuse.Utility;

namespace Comforthuse.Models
{
    public class ProductOption : IProductOption
    {

        public ProductOption(int productOptionId, string name, decimal priceF, decimal priceS, string unit, bool isStandard, int productType)
        {
            ProductId = productOptionId;
            Name = name;
            PriceFyn = priceF;
            PriceSjaelland = priceS;
            UnitType = unit;
            Standard = isStandard;
            ProductType = ProductTypeRepository.Instance.Load(productType);
            Selected = false;
        }

        private decimal _specialPrice = 0;

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal PriceFyn { get; set; }
        public decimal PriceSjaelland { get; set; }
        public string UnitType { get; set; }
        public bool Standard { get; set; }
        public IProductType ProductType { get; set; }
        public bool Selected { get; set; }
        public bool Special { get; set; }
        public decimal SpecialPrice
        {
            get
            {
                return _specialPrice;
            }
            set
            {
                if (value > 0)
                {
                    Special = true;
                    _specialPrice = value;
                }
                else
                {
                    Special = false;
                }
            }
        }
        public int Amount { get; set; }
    }
}
