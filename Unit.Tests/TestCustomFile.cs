using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;

namespace Unit.Tests
{
    [TestClass]
    [DeploymentItem("knapsack-items.csv", "targetFolder")]
    public class TestCustomFile
    {
        
        readonly string filePath = @"targetFolder\knapsack-items.csv";
        ICustomFile customFile;

        /*
        [TestInitialize]
        public void Test_Initialize_CustomFile_DefaultConstructor()
        {
            customFile = new CsvFile();
            Assert.IsNotNull(customFile, @"Test_Initialize_CustomFile_DefaultConstructor(), passed");
        }
        */
        [TestInitialize()]
        public void Test_Initialize_CustomFile_ConstructorWithFilePath()
        {
            customFile = new CustomFile(filePath);
            Assert.IsNotNull(customFile);
        }
        [TestMethod]
        public void Test_Initialize_CustomFile_FileExists()
        {            
            Assert.IsTrue(customFile.FileExists());
        }
        [TestMethod]
        public void Test_Initialize_CustomFile_FileInUse()
        {
            Assert.IsFalse(customFile.FileInUse());
        }
        [TestMethod]
        public void Test_Initialize_CustomFile_ReadAllText()
        {
            Assert.IsNotNull(customFile.ReadAllText());
        }
        [TestMethod]
        public void Test_Initialize_CustomFile_ReadAllLines()
        {
            Assert.IsNotNull(customFile.ReadAllLines());
        }
    }
}
