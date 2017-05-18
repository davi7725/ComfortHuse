using Comforthuse.Models;
using Comforthuse.Utility;
using System.Collections.Generic;

namespace Comforthuse.Facade
{
    public class DomainFacade : IEmployeeFacade, IAdministratorFacade
    {
        private ICaseRepository _caseRep = CaseRepository.Instance;
        private IEmployeeRepository _employeeRep = new EmployeeRepository();

        public ICase CreateCase()
        {
            return _caseRep.Create();
        }

        public List<ICase> GetAllCases()
        {
            return _caseRep.GetAllCases();
        }

        public List<IEmployee> GetAllEmployees()
        {
            return _employeeRep.GetAllEmployee();
        }
    }

    public interface IAdministratorFacade
    {
    }

    public interface IEmployeeFacade
    {
        ICase CreateCase();
        List<ICase> GetAllCases();
        List<IEmployee> GetAllEmployees();
    }
}
