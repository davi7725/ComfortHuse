using Comforthuse.Models;
using System;
using System.Collections.Generic;

namespace Comforthuse.Database
{
    public class DatabaseController : IDbAdmin, IDbEmployee
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

        public void SaveCase(ICase c)
        {
            throw new System.NotImplementedException();
        }

        public List<ICustomer> GetAllCustomersByName()
        {
            throw new NotImplementedException();
        }

        public void SearchForCustomer(string query)
        {
            throw new NotImplementedException();
        }
    }
}
