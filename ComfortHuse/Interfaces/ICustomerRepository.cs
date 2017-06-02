using Comforthuse.Models;
using System.Collections.Generic;

namespace Comforthuse.Interfaces
{
    public interface ICustomerRepository
    {
        void Clear();
        List<ICustomer> Search(string query);
        ICustomer Load(string phoneNb);
        ICustomer Create(string firstName, string lastName, string email, string city, string address, string zipcode, string phoneNb1, string phoneNb2);
        void Save(ICustomer customer);
    }
}
