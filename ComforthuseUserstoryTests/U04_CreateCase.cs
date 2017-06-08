using Comforthuse.Facade;
using Comforthuse.Interfaces;
using Comforthuse.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ComforthuseUserstoryTests
{
    [TestClass]
    public class UC04CreateCase
    {

        [TestMethod]
        public void ObjectFactoryCanCreateNewCase()
        {


            ObjectFactory objectFactory = ObjectFactory.Instance;

            ICase thiscase = objectFactory.CreateNewCase();

            Assert.AreEqual(0, thiscase.CaseNumber);
        }



        [TestMethod]
        public void CaseRepositoryCanCreateCase()
        {

            ICaseRepository cr = CaseRepository.Instance;

            ICase thiscase = cr.Create();

            Assert.AreEqual(0, thiscase.CaseNumber);
        }

        // Integration test
        [TestMethod]
        public void EmployeeCanCreateNewCase()
        {

            IEmployeeFacade facade = new DomainFacade();

            ICase thiscase = facade.CreateCase();

            Assert.AreEqual(0, thiscase.CaseNumber);
        }
    }
}
