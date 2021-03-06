﻿using Comforthuse.Models;
using System.Collections.Generic;
using Comforthuse.Interfaces;

namespace Comforthuse.Utility
{
    public interface ICaseRepository
    {
        ICase Load(int caseId);
        ICase Create();
        bool Save(ICase obj);
        List<ICase> GetAllCases();
        void Add(ICase caseObj);
    }
}