﻿using Comforthuse.Database;
using Comforthuse.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Comforthuse.Utility
{
    public class CaseRepository : ICaseRepository
    {

        private static CaseRepository _instance;
        public static CaseRepository Instance
        {
            get
            {
                if (_instance == null) _instance = new CaseRepository();
                return _instance;
            }
        }

        private List<ICase> _cases = new List<ICase>();
        private IDbEmployee _db = DatabaseController.Instance;
        private List<ICase> _currentCases = new List<ICase>();


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
            /*
            if (_cases.Count > 0)
            {
                _db.GetAllCases();
            }
            else
            {
                throw new Exception("The list is empty");
            }
            */
            var li = new List<ICase>()
            {
                new Case(){CaseNumber = 1, AmountOfRevisions = 1, HouseType = "HouseType A", DateOfLastRevision = new DateTime(2017, 6, 18),DateOfCreation = new DateTime(2017, 5, 18),
                    Customer = new Customer("Jens", "Jensen","abc@abc.com", "Odense", "Vollmose Allé 2", "5250", "60606060","")},
                new Case(){CaseNumber = 2, AmountOfRevisions = 2,HouseType = "HouseType B", DateOfLastRevision = new DateTime(2017, 6, 18), DateOfCreation = new DateTime(2017, 2, 18),Customer = new Customer("Sigurd", "Sigurdson","abc@abc.com", "Fredericia", "Blåbærvænget 12", "3250", "60606060","")},
                new Case(){CaseNumber = 3, AmountOfRevisions = 4,HouseType = "HouseType A", DateOfLastRevision = new DateTime(2017, 6, 18), DateOfCreation = new DateTime(2017, 1, 18),Customer = new Customer("Magnus", "Magnusen","abc@abc.com", "Århus", "Rønnebærvænget 14", "3250", "60606060","")}
            };

            return li;
        }

        public void Save(ICase obj)
        {
            _db.SaveCase(obj);
        }

    }
}
