using Comforthuse.Models;
using Comforthuse.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ComforthuseUserstoryTests
{
    [TestClass]
    public class U06_Tests
    {
        [TestMethod]
        public void CaseListIsNotEmpty()
        {
            ICaseRepository caseRepository = CaseRepository.Instance;

            caseRepository.Add(new Case());
            caseRepository.Add(new Case());

            List<ICase> listOfCases = caseRepository.GetAllCases();

            Assert.IsTrue(listOfCases.Count > 0);


        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CaseListIsEmpty()
        {
            ICaseRepository caseRepository = CaseRepository.Instance;

            List<ICase> listOfCases = caseRepository.GetAllCases();
        }

        [TestMethod]
        public void CheckIfListHasCorrectNumberOfCases()
        {

            ICaseRepository caseRepository = CaseRepository.Instance;

            caseRepository.Add(new Case());
            caseRepository.Add(new Case());
            caseRepository.Add(new Case());

            List<ICase> listOfCases = caseRepository.GetAllCases();

            Assert.AreEqual(3, listOfCases.Count);
        }

    }
}
