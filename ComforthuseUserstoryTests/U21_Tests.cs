using System;
using Comforthuse.Models;
using Comforthuse.Utility;
using Comforthuse.Database;
using Comforthuse.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComforthuseUserstoryTests
{
    [TestClass]
    public class U21_Tests
    {
        [TestMethod]
        public void ShouldInsertCaseInDatabase()
        {
            ICase case1 = ObjectFactory.Instance.CreateNewCase();

            case1.Customer.FirstName = "David";
            case1.Customer.LastName = "Alves";
            case1.Customer.Email = "davi7816@edu.eal.dk";
            case1.Customer.City = "Porto";
            case1.Customer.Address = "Praceta Ribeiro Sanches nº89";
            case1.Customer.Zipcode = "4100-428";
            case1.Customer.PhoneNb1 = "937776684";
            case1.Customer.PhoneNb2 = "31854331";

            case1.MoneyInstitute = new MoneyInstitute() { Name = "InstituteFake", Address = "Street", Zipcode = "5200", City = "Odense", PhoneNb = "31853146" };

            case1.Employee = new Employee("Employee1", "Mister", "test@abc.com", "123456278");

            case1.Plot = new Plot() { Zipcode = "21331", Address = "testaddress", City = "Idunno", Area = "Giant", Municipality = "Odense", AvailabilityDate = new DateTime(2017, 6, 23) };

            case1.Image = new Image() { Path = @"c:\test\img.png", Description = "Very good image" };

            Assert.IsTrue(DatabaseController.Instance.SaveCase(case1));

        }
    }
}
