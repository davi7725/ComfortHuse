﻿using Comforthuse;
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
        public void GetHouseTypeCategoryObject()
        {

            DomainFacade df = new DomainFacade();

            ICase c = df.CreateCase();

            List<ITechnicalSpecification> tspec = new List<ITechnicalSpecification>();


            IHouseTypeExpenses htExpenses = (IHouseTypeExpenses)c.GetExpenseCategory(Category.HouseType);


            Assert.AreEqual(typeof(HouseTypeExpenses), htExpenses.GetType());
            Assert.AreNotEqual(null, htExpenses);

        }
    }
}
