using Comforthuse.Models;
using System;
using System.Globalization;

namespace Comforthuse.Utility
{
    public class ValidateCustomer: Validator
    {
        public Customer CreateCustomer(string firstName, string lastName, string city, string address, string zipcode, string phoneNr1, string phoneNr2, string phoneNr3, string phoneNr4)
        {
            Customer customer;
            if (firstName != "" && lastName != "" && city != "" && address != "" && zipcode != "" && phoneNr1 != "" && phoneNr2 != "" && phoneNr3 != "" && phoneNr4 != "")
            {
               customer = new Customer(StandardizeName(firstName), StandardizeName(lastName), StandardizeName(city), StandardizeName(address), StandardizeZipcode(zipcode), StandardizePhoneNr(phoneNr1), StandardizePhoneNr(phoneNr2), StandardizePhoneNr(phoneNr3), StandardizePhoneNr(phoneNr4));
            }
            else
            {
                throw new Exception("Not all the fields have input");
            }
            return customer;
        }

        private string StandardizeName(string name)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
        }

        private string StandardizeZipcode(string zipcode)
        {
            return zipcode.ToUpper();
        }

        private string StandardizePhoneNr(string phoneNr)
        {
            string standardized = "";

            foreach(char c in phoneNr)
            {
                if(c != ' ')
                {
                    standardized += c;
                }
            }

            return standardized;
        }

    }
}
