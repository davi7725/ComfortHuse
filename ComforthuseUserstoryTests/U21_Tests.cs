﻿using System;
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
        [TestMethod]
        public void ShouldInsertCaseInDatabase()
        {

            Dictionary<int, ProductType> listOfProductTypes = ProductTypeRepository.Instance.GetProductTypes();
            Dictionary<int, ProductOption> listOfProductOptions = ProductOptionRepository.Instance.GetProductOptions();
            

            ICase case1 = ObjectFactory.Instance.CreateNewCase();

            case1.CaseNumber =0;

            case1.Customer.FirstName = "David";
            case1.Customer.LastName = "Alves";
            case1.Customer.Email = "castor3@noproblemo.com";
            case1.Customer.City = "Porto";
            case1.Customer.Address = "Praceta Ribeiro Sanches nº89";
            case1.Customer.Zipcode = "4100-428";
            case1.Customer.PhoneNb1 = "937776684";
            case1.Customer.PhoneNb2 = "31854331";

            //case1.MoneyInstitute = new MoneyInstitute() { Name = "intituto", Address = "intitutoAddress", Zipcode = "5200", City = "Odense", PhoneNb = "31854545" };

            //case1.Employee = new Employee("Alan", "Boje", "ab@comforthuse.dk", "24813540");

            //case1.Plot = new Plot() { Zipcode = "31634", Address = "testaddressforplot", City = "Idunno", Area = 123, Municipality = "Odense", AvailabilityDate = new DateTime(2017, 6, 23) };

            //case1.Image = new Image() { Path = @"c:\test\img2.png", Description = "Very good image" };


            /*case1.GetExpenseCategory(Category.CarportGarage).ExtraExpenses[0].Title = "Wall";
            case1.GetExpenseCategory(Category.CarportGarage).ExtraExpenses[0].Amount = 10;
            case1.GetExpenseCategory(Category.CarportGarage).ExtraExpenses[0].PricePerUnit = 10;
            case1.GetExpenseCategory(Category.CarportGarage).ExtraExpenses[0].Description = "Wood";

            case1.GetExpenseCategory(Category.Carpentry).ExtraExpenses[0].Title = "Material";
            case1.GetExpenseCategory(Category.Carpentry).ExtraExpenses[0].Amount = 1;
            case1.GetExpenseCategory(Category.Carpentry).ExtraExpenses[0].PricePerUnit = 10;
            case1.GetExpenseCategory(Category.Carpentry).ExtraExpenses[0].Description = "Hammer";

            case1.GetExpenseCategory(Category.CarportGarage).TechnicalSpecifications[0].EditAble = true;
            case1.GetExpenseCategory(Category.CarportGarage).TechnicalSpecifications[0].Description = "Woow such a technical thing";

            case1.GetExpenseCategory(Category.Carpentry).TechnicalSpecifications[0].EditAble = false;
            case1.GetExpenseCategory(Category.Carpentry).TechnicalSpecifications[0].Description = "I don't know how to write technical jk";

            case1.GetExpenseCategory(Category.CarportGarage).ListOfProductTypes[0].ListOfProductOption[1].Selected = true;
            case1.GetExpenseCategory(Category.CarportGarage).ListOfProductTypes[0].ListOfProductOption[1].Amount = 30;
            case1.GetExpenseCategory(Category.CarportGarage).ListOfProductTypes[0].ListOfProductOption[1].SpecialPrice = 19.99M;*/

            /*IHouseTypeExpenses houseEx = (IHouseTypeExpenses)case1.GetExpenseCategory(Category.HouseType);
            houseEx.HouseType = new HouseType();
            houseEx.HouseType.TotalPrice = 123654;*/
            throw new Exception(DatabaseController.Instance.GetAllCases().Count.ToString());

            Assert.IsTrue(DatabaseController.Instance.SaveCase(case1));

        }
    }
}
