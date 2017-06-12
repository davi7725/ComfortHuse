using Comforthuse;
using Comforthuse.Facade;
using Comforthuse.Models;
using Comforthuse.Utility;
using EmployeeGUI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Comforthuse.Interfaces;

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
            IEmployee employee = new Employee("Alexander", "Hvidt", "alexander2341@gmail.com", "60669041");

            //Then  
            Assert.AreEqual("[FirstName=Alexander,LastName=Hvidt,PhoneNumber=60669041,Email=alexander2341@gmail.com]", employee.ToString());

        }

        [TestMethod]
        public void GetAllEmployees()
        {
            //Given
            IEmployee employee = new Employee("Alan", "Boje", "ab@comforthuse.dk", "24813540");
            IEmployeeRepository empRepo = EmployeeRepository.Instance;

            //When
            empRepo.Add(employee);
            int count = empRepo.GetAllEmployee().Count;
            IEmployee e = empRepo.GetAllEmployee()[count - 1];

            //Then
            Assert.AreEqual("[FirstName=Alan,LastName=Boje,PhoneNumber=24813540,Email=ab@comforthuse.dk]", e.ToString());
        }

        [TestMethod]
        public void SetAndGetEmployeeOnCase()
        {
            //Given
            IEmployee employee = new Employee("Alan", "Boje", "ab@comforthuse.dk", "24813540");
            ICase c = ObjectFactory.Instance.CreateNewCase();

            //Then
            c.Employee = employee;
            IEmployee e = c.Employee;

            //When
            Assert.AreEqual(c.Employee.ToString(), e.ToString());
        }

        [TestMethod]
        public void SetAndGetEmployeeThroughCaseViewModel()
        {
            //Given
            IEmployee employee = new Employee("Alan", "Boje", "ab@comforthuse.dk", "24813540");
            ICase c = ObjectFactory.Instance.CreateNewCase();
            c.Employee = employee;
            CaseViewModel vm = new CaseViewModel();
            vm.Case = c;

            //Then
            IEmployee e = vm.Employee;


            //When
            Assert.AreEqual(employee.ToString(), e.ToString());
        }

        [TestMethod]
        public void GetAllEmployeesThroughCaseViewModel()
        {
            //Given
            IEmployee employee = ObjectFactory.Instance.CreateEmployee("Alexander", "Hvidt", "alexander2341@gmail.com", "60669041");
            IEmployeeRepository empRepo = EmployeeRepository.Instance;
            ICase c = ObjectFactory.Instance.CreateNewCase();
            CaseViewModel vm = new CaseViewModel();
            vm.Facade = new DomainFacade();

            vm.Case = c;

            //When
            empRepo.Add(employee);
            vm.Case = c;
            List<IEmployee> employees = vm.Employees;

            //Then
            Assert.AreEqual("[FirstName=Alan,LastName=Boje,PhoneNumber=24813540,Email=ab@comforthuse.dk]", employees[0].ToString());
        }


    }
}
