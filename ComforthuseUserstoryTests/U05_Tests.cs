using System;
using Comforthuse.Utility;
using Comforthuse.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComforthuseUserstoryTests
{
    [TestClass]
    public class U05_Tests
    {
        [TestMethod]
        public void CanLoadACaseFromCaseRepository()
        {

            Case case1 = new Case();
            case1.CaseNumber = 1;
            Case case2 = new Case();
            case2.CaseNumber = 2;

            CaseRepository cr = CaseRepository.Instance;

            cr.Add(case1);
            cr.Add(case2);


            ICase case1Loaded = cr.Load(1);
            ICase case2Loaded = cr.Load(2);


            Assert.IsTrue(case1.Equals(case1Loaded));
            Assert.IsTrue(case2.Equals(case2Loaded));
            Assert.IsFalse(case2.Equals(case1Loaded));
        }
    }
}
