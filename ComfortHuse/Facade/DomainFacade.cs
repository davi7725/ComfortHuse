using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Comforthuse.Models;
using Comforthuse.Utility;

namespace Comforthuse.Facade
{
    public class DomainFacade : IEmployeeFacade, IAdministratorFacade
    {
        private readonly ICaseRepository _caseRep = new CaseRepository();

        public void CreateCase()
        {
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
        void CreateCase();
        List<ICase> GetAllCases();
    }
}
