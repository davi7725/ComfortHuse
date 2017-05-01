using System.Collections.Generic;
using Comforthuse.Models;

namespace Comforthuse.Utility
{
    public interface ICaseRepository
    {
        void Load();
        void Create();
        void Save();
        List<ICase> GetAllCases();
    }
}