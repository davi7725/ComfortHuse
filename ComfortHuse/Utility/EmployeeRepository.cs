using Comforthuse.Database;
using System.Collections.Generic;

namespace Comforthuse.Utility
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static EmployeeRepository _instance;
        private IDbEmployee _db = DatabaseController.Instance;
        private List<IEmployee> _employees = new List<IEmployee>();

        public static EmployeeRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmployeeRepository();
                }
                return _instance;
            }

        }

        public List<IEmployee> GetAllEmployee()
        {
            _employees = _db.GetAllEmployees();
            return _employees;
        }
        public void Add(IEmployee employee)
        {
            _employees.Add(employee);
        }

        private EmployeeRepository()
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

        public IEmployee Load(string email)
        {
            IEmployee employee = null;
            foreach (IEmployee emp in _employees)
            {
                if (emp.Email == email)
                {
                    employee = emp;
                }
            }
            return employee;
        }
    }

    public interface IEmployeeRepository
    {
        List<IEmployee> GetAllEmployee();
        void Add(IEmployee employee);
    }
}
