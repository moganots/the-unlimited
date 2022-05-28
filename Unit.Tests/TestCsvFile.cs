using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;

namespace Unit.Tests
{
    [TestClass]
    [DeploymentItem("knapsack-items.csv", "targetFolder")]
    public class TestCsvFile
    {        
        readonly string filePath = @"targetFolder\knapsack-items.csv";
        ICsvFile csvFile;

        /*
        [TestInitialize]
        public void Test_Initialize_CsvFile_DefaultConstructor()
        {
            customFile = new CsvFile();
            Assert.IsNotNull(customFile, @"Test_Initialize_CsvFile_DefaultConstructor(), passed");
        }
        */
        [TestInitialize()]
        public void Test_Initialize_CsvFile_ConstructorWithFilePath()
        {
            csvFile = new CsvFile(filePath);
            Assert.IsNotNull(csvFile);
        }
        [TestMethod]
        public void Test_Initialize_CsvFile_FileExists()
        {            
            Assert.IsTrue(csvFile.FileExists());
        }
        [TestMethod]
        public void Test_Initialize_CsvFile_FileInUse()
        {
            Assert.IsFalse(csvFile.FileInUse());
        }
        [TestMethod]
        public void Test_Initialize_CsvFile_ReadAllText()
        {
            Assert.IsNotNull(csvFile.ReadAllText());
        }
        [TestMethod]
        public void Test_Initialize_CsvFile_ReadAllLines()
        {
            Assert.IsNotNull(csvFile.ReadAllLines());
        }
    }
}
