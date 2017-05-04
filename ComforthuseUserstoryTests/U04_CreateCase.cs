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

            //**Expand later once all the classes are done so it instanciate all expensecategory classes with preset options

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
            // Act
            ICaseRepository cr = CaseRepository.Instance;

            // Assert
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
