using Comforthuse.Models;
using System.Collections.Generic;

namespace Comforthuse.Database
{
    public interface IDbEmployee
    {
        void InsertCase();
        List<ICase> GetAllCases();
        int GetNextCaseId();
        ICase GetCase(int caseId);
        void SaveCase(ICase @case);
    }
}
