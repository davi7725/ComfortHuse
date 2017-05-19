using Comforthuse.Models;
using Comforthuse.Utility;
using EmployeeGUI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComforthuseUserstoryTests
{
    //??????
    [TestClass]
    public class U27_Tests2
    {
        [TestMethod]
        public void ShouldUpdateExtraExpenseAmount()
        {
            ICase case1 = ObjectFactory.Instance.CreateNewCase();

            CaseViewModel cvm = new CaseViewModel();
            cvm.Case = case1;
            cvm.InjectExpenseCategories();

            cvm.CurrentPageViewModel = cvm.PageViewModels[1];
            cvm.CurrentPageViewModel.ExtraExpenses[0].Amount = 25;

            Assert.AreEqual(25, case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Amount);
        }

        [TestMethod]
        public void ShouldAddExtraExpenseSpecificationForNewCase()
        {
            ICase case1 = ObjectFactory.Instance.CreateNewCase();

            CaseViewModel cvm = new CaseViewModel();
            cvm.Case = case1;
            cvm.InjectExpenseCategories();

            cvm.CurrentPageViewModel = cvm.PageViewModels[1];
            cvm.CurrentPageViewModel.ExtraExpenses[0].Title = "Wall";
            cvm.CurrentPageViewModel.ExtraExpenses[0].Description = "Wooden Tile";
            cvm.CurrentPageViewModel.ExtraExpenses[0].Amount = 10;
            cvm.CurrentPageViewModel.ExtraExpenses[0].PricePerUnit = 15;

            Assert.AreEqual("Wall", case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Title);
            Assert.AreEqual("Wooden Tile", case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Description);
            Assert.AreEqual(10, case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Amount);
            Assert.AreEqual(15, case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].PricePerUnit);
        }

        [TestMethod]
        public void ShouldEditExistingExtraExpenseSpecification()
        {
            ICase case1 = ObjectFactory.Instance.CreateNewCase();

            CaseViewModel cvm = new CaseViewModel();
            cvm.Case = case1;
            cvm.InjectExpenseCategories();

            cvm.CurrentPageViewModel = cvm.PageViewModels[1];
            cvm.CurrentPageViewModel.ExtraExpenses[0].Title = "Wall";
            cvm.CurrentPageViewModel.ExtraExpenses[0].Description = "Wooden Tile";
            cvm.CurrentPageViewModel.ExtraExpenses[0].Amount = 10;
            cvm.CurrentPageViewModel.ExtraExpenses[0].PricePerUnit = 15;

            cvm.CurrentPageViewModel.ExtraExpenses[1].Title = "Wall-e";
            cvm.CurrentPageViewModel.ExtraExpenses[1].Description = "Wooden Tile floating";
            cvm.CurrentPageViewModel.ExtraExpenses[1].Amount = 5;
            cvm.CurrentPageViewModel.ExtraExpenses[1].PricePerUnit = 10;

            Assert.AreEqual("Wall-e", case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[1].Title);
            Assert.AreEqual("Wooden Tile floating", case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[1].Description);
            Assert.AreEqual(5, case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[1].Amount);
            Assert.AreEqual(10, case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[1].PricePerUnit);

            cvm.CurrentPageViewModel.ExtraExpenses[1].Title = "Ceiling";
            cvm.CurrentPageViewModel.ExtraExpenses[1].Description = "Wooden Squares";
            cvm.CurrentPageViewModel.ExtraExpenses[1].Amount = 11;
            cvm.CurrentPageViewModel.ExtraExpenses[1].PricePerUnit = 2000;


            Assert.AreEqual("Wall", case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Title);
            Assert.AreEqual("Wooden Tile", case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Description);
            Assert.AreEqual(10, case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Amount);
            Assert.AreEqual(15, case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].PricePerUnit);

            Assert.AreEqual("Ceiling", case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[1].Title);
            Assert.AreEqual("Wooden Squares", case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[1].Description);
            Assert.AreEqual(11, case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[1].Amount);
            Assert.AreEqual(2000, case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[1].PricePerUnit);
        }

        [TestMethod]
        public void ShouldAddExtraExpenseSpecificationOnTwoCategories()
        {
            ICase case1 = ObjectFactory.Instance.CreateNewCase();

            CaseViewModel cvm = new CaseViewModel();
            cvm.Case = case1;
            cvm.InjectExpenseCategories();

            cvm.CurrentPageViewModel = cvm.PageViewModels[1];
            cvm.CurrentPageViewModel.ExtraExpenses[0].Title = "Wall";
            cvm.CurrentPageViewModel.ExtraExpenses[0].Description = "Wooden Tile";
            cvm.CurrentPageViewModel.ExtraExpenses[0].Amount = 10;
            cvm.CurrentPageViewModel.ExtraExpenses[0].PricePerUnit = 15;

            cvm.CurrentPageViewModel = cvm.PageViewModels[11];
            cvm.CurrentPageViewModel.ExtraExpenses[0].Title = "Wall-e";
            cvm.CurrentPageViewModel.ExtraExpenses[0].Description = "Wooden Tile floating";
            cvm.CurrentPageViewModel.ExtraExpenses[0].Amount = 5;
            cvm.CurrentPageViewModel.ExtraExpenses[0].PricePerUnit = 10;

            Assert.AreEqual("Wall", case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Title);
            Assert.AreEqual("Wooden Tile", case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Description);
            Assert.AreEqual(10, case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Amount);
            Assert.AreEqual(15, case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].PricePerUnit);

            Assert.AreEqual("Wall-e", case1.GetExpenseCategory(Comforthuse.Category.Carpentry).ExtraExpenses[0].Title);
            Assert.AreEqual("Wooden Tile floating", case1.GetExpenseCategory(Comforthuse.Category.Carpentry).ExtraExpenses[0].Description);
            Assert.AreEqual(5, case1.GetExpenseCategory(Comforthuse.Category.Carpentry).ExtraExpenses[0].Amount);
            Assert.AreEqual(10, case1.GetExpenseCategory(Comforthuse.Category.Carpentry).ExtraExpenses[0].PricePerUnit);
        }

        [TestMethod]
        public void ShouldEditExtraExpenseProductOnDifferentCategories()
        {
            ICase case1 = ObjectFactory.Instance.CreateNewCase();

            CaseViewModel cvm = new CaseViewModel();
            cvm.Case = case1;
            cvm.InjectExpenseCategories();

            cvm.CurrentPageViewModel = cvm.PageViewModels[1];
            cvm.CurrentPageViewModel.ExtraExpenses[0].Title = "Wall";
            cvm.CurrentPageViewModel.ExtraExpenses[0].Description = "Wooden Tile";
            cvm.CurrentPageViewModel.ExtraExpenses[0].Amount = 10;
            cvm.CurrentPageViewModel.ExtraExpenses[0].PricePerUnit = 15;

            cvm.CurrentPageViewModel = cvm.PageViewModels[11];
            cvm.CurrentPageViewModel.ExtraExpenses[0].Title = "Wall-e";
            cvm.CurrentPageViewModel.ExtraExpenses[0].Description = "Wooden Tile floating";
            cvm.CurrentPageViewModel.ExtraExpenses[0].Amount = 5;
            cvm.CurrentPageViewModel.ExtraExpenses[0].PricePerUnit = 10;

            Assert.AreEqual("Wall", case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Title);
            Assert.AreEqual("Wooden Tile", case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Description);
            Assert.AreEqual(10, case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Amount);
            Assert.AreEqual(15, case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].PricePerUnit);

            Assert.AreEqual("Wall-e", case1.GetExpenseCategory(Comforthuse.Category.Carpentry).ExtraExpenses[0].Title);
            Assert.AreEqual("Wooden Tile floating", case1.GetExpenseCategory(Comforthuse.Category.Carpentry).ExtraExpenses[0].Description);
            Assert.AreEqual(5, case1.GetExpenseCategory(Comforthuse.Category.Carpentry).ExtraExpenses[0].Amount);
            Assert.AreEqual(10, case1.GetExpenseCategory(Comforthuse.Category.Carpentry).ExtraExpenses[0].PricePerUnit);

            cvm.CurrentPageViewModel = cvm.PageViewModels[1];
            cvm.CurrentPageViewModel.ExtraExpenses[0].Title = "Wall-e";
            cvm.CurrentPageViewModel.ExtraExpenses[0].Description = "Wooden Tile floating";
            cvm.CurrentPageViewModel.ExtraExpenses[0].Amount = 5;
            cvm.CurrentPageViewModel.ExtraExpenses[0].PricePerUnit = 10;

            cvm.CurrentPageViewModel = cvm.PageViewModels[11];
            cvm.CurrentPageViewModel.ExtraExpenses[0].Title = "Wall";
            cvm.CurrentPageViewModel.ExtraExpenses[0].Description = "Wooden Tile";
            cvm.CurrentPageViewModel.ExtraExpenses[0].Amount = 10;
            cvm.CurrentPageViewModel.ExtraExpenses[0].PricePerUnit = 15;

            Assert.AreEqual("Wall", case1.GetExpenseCategory(Comforthuse.Category.Carpentry).ExtraExpenses[0].Title);
            Assert.AreEqual("Wooden Tile", case1.GetExpenseCategory(Comforthuse.Category.Carpentry).ExtraExpenses[0].Description);
            Assert.AreEqual(10, case1.GetExpenseCategory(Comforthuse.Category.Carpentry).ExtraExpenses[0].Amount);
            Assert.AreEqual(15, case1.GetExpenseCategory(Comforthuse.Category.Carpentry).ExtraExpenses[0].PricePerUnit);

            Assert.AreEqual("Wall-e", case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Title);
            Assert.AreEqual("Wooden Tile floating", case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Description);
            Assert.AreEqual(5, case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].Amount);
            Assert.AreEqual(10, case1.GetExpenseCategory(Comforthuse.Category.CarportGarage).ExtraExpenses[0].PricePerUnit);

        }
    }
}
