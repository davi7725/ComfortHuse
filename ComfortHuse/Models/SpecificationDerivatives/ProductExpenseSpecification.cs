using Comforthuse.Utility;

namespace Comforthuse.Models.SpecificationDerivatives
{
    public interface IProductExpenseSpecification
    {

    }
    public class ProductExpenseSpecification : Specification, IProductExpenseSpecification
    {
        private decimal _price;
        private decimal _specialprice;

        public ProductExpenseSpecification(int productExpenseSpecificationId, int productOptionId, int productTypeId)
        {
            ProductExpenseSpecificationId = productExpenseSpecificationId;
            ProductOptionId = productOptionId;
            ProductTypeId = productTypeId;
        }

        public string Description { get; set; }

        public decimal Price
        {
            get
            {
                if (_specialprice == 0)
                {
                    return _price;
                }
                return _specialprice;
            }
        }
        public int ProductExpenseSpecificationId { get; }
        public int ProductTypeId { get; }
        public int ProductOptionId { get; private set; }
        public int Amount { get; set; }
        public decimal SpecialPrice
        {
            get { return _specialprice; }
            set { _specialprice = value; }
        }


        public void UpdatePrice(string location)
        {
            if (_specialprice != 0)
            {
                ProductOption productType = ProductOptionRepository.Instance.GetProductOption(ProductTypeId);
                if (productType != null)
                {
                    switch (location)
                    {
                        case "Fyn":
                            _price = productType.PriceFyn * Amount;
                            break;

                        case "Sjaelland":
                            _price = productType.PriceSjaelland * Amount;
                            break;
                    }

                }
            }
        }

    }
}


