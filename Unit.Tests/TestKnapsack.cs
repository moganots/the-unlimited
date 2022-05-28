using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;

namespace Unit.Tests
{
    [TestClass]
    [DeploymentItem("knapsack-items.csv", "targetFolder")]
    public class TestKnapsack
    {
        
        readonly string filePath = @"targetFolder\knapsack-items.csv";
        int knapsackCapacity = 4000;
        ICsvFile csvFile;
        IKnapsack knapsack;

        [TestInitialize()]
        public void Test_Initialize_Knapsack_Constructor()
        {
            csvFile = new CsvFile(filePath);
            Assert.IsNotNull(csvFile);
            knapsack = new Knapsack(knapsackCapacity, csvFile);
            Assert.IsNotNull(knapsack);
        }
        [TestMethod]
        public void Test_Initialize_Knapsack_AddItems()
        {
            var items = knapsack.AddItems();
            Assert.IsNotNull(items);
        }
        [TestMethod]
        public void Test_Initialize_Knapsack_EmptyKnapsack()
        {
            Assert.IsTrue(knapsack.EmptyKnapsack());
        }
    }
}
