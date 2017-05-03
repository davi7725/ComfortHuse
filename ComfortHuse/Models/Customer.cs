namespace Comforthuse.Models
{
    public interface ICustomer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string City { get; set; }
        string Address { get; set; }
        string Zipcode { get; set; }
        string PhoneNr1 { get; set; }
        string PhoneNr2 { get; set; }
    }

    public class Customer : ICustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNr1 { get; set; }
        public string PhoneNr2 { get; set; }

        public Customer()
        {

        }
        public Customer(string firstName, string lastName, string city, string address, string zipcode, string phoneNr1, string phoneNr2, string phoneNr3, string phoneNr4)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Address = address;
            Zipcode = zipcode;
            PhoneNr1 = phoneNr1;
            PhoneNr2 = phoneNr2;
        }
    }
}
