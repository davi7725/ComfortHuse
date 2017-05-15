using System;
using Comforthuse.Models;
using Comforthuse.Utility;
using Comforthuse.Models.SpecificationDerivatives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comforthuse.Interfaces;

namespace ComforthuseUserstoryTests
{
    [TestClass]
    public class U09_Tests
    {
        [TestMethod]
        public void PriceChangeOnUpdatedAmountOfMaterial()
        {

            ICase case1 = ObjectFactory.Instance.CreateNewCase();

            IExpenseCategory ec = case1.GetExpenseCategory(Comforthuse.Category.Interior);

            IExtraExpenseSpecification ees = new ExtraExpenseSpecification();
            ees.PricePerUnit = 10;
            ees.Amount = 1;
            ec.ExtraExpenses.Add(ees);

            Assert.AreEqual(10, case1.Price);

            ees.Amount = 2;

            Assert.AreEqual(20, case1.Price);
        }

        [TestMethod]
        public void PriceChangeOnUpdatedPriceOfMaterial()
        {
            ICase case1 = ObjectFactory.Instance.CreateNewCase();

            IExpenseCategory ec = case1.GetExpenseCategory(Comforthuse.Category.CarportGarage);

            IExtraExpenseSpecification ees = new ExtraExpenseSpecification();
            ees.PricePerUnit = 10;
            ees.Amount = 1;
            ec.ExtraExpenses.Add(ees);

            Assert.AreEqual(10, case1.Price);

            ees.PricePerUnit = 20;
            Assert.AreEqual(20, case1.Price);
        }

        [TestMethod]
        public void PriceIsBaseWithoutAnySpecifiedExpenses()
        {
            ICase case1 = ObjectFactory.Instance.CreateNewCase();

            IExpenseCategory ec = case1.GetExpenseCategory(Comforthuse.Category.HouseType);


            IHouseTypeExpenses hte = (IHouseTypeExpenses)ec;

            hte.HouseType.TotalPrice = 123456;


            Assert.AreEqual(123456, case1.Price);
        }
    }
}
