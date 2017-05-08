namespace Comforthuse
{
    public class Employee : IEmployee
    {
        public Employee(string firstName, string lastName, string email, string phoneNb)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = PhoneNumber;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
    }
}
