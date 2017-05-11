using Comforthuse.Models;
using Comforthuse.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ComforthuseUserstoryTests
{
    [TestClass]
    public class U02_Tests
    {
        [TestInitialize]
        public void CleanRepository()
        {
            CustomerRepository.Instance.Clear();
        }
        [TestMethod]
        public void ShouldEditAllTheInformationCorrectly()
        {
            string old_fName = "Jon";
            string old_lName = "Doe";
            string old_email = "abc@dce.com";
            string old_city = "Odense";
            string old_address = "City Center, 10";
            string old_zipcode = "5200";
            string old_phoneNb = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(old_fName, old_lName, old_email, old_city, old_address, old_zipcode, old_phoneNb, old_phoneNb);


            string new_fName = "Ben";
            string new_lName = "Ten";
            string new_email = "abc@dce.com";
            string new_city = "Aarhus";
            string new_address = "City Center, 12";
            string new_zipcode = "8765";
            string new_phoneNr = "12131415";

            vc.Edit(new_fName, new_lName, new_email, new_city, new_address, new_zipcode, new_phoneNr, new_phoneNr, customer.Email);

            Assert.AreEqual(customer.FirstName, new_fName);
            Assert.AreEqual(customer.LastName, new_lName);
            Assert.AreEqual(customer.Email, new_email);
            Assert.AreEqual(customer.City, new_city);
            Assert.AreEqual(customer.Address, new_address);
            Assert.AreEqual(customer.Zipcode, new_zipcode);
            Assert.AreEqual(customer.PhoneNb1, new_phoneNr);
            Assert.AreEqual(customer.PhoneNb2, new_phoneNr);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldNotEditIfEmptyFields()
        {
            string old_fName = "Jon";
            string old_lName = "Doe";
            string old_email = "abc@dce.com";
            string old_city = "Odense";
            string old_address = "City Center, 10";
            string old_zipcode = "5200";
            string old_phoneNr = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(old_fName, old_lName, old_email, old_city, old_address, old_zipcode, old_phoneNr, old_phoneNr);


            string new_fName = "Ben";
            string new_lName = "";
            string new_email = "abc@dce.com";
            string new_city = "Aarhus";
            string new_address = "";
            string new_zipcode = "8765";
            string new_phoneNr = "12131415";

            vc.Edit(new_fName, new_lName, new_email, new_city, new_address, new_zipcode, new_phoneNr, new_phoneNr, customer.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldNotEditIfPhoneNumberIsIncorrect()
        {
            string old_fName = "Jon";
            string old_lName = "Doe";
            string old_email = "abc@dce.com";
            string old_city = "Odense";
            string old_address = "City Center, 10";
            string old_zipcode = "5200";
            string old_phoneNr = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(old_fName, old_lName, old_email, old_city, old_address, old_zipcode, old_phoneNr, old_phoneNr);


            string new_fName = "Ben";
            string new_lName = "Ten";
            string new_email = "abc@dce.com";
            string new_city = "Aarhus";
            string new_address = "City Center, 12";
            string new_zipcode = "8765";
            string new_phoneNr = "1213I415";

            vc.Edit(new_fName, new_lName, new_email, new_city, new_address, new_zipcode, new_phoneNr, new_phoneNr, customer.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldNotEditIfNamesAreIncorrect()
        {
            string old_fName = "Jon";
            string old_lName = "Doe";
            string old_email = "abc@dce.com";
            string old_city = "Odense";
            string old_address = "City Center, 10";
            string old_zipcode = "5200";
            string old_phoneNr = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(old_fName, old_lName, old_email, old_city, old_address, old_zipcode, old_phoneNr, old_phoneNr);


            string new_fName = "B_n";
            string new_lName = "T3n";
            string new_email = "abc@dce.com";
            string new_city = "Aarhus";
            string new_address = "City Center, 12";
            string new_zipcode = "8765";
            string new_phoneNr = "12131415";

            vc.Edit(new_fName, new_lName, new_email, new_city, new_address, new_zipcode, new_phoneNr, new_phoneNr, customer.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldNotEditIfEmailIsIncorrect()
        {
            string old_fName = "Jon";
            string old_lName = "Doe";
            string old_email = "abc@dce.com";
            string old_city = "Odense";
            string old_address = "City Center, 10";
            string old_zipcode = "5200";
            string old_phoneNr = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(old_fName, old_lName, old_email, old_city, old_address, old_zipcode, old_phoneNr, old_phoneNr);


            string new_fName = "Ben";
            string new_lName = "Ten";
            string new_email = "ab+c@dce.com";
            string new_city = "Aarhus";
            string new_address = "City Center, 12";
            string new_zipcode = "8765";
            string new_phoneNr = "12131415";

            vc.Edit(new_fName, new_lName, new_email, new_city, new_address, new_zipcode, new_phoneNr, new_phoneNr, customer.Email);
        }

        [TestMethod]
        public void ShouldStandardizeEveryInput()
        {
            string old_fName = "Jon";
            string old_lName = "Doe";
            string old_email = "abc@dce.com";
            string old_city = "Odense";
            string old_address = "City Center, 10";
            string old_zipcode = "5200";
            string old_phoneNr = "12 13 14 15";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(old_fName, old_lName, old_email, old_city, old_address, old_zipcode, old_phoneNr, old_phoneNr);


            string new_fName = "bEn";
            string new_lName = "teN";
            string new_email = "aBc@dCe.cOm";
            string new_city = "aarHUs";
            string new_address = "city center, 12";
            string new_zipcode = "8765asd";
            string new_phoneNr = "16 17 18 19";

            vc.Edit(new_fName, new_lName, new_email, new_city, new_address, new_zipcode, old_phoneNr, new_phoneNr, customer.Email);

            Assert.AreEqual(customer.FirstName, "Ben");
            Assert.AreEqual(customer.LastName, "Ten");
            Assert.AreEqual(customer.Email, "abc@dce.com");
            Assert.AreEqual(customer.City, "Aarhus");
            Assert.AreEqual(customer.Address, "City Center, 12");
            Assert.AreEqual(customer.Zipcode, "8765ASD");
            Assert.AreEqual(customer.PhoneNb1, "12131415");
            Assert.AreEqual(customer.PhoneNb2, "16171819");
        }

        [TestMethod]
        public void ShouldUpdateCustomerInEveryCase()
        {
            string old_fName = "Jon";
            string old_lName = "Doe";
            string old_email = "abc@dce.com";
            string old_city = "Odense";
            string old_address = "City Center, 10";
            string old_zipcode = "5200";
            string old_phoneNr = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(old_fName, old_lName, old_email, old_city, old_address, old_zipcode, old_phoneNr, old_phoneNr);

            CaseRepository cr = CaseRepository.Instance;

            Case case1 = new Case();
            case1.Customer = customer;
            case1.CaseNumber = 1;

            Case case2 = new Case();
            case2.Customer = customer;
            case2.CaseNumber = 2;

            cr.Add(case1);
            cr.Add(case2);

            string new_fName = "Ben";
            string new_lName = "Ten";
            string new_email = "abc@dce.com";
            string new_city = "Aarhus";
            string new_address = "City Center, 12";
            string new_zipcode = "8765";
            string new_phoneNr = "12131415";

            vc.Edit(new_fName, new_lName, new_email, new_city, new_address, new_zipcode, new_phoneNr, new_phoneNr, customer.Email);

            Assert.AreEqual(cr.Load(1).Customer.FirstName, cr.Load(2).Customer.FirstName);
        }


    }
}
