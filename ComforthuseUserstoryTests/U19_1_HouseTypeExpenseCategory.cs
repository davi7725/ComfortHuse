using Comforthuse;
using Comforthuse.Facade;
using Comforthuse.Interfaces;
using Comforthuse.Models;
using Comforthuse.Utility;
using EmployeeGUI.ViewModels.ExpenseCategoryPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleMVVMExample;
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

            IExpenseCategory expenseCategory = c.GetExpenseCategory(Category.HouseType);
            IHouseTypeExpenses houseTypeExpenses = (IHouseTypeExpenses)expenseCategory;

            Assert.AreEqual(typeof(IHouseTypeExpenses), houseTypeExpenses.GetType());
            Assert.AreNotEqual(null, expenseCategory);

        }

        [TestMethod]
        public void CanValidateHouseTypeProperties()
        {
            IHouseTypeExpenses houseTypeExpenses = new HouseTypeExpenses();
            houseTypeExpenses.HouseType.Name = "H170";
            houseTypeExpenses.HouseType.Area = 22;
            houseTypeExpenses.HouseType.TotalPrice = 10000;
            houseTypeExpenses.HouseType.Description = "The description";

            IPageViewModel htvm = new HouseTypeExpenseViewModel();



            //Assert.AreEqual();
        }


    }
}
