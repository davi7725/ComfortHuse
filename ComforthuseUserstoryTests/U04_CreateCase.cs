using Comforthuse.Facade;
using Comforthuse.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ComforthuseUserstoryTests
{
    [TestClass]
    public class UC04_CreateCase
    {

        [TestMethod]
        public void CreateCaseWillReturnId()
        {
            // Arrange
            ICaseRepository caseRep = new CaseRepository();
            DomainFacade df = new DomainFacade(caseRep);



            // Act
            int id = df.CreateCase();
            


            // Assert

            AssertAreEqual(id, 1);

        }

        [TestMethod]
        public void CreateCaseUnsuccessful()
        {
            // Arrange

            // Act 

            // Assert
        }


        [TestMethod]
        public void GetCase()
        {
            // Arrange

            // Act 

            // Assert

        }
    }
}
