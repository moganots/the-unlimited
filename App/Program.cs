using Common;
using Interfaces;
using Models;
using System;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"knapsack-items.csv";
            int knapsackCapacity = 4000;
            ICsvFile csvFile;
            IKnapsack knapsack;

            try
            {
                csvFile = new CsvFile(filePath);
                knapsack = new Knapsack(knapsackCapacity, csvFile);
                var items = knapsack.AddItems();
                if (Helpers.HasItems(items))
                {
                    Console.WriteLine("The following item(s) can be added / selected into the Knapsack:");
                    foreach (IKnapsackItem knapsackItem in items)
                    {
                        Console.WriteLine(knapsackItem.ToString());
                    }
                }
                Console.WriteLine("\r\nPress any key to Exit...");
                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
            finally { }
        }
    }
}
