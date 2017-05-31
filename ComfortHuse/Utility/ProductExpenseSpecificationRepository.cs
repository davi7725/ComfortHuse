using Comforthuse.Models.SpecificationDerivatives;
using System;

namespace Comforthuse.Utility
{
    public class ProductExpenseSpecificationRepository
    {

        private static ProductExpenseSpecificationRepository _instance;

        private ProductExpenseSpecificationRepository() { }

        public ProductExpenseSpecification Load(int productTypeId, int caseNumber)
        {
            return null;
        }


        public ProductExpenseSpecification Load()
        {
            throw new NotImplementedException();
        }

        public static ProductExpenseSpecificationRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProductExpenseSpecificationRepository();
                }
                return _instance;
            }
        }


    }
}
