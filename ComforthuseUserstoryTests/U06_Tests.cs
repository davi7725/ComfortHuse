using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comforthuse.Utility;
using Comforthuse.Models;

namespace ComforthuseUserstoryTests
{
    [TestClass]
    public class U06_Tests
    {
        [TestMethod]
        public void CaseListIsNotEmpty()
        {
            CaseRepository caseRepository = new CaseRepository();

            caseRepository.Add(new Case());
            caseRepository.Add(new Case());

            List<Case> listOfCases = caseRepository.GetListOfCases();

            Assert.IsTrue(listOfCases.Count > 0);


        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CaseListIsEmpty()
        {
            CaseRepository caseRepository = new CaseRepository();

            List<Case> listOfCases = caseRepository.GetListOfCases();
        }

        [TestMethod]
        public void CheckIfListHasCorrectNumberOfCases()
        {

            CaseRepository caseRepository = new CaseRepository();

            caseRepository.Add(new Case());
            caseRepository.Add(new Case());
            caseRepository.Add(new Case());

            List<Case> listOfCases = caseRepository.GetListOfCases();

            Assert.AreEqual(3, listOfCases.Count);
        }

    }
}
