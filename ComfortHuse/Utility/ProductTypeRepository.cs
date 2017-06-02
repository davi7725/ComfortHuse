using Comforthuse.Database;
using Comforthuse.Models;
using System.Collections.Generic;

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

        public ProductType GetProductType(int productTypeId)
        {
            return listOfProductTypes[productTypeId];
        }

        public List<IProductType> Load(Category category)
        {
            List<IProductType> listOfProductTypesFromCategory = new List<IProductType>();

            foreach (ProductType pt in listOfProductTypes.Values)
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
