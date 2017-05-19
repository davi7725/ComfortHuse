using Comforthuse.Models;
using System.Collections.Generic;
using Comforthuse.Database;

namespace Comforthuse.Utility
{
    public class ProductOptionRepository
    {
        private Dictionary<int, ProductOption> listOfProductOptions = new Dictionary<int, ProductOption>();

        public Dictionary<int,ProductOption> GetProductOptions()
        {
            if(listOfProductOptions.Count == 0)
            {
                listOfProductOptions = DatabaseController.Instance.GetAllProductOptions();
            }

            return listOfProductOptions;
        }
    }
}
