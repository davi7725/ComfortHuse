using Comforthuse.Models;
using System.Collections.Generic;
using Comforthuse.Database;

namespace Comforthuse.Utility
{
    public class ProductOptionRepository
    {

        private static ProductOptionRepository _instance;

        private Dictionary<int, ProductOption> listOfProductOptions = new Dictionary<int, ProductOption>();

        public Dictionary<int,ProductOption> GetProductOptions()
        {
            if(listOfProductOptions.Count == 0)
            {
                listOfProductOptions = DatabaseController.Instance.GetAllProductOptions();
            }

            return listOfProductOptions;
        }

        public static ProductOptionRepository Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ProductOptionRepository();
                }
                return _instance;
            }
        }

        private ProductOptionRepository()
        {

        }

    }
}
