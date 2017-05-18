using EmployeeGUI.Helpers;

namespace Comforthuse.Models
{
    public interface ICustomer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string City { get; set; }
        string Address { get; set; }
        string Zipcode { get; set; }
        string PhoneNb1 { get; set; }
        string PhoneNb2 { get; set; }
    }

    public class Customer : ObservableObject, ICustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNb1 { get; set; }
        public string PhoneNb2 { get; set; }

        public Customer()
        {

        }
        public Customer(string firstName, string lastName, string email, string city, string address, string zipcode, string phoneNb1, string phoneNb2)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            City = city;
            Address = address;
            Zipcode = zipcode;
            PhoneNb1 = phoneNb1;
            PhoneNb2 = phoneNb2;
        }
    }
}
