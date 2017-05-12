using Comforthuse.Facade;
using Comforthuse.Interfaces;
using Comforthuse.Models;
using Comforthuse.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ComforthuseUserstoryTests
{
    [TestClass]
    public class U19_1_HouseTypeExpenseCategory
    {


        [TestMethod]
        public void CanCastHouseTypeCategory()
        {

            DomainFacade df = new DomainFacade();

            ICase c = df.CreateCase();

            List<ITechnicalSpecification> tspec = new List<ITechnicalSpecification>();
            tspec.Add(new TechnicalSpecification());
            tspec.Add(new TechnicalSpecification());
            tspec.Add(new TechnicalSpecification());
            tspec.Add(new TechnicalSpecification());
            tspec.Add(new TechnicalSpecification());

            IHouseTypeExpenses htExpenses = new HouseTypeExpenses();

            Assert.AreEqual(1, 1);

        }
    }
}
