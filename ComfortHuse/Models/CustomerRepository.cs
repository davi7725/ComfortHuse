﻿using Comforthuse.Database;
using System;
using System.Collections.Generic;

namespace Comforthuse.Models
{
    public interface ICustomerRepository
    {
        void Clear();
        List<ICustomer> GetAllCustomersByName();
        List<ICustomer> Search(string query);
        ICustomer Load(string phoneNr);
        ICustomer Create(string firstName, string lastName, string city, string address, string zipcode, string phoneNr1, string phoneNr2);
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
        public ICustomer Create(string firstName, string lastName, string city, string address, string zipcode, string phoneNr1, string phoneNr2)
        {
            ICustomer newCustomer = new Customer(firstName, lastName, city, address, zipcode, phoneNr1, phoneNr2);
            listOfCustomers.Add(phoneNr1, newCustomer);

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

        public ICustomer Load(string phoneNr)
        {
            if(listOfCustomers.ContainsKey(phoneNr) == true)
            {
                return listOfCustomers[phoneNr];
            }
            else
            {
                throw new Exception("Customer with this phone number does not exist");
            }
        }

        public void Save(ICustomer customer)
        {
            throw new System.NotImplementedException();
        }

    }
}
