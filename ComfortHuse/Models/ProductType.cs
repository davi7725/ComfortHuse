using Comforthuse.Interfaces;
using Comforthuse.Utility;
using System;
using System.Collections.Generic;

namespace Comforthuse.Models
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class ProductType : IProductType
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        private List<IProductOption> _listOfProductOptions;

        public ProductType(int productTypeId, string name, string productCategoryName)
        {
            ProductTypeId = productTypeId;
            Name = name;
            Category = (Category)Enum.Parse(typeof(Category), productCategoryName);
            _listOfProductOptions = new List<IProductOption>();
        }

        public int ProductTypeId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public List<IProductOption> ListOfProductOptions
        {
            get
            {
                return _listOfProductOptions;
            }
            set { _listOfProductOptions = value; }
        }


        public List<IProductOption> GetListOfProductOptions()
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




