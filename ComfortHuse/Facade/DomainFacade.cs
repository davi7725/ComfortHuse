using Comforthuse.Models;
using Comforthuse.Utility;
using System.Collections.Generic;

namespace Comforthuse.Facade
{
    public class DomainFacade : IEmployeeFacade, IAdministratorFacade
    {
        private readonly ICaseRepository _caseRep = CaseRepository.Instance;

        public ICase CreateCase()
        {
            return _caseRep.Create();
        }

        public List<ICase> GetAllCases()
        {
            return _caseRep.GetAllCases();
        }
    }

    public interface IAdministratorFacade
    {
    }

    public interface IEmployeeFacade
    {
        ICase CreateCase();
        List<ICase> GetAllCases();
    }
}
