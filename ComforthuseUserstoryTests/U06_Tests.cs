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
            ICaseRepository caseRepository = new CaseRepository();

            caseRepository.Add(new Case());
            caseRepository.Add(new Case());

            List<ICase> listOfCases = caseRepository.GetAllCases();

            Assert.IsTrue(listOfCases.Count > 0);


        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CaseListIsEmpty()
        {
            ICaseRepository caseRepository = new CaseRepository();

            List<ICase> listOfCases = caseRepository.GetAllCases();
        }

        [TestMethod]
        public void CheckIfListHasCorrectNumberOfCases()
        {

            ICaseRepository caseRepository = new CaseRepository();

            caseRepository.Add(new Case());
            caseRepository.Add(new Case());
            caseRepository.Add(new Case());

            List<ICase> listOfCases = caseRepository.GetAllCases();

            Assert.AreEqual(3, listOfCases.Count);
        }

    }
}
