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
        /*[TestMethod]
        public void PriceChangeOnUpdatedAmountOfMaterial()
        {

            ICase case1 = ObjectFactory.Instance.CreateNewCase();
            case1.CaseNumber = 1;

            case1.

        }*/

        [TestMethod]
        public void PriceChangeOnUpdatedPriceOfMaterial()
        {
            ICase case1 = ObjectFactory.Instance.CreateNewCase();
            case1.CaseNumber = 1;

            IExpenseCategory ec = case1.GetExpenseCategory(Comforthuse.Category.HouseType);

            IExtraExpenseSpecification ees = new ExtraExpenseSpecification();
            ees.PricePerUnit = 10;
            ees.Amount = 1;
            ec.ExtraExpenses.Add(ees);

            Assert.AreEqual(10, case1.Price);
        }

        [TestMethod]
        public void PriceChangeOnSelectedIsland()
        {
        }

        [TestMethod]
        public void PriceIsBaseWithoutAnySpecifiedExpenses()
        {
        }
    }
}
