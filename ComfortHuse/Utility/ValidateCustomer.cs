using Comforthuse.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Comforthuse.Utility
{
    public class ValidateCustomer : Validator
    {
        public ICustomer CreateCustomer(string firstName, string lastName, string email, string city, string address, string zipcode, string phoneNr1, string phoneNr2)
        {
            ICustomer customer;
            if (firstName != "" && lastName != "" && email != "" && city != "" && address != "" && zipcode != "" && phoneNr1 != "" && phoneNr2 != "")
            {
                customer = CustomerRepository.Instance.Create(StandardizeName(firstName), StandardizeName(lastName), StandardizeEmail(email), StandardizeName(city), StandardizeAddress(address), StandardizeZipcode(zipcode), StandardizePhoneNr(phoneNr1), StandardizePhoneNr(phoneNr2));
            }
            else
            {
                throw new Exception("Not all the fields have input");
            }
            return customer;
        }

        public ICustomer Edit(string firstName, string lastName, string email, string city, string address, string zipcode, string phoneNr1, string phoneNr2, string old_PhoneNr)
        {
            ICustomer customer = CustomerRepository.Instance.Load(StandardizeEmail(email));
            if (firstName != "" && lastName != "" && email != "" && city != "" && address != "" && zipcode != "" && phoneNr1 != "" && phoneNr2 != "")
            {
                string newFirstName = StandardizeName(firstName);
                string newLastName = StandardizeName(lastName);
                string newEmail = StandardizeEmail(email);
                string newCity = StandardizeName(city);
                string newAddress = StandardizeAddress(address);
                string newZipcode = StandardizeZipcode(zipcode);
                string newPhoneNr1 = StandardizePhoneNr(phoneNr1);
                string newPhoneNr2 = StandardizePhoneNr(phoneNr2);

                customer.FirstName = newFirstName;
                customer.LastName = newLastName;
                customer.Email = newEmail;
                customer.City = newCity;
                customer.Address = newAddress;
                customer.Zipcode = newZipcode;
                customer.PhoneNr1 = newPhoneNr1;
                customer.PhoneNr2 = newPhoneNr2;
            }
            else
            {
                throw new Exception("Not all the fields have input");
            }
            return customer;
        }

        private string StandardizeAddress(string address)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(address.ToLower());
        }

        private string StandardizeEmail(string email)
        {
            return email.ToLower();
        }

        private string StandardizeName(string name)
        {
            string properName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
            OnlyContainsValidNameCharacters(properName);
            return properName;
        }

        private string StandardizeZipcode(string zipcode)
        {
            return zipcode.ToUpper();
        }

        private string StandardizePhoneNr(string phoneNr)
        {
            string standardized = "";

            foreach (char c in phoneNr)
            {
                if (c != ' ')
                {
                    standardized += c;
                }
            }

            OnlyContainsNumbers(standardized);

            return standardized;
        }

        private void OnlyContainsNumbers(string numbers)
        {
            List<char> listOfNumbers = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

            foreach (char digit in numbers)
            {
                if (listOfNumbers.Contains(digit) == false)
                {
                    throw new Exception("Does not contain only numbers");
                }
            }
        }

        private void OnlyContainsValidNameCharacters(string name)
        {
            List<char> listOfAcceptedCharacters = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'æ', 'ø', 'å', ' ' };

            foreach (char character in name.ToLower())
            {
                if (listOfAcceptedCharacters.Contains(character) == false)
                {
                    throw new Exception("Invalid characters found");
                }
            }
        }

    }
}
