using Comforthuse.Database;
using System.Collections.Generic;

namespace Comforthuse.Utility
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private IDbEmployee _db = DatabaseController.Instance;
        private List<IEmployee> _employees = new List<IEmployee>();
        public List<IEmployee> GetAllEmployee()
        {
            return _employees;
        }
        public void Add(IEmployee employee)
        {
            _employees.Add(employee);
        }

        public EmployeeRepository()
        {
            _employees = InstanciateMockObjects();
        }

        private List<IEmployee> InstanciateMockObjects()
        {

            return new List<IEmployee>()
            {
                new Employee("Alexander", "Hvidt", "alexander2341@gmail.com", "60669041"),
                new Employee("Reno", "Rubar", "reno@gmail.com", "41241414"),
                new Employee("Darius", "Vasili", "darius@gmail.com", "41414141")
            };
        }
    }

    public interface IEmployeeRepository
    {
        List<IEmployee> GetAllEmployee();
        void Add(IEmployee employee);
    }
}
