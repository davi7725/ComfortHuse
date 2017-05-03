using Comforthuse.Models;
using System.Collections.Generic;

namespace Comforthuse.Utility
{
    public interface ICaseRepository
    {
        ICase Load(int caseId);
        int Create();
        void Save(int caseId);
        void Save(ICase obj);
        List<ICase> GetAllCases();
        void Add(ICase caseObj);
    }
}