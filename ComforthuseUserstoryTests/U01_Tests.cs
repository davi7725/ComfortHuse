using Comforthuse.Models;
using Comforthuse.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ComforthuseUserstoryTests
{
    /// <summary>
    /// Summary description for U01_Tests
    /// </summary>
    [TestClass]
    public class U01_Tests
    {
        [TestInitialize]
        public void CleanRepository()
        {
            CustomerRepository.Instance.Clear();
        }
        [TestMethod]
        public void CheckIfAllFieldsHaveValues()
        {
            string fName = "Jon";
            string lName = "Doe";
            string email = "abc@dce.com";
            string city = "Odense";
            string address = "City Center, 10";
            string zipcode = "5200";
            string phoneNb = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, email, city, address, zipcode, phoneNb, phoneNb);

            Assert.AreEqual(fName, customer.FirstName);
            Assert.AreEqual(lName, customer.LastName);
            Assert.AreEqual(city, customer.City);
            Assert.AreEqual(address, customer.Address);
            Assert.AreEqual(zipcode, customer.Zipcode);
            Assert.AreEqual(phoneNb, customer.PhoneNb1);
            Assert.AreEqual(phoneNb, customer.PhoneNb2);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckIfSomeFieldsAreEmpty()
        {
            string fName = "";
            string lName = "Doe";
            string email = "abc@dce.com";
            string city = "Odense";
            string address = "";
            string zipcode = "5200";
            string phoneNb = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, email, city, address, zipcode, phoneNb, phoneNb);

        }

        [TestMethod]
        public void CheckIfNamesGetStandardized()
        {
            string fName = "jANe";
            string lName = "DOe";
            string email = "abc@dce.com";
            string city = "oDeNSE";
            string address = "no street";
            string zipcode = "5200";
            string phoneNb = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, email, city, address, zipcode, phoneNb, phoneNb);

            Assert.AreEqual("Jane", customer.FirstName);
            Assert.AreEqual("Doe", customer.LastName);
            Assert.AreEqual("Odense", customer.City);
        }

        [TestMethod]
        public void CheckIfAddressGetsStandardized()
        {
            string fName = "jANe";
            string lName = "DOe";
            string email = "abc@dce.com";
            string city = "oDeNSE";
            string address = "no street, 12309";
            string zipcode = "5200";
            string phoneNb = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, email, city, address, zipcode, phoneNb, phoneNb);

            Assert.AreEqual("No Street, 12309", customer.Address);
        }

        [TestMethod]
        public void CheckIfZipcodeGetsStandardized()
        {
            string fName = "jANe";
            string lName = "DOe";
            string email = "abc@dce.com";
            string city = "oDeNSE";
            string address = "no street, 12309";
            string zipcode = "52o0da";
            string phoneNb = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, email, city, address, zipcode, phoneNb, phoneNb);

            Assert.AreEqual("52O0DA", customer.Zipcode);
        }

        [TestMethod]
        public void CheckIfPhoneNbsGetStandardized()
        {
            string fName = "jANe";
            string lName = "DOe";
            string email = "abc@dce.com";
            string city = "oDeNSE";
            string address = "no street, 12309";
            string zipcode = "52o0da";
            string phoneNb = "30 52 54 85";

            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, email, city, address, zipcode, phoneNb, phoneNb);

            Assert.AreEqual("30525485", customer.PhoneNb1);
            Assert.AreEqual("30525485", customer.PhoneNb2);

        }

        [TestMethod]
        public void CheckIfEmailGetStandardized()
        {
            string fName = "jANe";
            string lName = "DOe";
            string email = "aBC@dCe.com";
            string city = "oDeNSE";
            string address = "no street, 12309";
            string zipcode = "52o0da";
            string phoneNb = "30 52 54 85";

            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, email, city, address, zipcode, phoneNb, phoneNb);

            Assert.AreEqual("abc@dce.com", customer.Email);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckIfExceptionIsThrownOnPhoneWithLetters()
        {
            string fName = "";
            string lName = "Doe";
            string email = "abc@dce.com";
            string city = "Odense";
            string address = "";
            string zipcode = "5200";
            string phoneNb = "31525a85";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, email, city, address, zipcode, phoneNb, phoneNb);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckIfExceptionIsThrownOnNameWithNumbers()
        {
            string fName = "J1ohn";
            string lName = "D0e";
            string email = "abc@dce.com";
            string city = "Odense";
            string address = "";
            string zipcode = "5200";
            string phoneNb = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, email, city, address, zipcode, phoneNb, phoneNb);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckIfExceptionIsThrownOnEmailWithInvalidCharacters()
        {
            string fName = "Jon";
            string lName = "Doe";
            string email = "ab c@dce.com";
            string city = "Odense";
            string address = "City Center, 10";
            string zipcode = "5200";
            string phoneNb = "31525485";

            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, email, city, address, zipcode, phoneNb, phoneNb);

        }
    }
}
