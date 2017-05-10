using Comforthuse.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Comforthuse.Utility
{
    public class ValidateCustomer : Validator
    {
        public ICustomer CreateCustomer(string firstName, string lastName, string email, string city, string address, string zipcode, string phoneNb1, string phoneNb2)
        {
            ICustomer customer;
            if (firstName != "" && lastName != "" && email != "" && city != "" && address != "" && zipcode != "" && phoneNb1 != "" && phoneNb2 != "")
            {
                customer = CustomerRepository.Instance.Create(StandardizeName(firstName), StandardizeName(lastName), StandardizeEmail(email), StandardizeName(city), StandardizeAddress(address), StandardizeZipcode(zipcode), StandardizePhoneNb(phoneNb1), StandardizePhoneNb(phoneNb2));
            }
            else
            {
                throw new Exception("Not all the fields have input");
            }
            return customer;
        }

        public ICustomer Edit(string firstName, string lastName, string email, string city, string address, string zipcode, string phoneNb1, string phoneNb2, string old_email)
        {
            ICustomer customer = CustomerRepository.Instance.Load(StandardizeEmail(old_email));
            if (firstName != "" && lastName != "" && email != "" && city != "" && address != "" && zipcode != "" && phoneNb1 != "" && phoneNb2 != "")
            {
                string newFirstName = StandardizeName(firstName);
                string newLastName = StandardizeName(lastName);
                string newEmail = StandardizeEmail(email);
                string newCity = StandardizeName(city);
                string newAddress = StandardizeAddress(address);
                string newZipcode = StandardizeZipcode(zipcode);
                string newPhoneNr1 = StandardizePhoneNb(phoneNb1);
                string newPhoneNr2 = StandardizePhoneNb(phoneNb2);

                customer.FirstName = newFirstName;
                customer.LastName = newLastName;
                customer.Email = newEmail;
                customer.City = newCity;
                customer.Address = newAddress;
                customer.Zipcode = newZipcode;
                customer.PhoneNb1 = newPhoneNr1;
                customer.PhoneNb2 = newPhoneNr2;
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

            CheckForInvalidEmailCharacters(email);
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

        private string StandardizePhoneNb(string phoneNb)
        {
            string standardized = "";

            foreach (char c in phoneNb)
            {
                if (c != ' ')
                {
                    standardized += c;
                }
            }

            OnlyContainsNumbers(standardized);

            return standardized;
        }



        private void CheckForInvalidEmailCharacters(string email)
        {
            List<char> listOfInvalidCharacters = new List<char>() { '*', 'ç', ' ', '+', '!', '"', '#', '$', '%', '&', '/', '(', ')', '=', '?', '£', '§', '{', '[', ']', '}', '\'', '«', '»', '<', '>', ':', ',', ';', 'º','ª','á', 'é', 'ó', 'à', 'è', 'ò', 'ä', 'ë', 'ö', 'ü', 'â', 'ê', 'î','ô','û','ã','õ','\\','|' };

            foreach (char character in email.ToLower())
            {
                if (listOfInvalidCharacters.Contains(character) == true)
                {
                    throw new Exception("Invalid characters found");
                }
            }
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
