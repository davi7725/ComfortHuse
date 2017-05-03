using Comforthuse.Database;
using System;
using System.Collections.Generic;

namespace Comforthuse.Models
{
    public interface ICustomerRepository
    {
        List<ICustomer> GetAllCustomersByName();
        List<ICustomer> Search(string query);
        ICustomer Load(int id);
        void Save(ICustomer customer);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private IDbEmployee _dbController = DatabaseController.Instance;
        private static ICustomerRepository _instance = null;

        private CustomerRepository() { }

        public static ICustomerRepository Instance
        {
            get
            {
                if (_instance == null) _instance = new CustomerRepository();
                return _instance;
            }
        }

        public List<ICustomer> GetAllCustomersByName()
        {
            return _dbController.GetAllCustomersByName();
        }

        public List<ICustomer> Search(string query)
        {
            // Define search algorithm
            // Narrow down search
            throw new NotImplementedException();
        }

        public ICustomer Load(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(ICustomer customer)
        {
            throw new System.NotImplementedException();
        }

    }
}
