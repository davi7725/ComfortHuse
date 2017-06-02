using Comforthuse.Utility;
using System;
using System.Collections.Generic;

namespace Comforthuse.Models
{
    public class ProductType
    {

        public ProductType(int productTypeId, string name, string productCategoryName)
        {
            ProductTypeId = productTypeId;
            Name = name;
            Category = (Category)Enum.Parse(typeof(Category), productCategoryName);
            _listOfProductOptions = new List<ProductOption>();
        }

        private List<ProductOption> _listOfProductOptions;

        public int ProductTypeId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public List<ProductOption> ListOfProductOptions
        {
            get
            {
                return _listOfProductOptions;
            }
        }


        public List<ProductOption> GetListOfProductOptions()
        {
            _listOfProductOptions.Clear();
            Dictionary<int, ProductOption> listOfProductOptions = ProductOptionRepository.Instance.GetProductOptions();
            
            foreach (ProductOption po in listOfProductOptions.Values)
            {
                if (po.ProductType.Equals(this))
                {
                    _listOfProductOptions.Add(po);
                }
            }
            return _listOfProductOptions;
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




