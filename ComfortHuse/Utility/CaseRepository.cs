using Comforthuse.Database;
using Comforthuse.Models;
using System;
using System.Collections.Generic;

namespace Comforthuse.Utility
{
    public class CaseRepository : ICaseRepository
    {

        private static CaseRepository _instance;
        private List<ICase> _cases = new List<ICase>();
        private IDbEmployee _db = DatabaseController.Instance;
        private List<ICase> _currentCases = new List<ICase>();

        public static CaseRepository Instance
        {
            get
            {
                if (_instance == null) _instance = new CaseRepository();
                return _instance;
            }
        }



        public void Add(ICase caseObj)
        {
            _cases.Add(caseObj);
        }

        public ICase Load(int caseId)
        {
            //return _db.GetCase(caseId);
            ICase loadedCase = null;

            foreach (ICase cs in _cases)
            {
                if (cs.CaseNumber == caseId)
                {
                    loadedCase = cs;
                }
            }

            if (loadedCase != null)
            {
                return loadedCase;
            }
            else
            {
                throw new Exception("Case not found");
            }

        }

        public ICase Create()
        {
            ICase newCase = ObjectFactory.Instance.CreateNewCase();
            _currentCases.Add(newCase);
            return newCase;
        }

        public void Save(int caseId)
        {

        }

        private int GetNextId()
        {
            // return _db.GetNextCaseId();
            return 1;
        }

        public List<ICase> GetAllCases()
        {
            if (_cases.Count > 0)
            {
                return _cases;
            }
            else
            {
                throw new Exception("The list is empty");
            }
        }

        public void Save(ICase obj)
        {
            _db.SaveCase(obj);
        }

        public void Clear()
        {
            _cases.Clear();
        }

    }
}
