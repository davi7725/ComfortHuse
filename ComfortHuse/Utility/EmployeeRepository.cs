using System.Collections.Generic;

namespace Comforthuse.Utility
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<IEmployee> _employees = new List<IEmployee>();
        public List<IEmployee> GetAllEmployee()
        {
            return new List<IEmployee>() { new Employee("Allan", "Boeje", "d@d.dk", "60669041"), new Employee("Allan", "Heboe", "hb@d.com", "60890020") };
        }
    }

    public interface IEmployeeRepository
    {
        List<IEmployee> GetAllEmployee();
    }
}
