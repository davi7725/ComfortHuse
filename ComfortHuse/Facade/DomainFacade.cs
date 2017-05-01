using System.Security.Cryptography.X509Certificates;
using Comforthuse.Utility;

namespace Comforthuse.Facade
{
    public class DomainFacade : IEmployeeFacade, IAdministratorFacade
    {
        
        ICaseRepository caseRep = new CaseRepository();

        public void CreateCase()
        {
        }

        public void GetCases()
        {
            caseRep.
        }
    }

    public interface IAdministratorFacade
    {
    }

    public interface IEmployeeFacade
    {
        void CreateCase();
        void GetCases();
    }
}
