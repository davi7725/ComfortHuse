using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comforthuse.Models;
using Comforthuse.Utility;

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
            string city = "Odense";
            string address = "City Center, 10";
            string zipcode = "5200";
            string phoneNr = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, city, address, zipcode, phoneNr, phoneNr);

            Assert.AreEqual(fName, customer.FirstName);
            Assert.AreEqual(lName, customer.LastName);
            Assert.AreEqual(city, customer.City);
            Assert.AreEqual(address, customer.Address);
            Assert.AreEqual(zipcode, customer.Zipcode);
            Assert.AreEqual(phoneNr, customer.PhoneNr1);
            Assert.AreEqual(phoneNr, customer.PhoneNr2);
        }


        [TestMethod]
        [ExpectedException (typeof(Exception))]
        public void CheckIfSomeFieldsAreEmpty()
        {
            string fName = "";
            string lName = "Doe";
            string city = "Odense";
            string address = "";
            string zipcode = "5200";
            string phoneNr = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, city, address, zipcode, phoneNr, phoneNr);
            
        }

        [TestMethod]
        public void CheckIfNamesGetStandardized()
        {
            string fName = "jANe";
            string lName = "DOe";
            string city = "oDeNSE";
            string address = "no street";
            string zipcode = "5200";
            string phoneNr = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, city, address, zipcode, phoneNr, phoneNr);

            Assert.AreEqual("Jane", customer.FirstName);
            Assert.AreEqual("Doe", customer.LastName);
            Assert.AreEqual("Odense", customer.City);
        }

        [TestMethod]
        public void CheckIfAddressGetsStandardized()
        {
            string fName = "jANe";
            string lName = "DOe";
            string city = "oDeNSE";
            string address = "no street, 12309";
            string zipcode = "5200";
            string phoneNr = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, city, address, zipcode, phoneNr, phoneNr);

            Assert.AreEqual("No Street, 12309", customer.Address);
        }

        [TestMethod]
        public void CheckIfZipcodeGetsStandardized()
        {
            string fName = "jANe";
            string lName = "DOe";
            string city = "oDeNSE";
            string address = "no street, 12309";
            string zipcode = "52o0da";
            string phoneNr = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, city, address, zipcode, phoneNr, phoneNr);

            Assert.AreEqual("52O0DA", customer.Zipcode);
        }

        [TestMethod]
        public void CheckIfPhoneNrsGetStandardized()
        {
            string fName = "jANe";
            string lName = "DOe";
            string city = "oDeNSE";
            string address = "no street, 12309";
            string zipcode = "52o0da";
            string phoneNr = "30 52 54 85";

            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, city, address, zipcode, phoneNr, phoneNr);

            Assert.AreEqual("30525485", customer.PhoneNr1);
            Assert.AreEqual("30525485", customer.PhoneNr2);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckIfExceptionIsThrownOnPhoneWithLetters()
        {
            string fName = "";
            string lName = "Doe";
            string city = "Odense";
            string address = "";
            string zipcode = "5200";
            string phoneNr = "31525a85";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, city, address, zipcode, phoneNr, phoneNr);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckIfExceptionIsThrownOnNameWithNumbers()
        {
            string fName = "";
            string lName = "D0e";
            string city = "Odense";
            string address = "";
            string zipcode = "5200";
            string phoneNr = "31525485";


            ValidateCustomer vc = new ValidateCustomer();

            ICustomer customer = vc.CreateCustomer(fName, lName, city, address, zipcode, phoneNr, phoneNr);

        }
    }
}
