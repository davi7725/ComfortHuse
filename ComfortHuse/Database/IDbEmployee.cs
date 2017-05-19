using Comforthuse.Models;
using System.Collections.Generic;

namespace Comforthuse.Database
{
    public interface IDbEmployee
    {
        void InsertCase(ICase c, string customerEmail, int moneyInstituteId, string employeeEmail, int plotId, int imageId);
        List<ICase> GetAllCases();
        int GetNextCaseId();
        ICase GetCase(int caseId);
        bool SaveCase(ICase @case);
        List<ICustomer> GetAllCustomersByName();
        void SearchForCustomer(string query);
    }
}
