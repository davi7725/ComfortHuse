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

        private CaseRepository()
        {
            instanciateMockCases();
        }

        public static CaseRepository Instance
        {
            get
            {
                if (_instance == null) _instance = new CaseRepository();
                return _instance;
            }
        }

        private void instanciateMockCases()
        {

            var li = new List<ICase>()
                {
                    new Case(ObjectFactory.Instance.InstanciateEmptyExpenseCategories())
                    {
                        CaseNumber = 1,
                        AmountOfRevisions = 1,
                        DateOfLastRevision = new DateTime(2017, 6, 18),
                        DateOfCreation = new DateTime(2017, 5, 18),
                        Customer =
                            new Customer("Jens", "Jensen", "abc@abc.com", "Odense", "Vollmose Allé 2", "5250",
                                "60606060", "")
                    },
                    new Case(ObjectFactory.Instance.InstanciateEmptyExpenseCategories())
                    {
                        CaseNumber = 1,
                        AmountOfRevisions = 1,
                        DateOfLastRevision = new DateTime(2017, 6, 18),
                        DateOfCreation = new DateTime(2017, 5, 18),
                        Customer =
                            new Customer("Jens", "Jensen", "abc@abc.com", "Odense", "Vollmose Allé 2", "5250",
                                "60606060", "60000")
                    },
                    new Case(ObjectFactory.Instance.InstanciateEmptyExpenseCategories())
                    {
                        CaseNumber = 2,
                        AmountOfRevisions = 2,
                        DateOfLastRevision = new DateTime(2017, 6, 18),
                        DateOfCreation = new DateTime(2017, 2, 18),
                        Customer =
                            new Customer("Sigurd", "Sigurdson", "abc@abc.com", "Fredericia", "Blåbærvænget 12", "3250",
                                "60606060", "")
                    },
                    new Case(ObjectFactory.Instance.InstanciateEmptyExpenseCategories())
                    {
                        CaseNumber = 3,
                        AmountOfRevisions = 4,
                        DateOfLastRevision = new DateTime(2017, 6, 18),
                        DateOfCreation = new DateTime(2017, 1, 18),
                        Customer =
                            new Customer("Magnus", "Magnusen", "abc@abc.com", "Århus", "Rønnebærvænget 14", "3250",
                                "60606060", "")
                    },
                    new Case(ObjectFactory.Instance.InstanciateEmptyExpenseCategories())
                    {
                        CaseNumber = 2,
                        AmountOfRevisions = 2,
                        DateOfLastRevision = new DateTime(2017, 6, 18),
                        DateOfCreation = new DateTime(2017, 2, 18),
                        Customer =
                            new Customer("Sigurd", "Sigurdson", "abc@abc.com", "Fredericia", "Blåbærvænget 12", "3250",
                                "60606060", "")
                    },
                    new Case(ObjectFactory.Instance.InstanciateEmptyExpenseCategories())
                    {
                        CaseNumber = 3,
                        AmountOfRevisions = 4,
                        DateOfLastRevision = new DateTime(2017, 6, 18),
                        DateOfCreation = new DateTime(2017, 1, 18),
                        Customer =
                            new Customer("Magnus", "Magnusen", "abc@abc.com", "Århus", "Rønnebærvænget 14", "3250",
                                "60606060", "")
                    }
                };

            _cases = li;
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


        private int GetNextId()
        {
            // return _db.GetNextCaseId();
            return 1;
        }

        public List<ICase> GetAllCases()
        {

            _cases = _db.GetAllCases();
            if (_cases.Count <= 0)
            {
                throw new Exception("The list is empty");
            }
            return _cases;
        }

        public bool Save(ICase obj)
        {
            obj.RegisterRevision();
            return _db.SaveCase(obj);
        }

        public void Clear()
        {
            _cases.Clear();
        }

    }
}
