using System;
using System.Collections.Generic;
using Comforthuse.Database;
using Comforthuse.Models;

namespace Comforthuse.Utility
{
    public class CaseRepository : ICaseRepository
    {
        private readonly List<ICase> _cases = new List<ICase>();

        IDbEmployee _db = new DatabaseFacade();
        private List<ICase> _currentCases;

        public CaseRepository()
        {
         
        }

        public void Load(int caseID)
        {
            
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
           Add(newCase);
        }

        private int GetNextId()
        {
           // return _db.GetNextCaseId();
            return 1;
        }

        public List<ICase> GetAllCases()
        {
            /*
            if(_cases.Count > 0)
            {
                return _cases;
            }
            else
            {
                throw new Exception("The list is empty");
            }
            */
            List<ICase> li = new List<ICase>()
            {
                new Case(){CaseNumber = 1, Customer = new Customer("Jens", "Jensen", "Odense", "Vollmose Allé 12", "5250", "60606060","","","")},
                new Case(){CaseNumber = 2, Customer = new Customer("Sigurd", "Sigurdson", "Fredericia", "Blåbærvænget 12", "3250", "60606060","","","")}
            };

            return li;
        }
    }
}
