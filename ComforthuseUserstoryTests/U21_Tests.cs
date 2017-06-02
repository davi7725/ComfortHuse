using System;
using Comforthuse.Models;
using Comforthuse.Utility;
using Comforthuse.Database;
using Comforthuse.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comforthuse;
using System.Collections.Generic;

namespace ComforthuseUserstoryTests
{
    [TestClass]
    public class U21_Tests
    {
        private Dictionary<int, ProductType> listOfProductTypes;
        private Dictionary<int, ProductOption> listOfProductOptions;

        [TestInitialize]
        public void InitializeRepositories()
        {
            listOfProductTypes = ProductTypeRepository.Instance.GetProductTypes();
            listOfProductOptions = ProductOptionRepository.Instance.GetProductOptions();
        }
        [TestMethod]
        public void ShouldInsertCaseWithOnlyTheNecessaryInformation()
        {
            CaseRepository.Instance.GetAllCases();
            ICase case1 = ObjectFactory.Instance.CreateNewCase();

            case1.CaseNumber = 0;

            case1.Customer.FirstName = "David";
            case1.Customer.LastName = "Alves";
            case1.Customer.Email = "castor3@email.com";
            case1.Customer.City = "Porto";
            case1.Customer.Address = "Praceta Ribeiro Sanches nº89";
            case1.Customer.Zipcode = "4100-428";
            case1.Customer.PhoneNb1 = "937776684";
            case1.Customer.PhoneNb2 = "31854331";

            case1.Employee = new Employee("Alan", "Boje", "ab@comforthuse.dk", "24813540");

            Assert.IsTrue(DatabaseController.Instance.SaveCase(case1));
        }

        [TestMethod]
        public void ShouldNotInsertCaseWithLessThenTheNecessaryInformation()
        {
            ICase case1 = ObjectFactory.Instance.CreateNewCase();

            case1.CaseNumber = 0;

            case1.Employee = new Employee("Alan", "Boje", "ab@comforthuse.dk", "24813540");

            Assert.IsFalse(DatabaseController.Instance.SaveCase(case1));
        }

        [TestMethod]
        public void ShouldInsertCaseWithAllInformation()
        {
            ICase case1 = ObjectFactory.Instance.CreateNewCase();

            case1.CaseNumber = 0;

            case1.Customer.FirstName = "David";
            case1.Customer.LastName = "Alves";
            case1.Customer.Email = "castor3@noproblemo.com";
            case1.Customer.City = "Porto";
            case1.Customer.Address = "Praceta Ribeiro Sanches nº89";
            case1.Customer.Zipcode = "4100-428";
            case1.Customer.PhoneNb1 = "937776684";
            case1.Customer.PhoneNb2 = "31854331";

            case1.Employee = new Employee("Alan", "Boje", "ab@comforthuse.dk", "24813540");
            case1.MoneyInstitute = new MoneyInstitute() { Name = "intituto", Address = "intitutoAddress", Zipcode = "5200", City = "Odense", PhoneNb = "31854545" };

            case1.Plot = new Plot() { Zipcode = "31634", Address = "testaddressforplot", City = "Idunno", Area = 123, Municipality = "Odense", AvailabilityDate = new DateTime(2017, 6, 23) };

            case1.Image = new Image() { Path = @"c:\test\img2.png", Description = "Very good image" };
            case1.GetExpenseCategory(Category.CarportGarage).ExtraExpenses[0].Title = "Wall";
            case1.GetExpenseCategory(Category.CarportGarage).ExtraExpenses[0].Amount = 10;
            case1.GetExpenseCategory(Category.CarportGarage).ExtraExpenses[0].PricePerUnit = 10;
            case1.GetExpenseCategory(Category.CarportGarage).ExtraExpenses[0].Description = "Wood";
            case1.GetExpenseCategory(Category.HouseType).ExtraExpenses[0].Title = "Material";
            case1.GetExpenseCategory(Category.HouseType).ExtraExpenses[0].Amount = 1;
            case1.GetExpenseCategory(Category.HouseType).ExtraExpenses[0].PricePerUnit = 10;
            case1.GetExpenseCategory(Category.HouseType).ExtraExpenses[0].Description = "Hammer";
            case1.GetExpenseCategory(Category.CarportGarage).TechnicalSpecifications[0].Editable = true;
            case1.GetExpenseCategory(Category.CarportGarage).TechnicalSpecifications[0].Description = "Woow such a technical thing";
            case1.GetExpenseCategory(Category.HouseType).TechnicalSpecifications[0].Editable = false;
            case1.GetExpenseCategory(Category.HouseType).TechnicalSpecifications[0].Description = "I don't know how to write technical jk";
            case1.GetExpenseCategory(Category.Plot).TechnicalSpecifications[0].Editable = false;
            case1.GetExpenseCategory(Category.Plot).TechnicalSpecifications[0].Description = "I don't know how to write";
            case1.GetExpenseCategory(Category.CarportGarage).ListOfProductTypes[0].ListOfProductOptions[1].Selected = true;
            case1.GetExpenseCategory(Category.CarportGarage).ListOfProductTypes[0].ListOfProductOptions[1].Amount = 30;
            case1.GetExpenseCategory(Category.CarportGarage).ListOfProductTypes[0].ListOfProductOptions[1].SpecialPrice = 19.99M;
            
            IHouseTypeExpenses houseEx = (IHouseTypeExpenses)case1.GetExpenseCategory(Category.HouseType);
            houseEx.HouseType = new HouseType();
            houseEx.HouseType.TotalPrice = 123654;

            Assert.IsTrue(DatabaseController.Instance.SaveCase(case1));
        }

    }
}
