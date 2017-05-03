using Comforthuse.Models;
using System;
using System.Collections.Generic;

namespace Comforthuse.Database
{
    internal class DatabaseController : IDbAdmin, IDbEmployee
    {

        private static DatabaseController _instance = null;

        private DatabaseController() { }

        public static DatabaseController Instance
        {
            get
            {
                if (_instance == null) _instance = new DatabaseController();
                return _instance;
            }
        }

        public void InsertCase()
        {
            try
            {
                // do implementation
            }
            catch
            {
                throw new SystemException("Connection issue");
            }
        }

        public List<ICase> GetAllCases()
        {
            List<ICase> list = new List<ICase>();

            return list;
        }

        public int GetNextCaseId()
        {
            return 1;

        }

        public ICase GetCase(int caseId)
        {
            throw new System.NotImplementedException();
        }

        public void SaveCase(ICase @case)
        {
            throw new System.NotImplementedException();
        }
    }
}
