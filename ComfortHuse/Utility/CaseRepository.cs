using System;
using System.Collections.Generic;
using Comforthuse.Database;
using Comforthuse.Models;

namespace Comforthuse.Utility
{
    public class CaseRepository : ICaseRepository
    {
        private readonly List<ICase> _cases = new List<ICase>();
        private List<ICase> _currentCases = new List<ICase>();

        IDbEmployee _db = new DatabaseFacade();

        public ICase Load(int caseID)
        {

            throw new NotImplementedException();
        }

        public void Save(int caseId)
        {
            // Save
            throw new NotImplementedException();
        }


        public void Add(ICase caseObj)
        {
            _cases.Add(caseObj);
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Create()
        {
           ICase newCase = new Case(){CaseNumber = GetNextId()};
           _currentCases.Add(newCase);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        private int GetNextId()
        {
           // return _db.GetNextCaseId();
            return 1;
        }

        public List<ICase> GetAllCases()
        {
            
            if(_cases.Count > 0)
            {
                return _cases;
            }
            else
            {
                throw new Exception("The list is empty");
            }
        }

    }
}
