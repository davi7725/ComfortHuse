using Comforthuse;
using Comforthuse.Facade;
using Comforthuse.Interfaces;
using Comforthuse.Models;
using Comforthuse.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ComforthuseUserstoryTests
{
    [TestClass]
    public class U25_EditTechnicalSpecifications
    {


        [TestMethod]
        public void GetListOfTechnicalSpecifiations()
        {

            DomainFacade df = new DomainFacade();

            ICase c = df.CreateCase();

            List<ITechnicalSpecification> tspec = new List<ITechnicalSpecification>();
            


            IHouseTypeExpenses htExpenses = (IHouseTypeExpenses)c.GetExpenseCategory(Category.HouseType);

            //List has 5 

            Assert.AreEqual(typeof(HouseTypeExpenses), htExpenses.GetType());
            Assert.AreNotEqual(null, htExpenses);
        }
    }
}
