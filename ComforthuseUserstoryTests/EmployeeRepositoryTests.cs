using Comforthuse;
using Comforthuse.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComforthuseUserstoryTests
{
    /// <summary>
    /// Summary description for EmployeeRepositoryTests
    /// </summary>
    [TestClass]
    public class EmployeeRepositoryTests
    {
        [TestMethod]
        public void AddEmployees()
        {
            //Given
            IEmployee emp = ObjectFactory.Instance.CreateEmployee("Alexander", "Hvidt", "alexander2341@gmail.com", "60669040");
            IEmployee emp1 = ObjectFactory.Instance.CreateEmployee("Reno", "Rubar", "reno@gmail.com", "41241414");
            IEmployee emp3 = ObjectFactory.Instance.CreateEmployee("Darius", "Vasili", "darius@gmail.com", "41414141");
            IEmployeeRepository empRep = EmployeeRepository.Instance;
            //When 
            empRep.Add(emp);
            empRep.Add(emp1);
            empRep.Add(emp3);

            //Then
            Assert.AreEqual(empRep.GetAllEmployee().Count, 3);
        }
    }
}
