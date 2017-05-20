using Comforthuse.Models;
using Comforthuse.Utility;
using System.Collections.Generic;

namespace Comforthuse.Facade
{
    public class DomainFacade : IEmployeeFacade, IAdministratorFacade
    {
        private ICaseRepository _caseRep = CaseRepository.Instance;
        private IEmployeeRepository _employeeRep = EmployeeRepository.Instance;

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

        public void GetAllProductTypes()
        {
            ProductTypeRepository.Instance.GetProductTypes();
        }

        public void GetAllProductOptions()
        {
            ProductOptionRepository.Instance.GetProductOptions();
        }
    }

    public interface IAdministratorFacade
    {
    }

    public interface IEmployeeFacade
    {
        ICase CreateCase();
        void GetAllProductOptions();
        List<ICase> GetAllCases();
        List<IEmployee> GetAllEmployees();
        void GetAllProductTypes();
    }
}
