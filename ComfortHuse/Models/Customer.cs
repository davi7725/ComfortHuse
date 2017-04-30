namespace Comforthuse.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNr1 { get; set; }
        public string PhoneNr2 { get; set; }
        public string PhoneNr3 { get; set; }
        public string PhoneNr4 { get; set; }

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
            PhoneNr3 = phoneNr3;
            PhoneNr4 = phoneNr4;
        }
    }
}
