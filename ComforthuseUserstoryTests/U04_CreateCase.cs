using Comforthuse.Facade;
using Comforthuse.Models;
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
            // Arrange
            ObjectFactory objectFactory = new ObjectFactory();

            // Act
            ICase thiscase = objectFactory.CreateNewCase();

            // Assert
            Assert.AreEqual(0, thiscase.CaseNumber);
        }

        [TestMethod]
        public void CaseRepositoryCanCreateCase()
        {
            // Arrange
            ICaseRepository cr = CaseRepository.Instance;

            // Act
            ICase thiscase = cr.Create();

            // Assert
            Assert.AreEqual(0, thiscase.CaseNumber);
        }


        /*
        [TestMethod]
        public void CaseRepositoryCanAssignLocalCaseId
        {

        }
        */

        [TestMethod]
        public void CaseRepositoryCanAddCaseToListOfCurrentLocalCases()
        {
            // Arrange
            ICaseRepository cr = CaseRepository.Instance;

            // Act
            ICase thiscase = cr.Create();

            // Assert
            Assert.AreEqual(0, thiscase.CaseNumber);
        }


        // Integration test
        [TestMethod]
        public void EmployeeCanCreateNewCase()
        {
            // Arrange
            IEmployeeFacade facade = new DomainFacade();

            // Act 
            ICase thiscase = facade.CreateCase();

            // Assert
            Assert.AreEqual(0, thiscase.CaseNumber);
        }
    }
}
