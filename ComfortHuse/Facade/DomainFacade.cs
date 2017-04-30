using System.Security.Cryptography.X509Certificates;

namespace Comforthuse.Facade
{
    public class DomainFacade : IEmployeeFacade, IAdministratorFacade
    {
        public void CreateCase()
        {
            
        }
    }

    public interface IAdministratorFacade
    {
    }

    public interface IEmployeeFacade
    {
        void CreateCase();
    }
}
