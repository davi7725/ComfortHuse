using System.Collections.Generic;
using Comforthuse.Models;
using EmployeeGUI.ViewModels.Partial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComforthuseUserstoryTests
{
    [TestClass]
    public class TechnicalSpecificationViewModelTest
    {
    
        [TestMethod]
        public void CanRetrieveListOfTechnicalSpecifications()
        {
            List<TechnicalSpecification> tslist = new List<TechnicalSpecification>();
            TechnicalSpecification tspec1 = new TechnicalSpecification() { Description = "Spec1", Ticked = true };
            TechnicalSpecification tspec2 = new TechnicalSpecification() { Description = "Spec2", Ticked = false };
            TechnicalSpecification tspec3 = new TechnicalSpecification() { Description = "Spec3", Ticked = true };

            tslist.Add(tspec1);
            tslist.Add(tspec2);
            tslist.Add(tspec3);

            TechnicalSpecificationViewModel vm = new TechnicalSpecificationViewModel(tslist);

            Assert.AreEqual(vm.TechnicalSpecifications[0].Description, "Spec1");

            Assert.AreEqual(vm.TechnicalSpecifications[0].Ticked, true);
            Assert.AreEqual(vm.TechnicalSpecifications[1].Description, "Spec2");
            Assert.AreEqual(vm.TechnicalSpecifications[1].Ticked, false);
            Assert.AreEqual(vm.TechnicalSpecifications[2].Description, "Spec3");
            Assert.AreEqual(vm.TechnicalSpecifications[2].Ticked, true);
        }
        
    }
}
