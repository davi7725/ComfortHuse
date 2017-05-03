using Comforthuse.Models;
using Comforthuse.Utility;
using System.Collections.Generic;

namespace Comforthuse.Facade
{
    public class DomainFacade : IEmployeeFacade, IAdministratorFacade
    {
        private readonly ICaseRepository _caseRep = CaseRepository.Instance;

        public int CreateCase()
        {
            return _caseRep.Create();
        }

        List<ICase> IEmployeeFacade.GetAllCases()
        {
            return _caseRep.GetAllCases();
        }
    }

    public interface IAdministratorFacade
    {
    }

    public interface IEmployeeFacade
    {
        int CreateCase();
        List<ICase> GetAllCases();
    }
}
