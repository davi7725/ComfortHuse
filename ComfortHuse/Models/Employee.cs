using Comforthuse.Interfaces;

namespace Comforthuse.Models
{
    public class Employee : IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Employee(string firstName, string lastName, string email, string phoneNb)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = PhoneNumber;
        }
    }
}
