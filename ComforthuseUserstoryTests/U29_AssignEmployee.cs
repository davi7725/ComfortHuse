using Comforthuse;
using Comforthuse.Models;
using Comforthuse.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ComforthuseUserstoryTests
{
    /// <summary>
    /// Summary description for U29_AssignEmployee
    /// </summary>
    [TestClass]
    public class U29_AssignEmployee
    {
        [TestMethod]
        public void CreateNewEmployee()
        {
            //Given
            IEmployee employee2 = new Employee("Alexander", "Hvidt", "alexander2341@gmail.com", "60669041");

            //When
            IEmployee employee = ObjectFactory.Instance.CreateEmployee("Alexander", "Hvidt", "alexander2341@gmail.com", "60669041");

            //Then  
            Assert.AreEqual("[FirstName=Alexander,LastName=Hvidt,PhoneNumber=60669041,Email=alexander2341@gmail.com]", employee.ToString());
            Assert.AreEqual(true, employee2.Equals(employee));

        }

        [TestMethod]
        public void GetAllEmployees()
        {
            //Given
            IEmployee employee = ObjectFactory.Instance.CreateEmployee("Alexander", "Hvidt", "alexander2341@gmail.com", "60669041");
            IEmployeeRepository empRepo = new EmployeeRepository();

            //When
            empRepo.Add(employee);
            List<IEmployee> employees = empRepo.GetAllEmployee();

            //Then
            Assert.AreEqual(true, employees[0].Equals(employee));
        }

        public void SetAndGetEmployeeOnCase()
        {
            //Given
            IEmployee employee = new Employee("Alexander", "Hvidt", "alexander2341@gmail.com", "60669041");
            ICase c = ObjectFactory.Instance.CreateNewCase();

            //Then
            c.Employee = employee;

            //When
            Assert.AreEqual(c.Employee.Equals(employee), true);
        }
    }
}
