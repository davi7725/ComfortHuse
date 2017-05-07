using Comforthuse.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ComforthuseUserstoryTests
{
    [TestClass]
    public class TechnicalSpecificationViewModelTest
    {
        //
        [TestMethod]
        public void CanRetrieveListOfTechnicalSpecifications()
        {
            TechnicalSpecificationViewModel vm = new TechnicalSpecificationViewModel();

            List<TechnicalSpecification> tslist = new List<TechnicalSpecification>();
            TechnicalSpecification tspec1 = new TechnicalSpecification();
            TechnicalSpecification tspec2 = new TechnicalSpecification();
            TechnicalSpecification tspec3 = new TechnicalSpecification();
            TechnicalSpecification tspec4 = new TechnicalSpecification();
            tslist.Add(tspec1);
            tslist.Add(tspec2);
            tslist.Add(tspec3);
        }
    }
}
