using Comforthuse.Database;
using System;
using System.Collections.Generic;

namespace Comforthuse.Models
{
    public interface ICustomerRepository
    {
        void Clear();
        List<ICustomer> GetAllCustomersByName();
        List<ICustomer> Search(string query);
        ICustomer Load(string phoneNb);
        ICustomer Create(string firstName, string lastName, string email, string city, string address, string zipcode, string phoneNb1, string phoneNb2);
        void Save(ICustomer customer);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private IDbEmployee _dbController = DatabaseController.Instance;
        private static ICustomerRepository _instance = null;
        private Dictionary<string, ICustomer> listOfCustomers;

        private CustomerRepository()
        {
            listOfCustomers = new Dictionary<string, ICustomer>();
        }

        public static ICustomerRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomerRepository();
                }
                return _instance;
            }
        }


        public void Clear()
        {
            listOfCustomers.Clear();
        }
        public ICustomer Create(string firstName, string lastName, string email, string city, string address, string zipcode, string phoneNb1, string phoneNb2)
        {
            ICustomer newCustomer = new Customer(firstName, lastName, email, city, address, zipcode, phoneNb1, phoneNb2);
            listOfCustomers.Add(email, newCustomer);

            return newCustomer;
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

        public ICustomer Load(string email)
        {
            if (listOfCustomers.ContainsKey(email) == true)
            {
                return listOfCustomers[email];
            }
            else
            {
                throw new Exception("Customer with this email does not exist");
            }
        }

        public void Save(ICustomer customer)
        {
            throw new System.NotImplementedException();
        }

    }
}
