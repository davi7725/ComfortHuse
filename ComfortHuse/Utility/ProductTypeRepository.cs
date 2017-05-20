using Comforthuse.Models;
using System.Collections.Generic;
using Comforthuse.Database;
using System;

namespace Comforthuse.Utility
{
    public class ProductTypeRepository
    {

        private static ProductTypeRepository _instance;
        Dictionary<int, ProductType> listOfProductTypes = new Dictionary<int, ProductType>();

        public Dictionary<int, ProductType> GetProductTypes()
        {
            if (listOfProductTypes.Count == 0)
            {
                listOfProductTypes = DatabaseController.Instance.GetAllProductTypes();
            }

            return listOfProductTypes;
        }

        public ProductType Load(int productTypeId)
        {
            return listOfProductTypes[productTypeId];
        }

        public List<ProductType> Load(Category category)
        {
            List<ProductType> listOfProductTypesFromCategory = new List<ProductType>();

            foreach(ProductType pt in listOfProductTypes.Values)
            {
                if (pt.Category == category)
                {
                    listOfProductTypesFromCategory.Add(pt);
                    pt.GetListOfProductOptions();
                }
            }
            return listOfProductTypesFromCategory;
        }

        public static ProductTypeRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProductTypeRepository();
                }
                return _instance;
            }
        }

        private ProductTypeRepository()
        {

        }
    }
}
