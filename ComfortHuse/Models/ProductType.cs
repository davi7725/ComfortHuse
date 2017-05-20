using Comforthuse.Utility;
using System;
using System.Collections.Generic;

namespace Comforthuse.Models
{
    public class ProductType
    {
        private List<ProductOption> _listOfProductOption;

        public ProductType(int productTypeId, string name, string productCategoryName)
        {
            ProductTypeId = productTypeId;
            Name = name;
            Category = (Category)Enum.Parse(typeof(Category), productCategoryName);
            _listOfProductOption = new List<ProductOption>();
        }

        public int ProductTypeId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public List<ProductOption> ListOfProductOption
        {
            get
            {
                return _listOfProductOption;
            }
        }


        public List<ProductOption> GetListOfProductOptions()
        {
            Dictionary<int,ProductOption> listOfProductOptions = ProductOptionRepository.Instance.GetProductOptions();

            foreach(ProductOption po in listOfProductOptions.Values)
            {
                if (po.ProductType.Equals(this))
                {
                    _listOfProductOption.Add(po);
                }
            }

            return _listOfProductOption;
        }

        public override bool Equals(object obj)
        {
            bool areEqual = false;
            ProductType po = (ProductType)obj;

            if (ProductTypeId == po.ProductTypeId)
            {
                areEqual = true;
            }

            return areEqual;
        }
    }

}




