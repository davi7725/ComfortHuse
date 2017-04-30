using System;
using System.Collections.Generic;
using Comforthuse.Database;
using Comforthuse.Models;

namespace Comforthuse.Utility
{
    public class CaseRepository : ICaseRepository
    {
        private List<Case> listOfCases = new List<Case>();
        IDbEmployee db = new DatabaseFacade();

        public CaseRepository()
        {
            //db.CreateCase();

        }

        public void Load()
        {

        }

        public void AddCase(Case caseObj)
        {
            listOfCases.Add(caseObj);
        }

        public bool Create()
        {
            return true;
           // throw new System.NotImplementedException();
        }

        public List<Case> GetListOfCases()
        {
            if(listOfCases.Count > 0)
            {
                return listOfCases;
            }
            else
            {
                throw new Exception("The list is empty");
            }
        }
    }
}
