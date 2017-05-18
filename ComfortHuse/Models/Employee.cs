﻿namespace Comforthuse
{
    public class Employee : IEmployee
    {
        public string FirstName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"[FirstName={FirstName},LastName={LastName},PhoneNumber={PhoneNumber},Email={Email}]";
        }

        public override bool Equals(object obj)
        {
            bool areEqual = false;
            Employee otherEmployee = (Employee)obj;
            if (otherEmployee.FirstName == this.FirstName && otherEmployee.LastName == this.LastName && otherEmployee.Email == this.Email)
            {
                areEqual = true;
            }

            return areEqual;
        }

        public Employee(string firstName, string lastName, string email, string phoneNb)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNb;
        }
    }
}
