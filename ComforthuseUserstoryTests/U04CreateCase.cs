﻿using Comforthuse.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Comforthuse.Models;
namespace ComforthuseUserstoryTests
{
    [TestClass]
    public class UC04CreateCase
    {
        
        [TestMethod]
        public void CreateCase()
        {
            // Arrange
            ICaseRepository caseRep = new CaseRepository();

            // Act
            caseRep.Create();

            // Assert
            //AssertAreEqual();

        }

        [TestMethod]
        public void CaseCreateFails()
        {
            // Arrange


            // Act 

            // Assert
        }


        [TestMethod]
        public void LoadCase()
        {
            // Arrange

            // Act 

            // Assert

        }
    }
}
