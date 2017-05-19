﻿using System;
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

            case1.CaseNumber = 1;
            case1.DateOfCreation = new DateTime(2017, 6, 6);
            

            case1.ConstructionStartDate = new DateTime(2017, 1, 1);
            case1.MoveInDate = new DateTime(2016, 2, 2);
            case1.Description = "Very bad description of this case";

            case1.Customer.FirstName = "David";
            case1.Customer.LastName = "Alves";
            case1.Customer.Email = "davi7816@edu.eal.dk";
            case1.Customer.City = "Porto";
            case1.Customer.Address = "Praceta Ribeiro Sanches nº89";
            case1.Customer.Zipcode = "4100-428";
            case1.Customer.PhoneNb1 = "937776684";
            case1.Customer.PhoneNb2 = "31854331";

            case1.MoneyInstitute = new MoneyInstitute() { Name = "InstituteFake", Address = "Street", Zipcode = "5200", City = "Odense", PhoneNb = "31853146" };

            case1.Employee = new Employee("Alan", "Boje", "ab@comforthuse.dk", "24813540");

            case1.Plot = new Plot() { Zipcode = "21331", Address = "testaddress", City = "Idunno", Area = "Giant", Municipality = "Odense", AvailabilityDate = new DateTime(2017, 6, 23) };

            case1.Image = new Image() { Path = @"c:\test\img2.png", Description = "Very good image" };


            case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Title = "Wall";
            case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Amount = 10;
            case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].PricePerUnit = 10;
            case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Description = "Wood";

            case1.GetExpenseCategory(Comforthuse.Category.Carpentry).ExtraExpenses[0].Title = "Material";
            case1.GetExpenseCategory(Comforthuse.Category.Carpentry).ExtraExpenses[0].Amount = 1;
            case1.GetExpenseCategory(Comforthuse.Category.Carpentry).ExtraExpenses[0].PricePerUnit = 10;
            case1.GetExpenseCategory(Comforthuse.Category.Carpentry).ExtraExpenses[0].Description = "Hammer";

            case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).TechnicalSpecifications[0].EditAble = true;
            case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).TechnicalSpecifications[0].Description = "Woow such a technical thing";

            case1.GetExpenseCategory(Comforthuse.Category.Carpentry).TechnicalSpecifications[0].EditAble = false;
            case1.GetExpenseCategory(Comforthuse.Category.Carpentry).TechnicalSpecifications[0].Description = "I don't know how to write technical jk";



            Assert.IsTrue(DatabaseController.Instance.SaveCase(case1));

        }
    }
}
