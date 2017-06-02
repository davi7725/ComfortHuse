using Comforthuse.Models;
using System.Collections.Generic;

namespace Comforthuse.Database
{
    public interface IDbEmployee
    {
        int InsertCase(ICase c, string customerEmail, int moneyInstituteId, string employeeEmail, int plotId, int? imageId);
        List<ICase> GetAllCases();
        int GetNextCaseId();
        bool SaveCase(ICase @case);
        List<IEmployee> GetAllEmployees();
    }
}
