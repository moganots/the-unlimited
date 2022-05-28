using Common;
using Interfaces;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Defines the properties, methods, structure and syntax for handling a Knapsack and its contents
    /// </summary>
    public class Knapsack : IKnapsack
    {
        #region Internal Properties
        /// <summary>
        /// Gets or Sets the maximum weight for the Knapsack
        /// </summary>
        public int MaximumWeight { get; set; }
        /// <summary>
        /// Gets or Sets the potential items to be placed inside the Knapsack
        /// </summary>
        public List<IKnapsackItem> KnapsackItems { get; set; }
        /// <summary>
        /// Gets or Sets the contents / items in the Knapsack
        /// </summary>
        public List<IKnapsackItem> KnapsackContents { get; set; }
        /// <summary>
        /// Gets the current total weight of Knapsack contents / items
        /// </summary>
        public int TotalWeight => KnapsackContents.Sum(knapsackItem => knapsackItem.Weight);
        #endregion Internal Properties

        #region Constructor Methods
        /// <summary>
        /// Instatiates a default instance of a Knapsack
        /// </summary>
        public Knapsack()
        {
            KnapsackItems = new List<IKnapsackItem>();
            KnapsackContents = new List<IKnapsackItem>();
        }
        /// <summary>
        /// Instatiates a default instance of a Knapsack, setting the specified maximum weight
        /// </summary>
        /// <param name="maximumWeight">the maximum weight of the Knapsack</param>
        public Knapsack(int maximumWeight) : this()
        {
            MaximumWeight = maximumWeight;
        }
        /// <summary>
        /// Instatiates a default instance of a Knapsack, setting the specified maximum weight and list of items to be added
        /// </summary>
        /// <param name="maximumWeight">the capacity of the Knapsack</param>
        /// <param name="knapsackItems">the list of items to be added to the Knapsack</param>
        public Knapsack(int maximumWeight, List<IKnapsackItem> knapsackItems) : this(maximumWeight)
        {
            KnapsackItems = knapsackItems;
        }
        /// <summary>
        /// Instatiates an instance of a Knapsack, setting the specified maximum weight and using input from the specified file object
        /// </summary>
        /// <param name="maximumWeight">the capacity of the Knapsack</param>
        /// <param name="csvFile">The file object with data to be used</param>
        public Knapsack(int maximumWeight, ICsvFile csvFile) : this(maximumWeight)
        {
            var contents = csvFile.ReadAllLines().Skip(1);
            KnapsackItems = contents.Select(item => new KnapsackItem(item)).ToList<IKnapsackItem>();
        }
        #endregion Constructor Methods

        #region Internal Methods
        /// <summary>
        /// Adds items to the Knapsack, returns the list of added / selected Knapsack items
        /// </summary>
        /// <returns>List<IKnapsackItem></returns>
        public List<IKnapsackItem> AddItems()
        {
            try
            {
                // Check that the list of predefined Knapsack items to select from is set
                if (Helpers.HasItems(KnapsackItems))
                {
                    // Iterate, throuh the list of predefined Knapsack items
                    // Check and Compare which item(s) can be selected and added to the contents of the Knapsack
                    foreach(IKnapsackItem knapsackItem in SelectedItems(KnapsackItems))
                    {
                        AddItem(knapsackItem);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
            finally { }
            return KnapsackContents;
        }

        /// <summary>
        /// Returns of items that can be added to the Knapsack
        /// </summary>
        /// <param name="knapsackItems">the list of Knapsack items to select from</param>
        /// <returns>IEnumerable<IKnapsackItem></returns>
        private IEnumerable<IKnapsackItem> SelectedItems(List<IKnapsackItem> knapsackItems)
        {
            List<IKnapsackItem> selectedItems = new List<IKnapsackItem>();
            try
            {
                // Iterate, through each item in the possible Knapsack item list
                for (int index = 0; index < knapsackItems.Count; index++)
                {
                    int indexToAdd = -1;
                    // If, we are only still starting out i.e. beginning of the loop
                    // Then add the first item to the list
                    if (index == 0)
                    {
                        selectedItems.Add(knapsackItems[index]);
                    }
                    // If, we are not starting out i.e. in the middle or close to the end of the loop
                    // We need to now recursively compare and find the next Knapsack item(s) that can be added to the selected list of Knapsack items
                    if(index > 0)
                    {
                        if (!CanAddAsNextKnaspackItem(knapsackItems, index, selectedItems, selectedItems.Count - 1, ref indexToAdd))
                        {
                            selectedItems.Add(knapsackItems[index]);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
            finally { }
            return selectedItems;
        }

        /// <summary>
        /// Checks and compares if items in the Knapsack item list can be added to the selected Knapsack item list recursively
        /// </summary>
        /// <param name="knapsackItems">the list of predefined Knapsack items</param>
        /// <param name="index">the current index of the Knapsack item being processed</param>
        /// <param name="selectedItems">the list of already selected Knapsack items</param>
        /// <param name="lastBoundItem">the index of the last added / bound or selected Knapsack item</param>
        /// <param name="indexToAdd">the index of the next item to add to the selected items Knapsack list</param>
        /// <returns>bool</returns>
        private bool CanAddAsNextKnaspackItem(List<IKnapsackItem> knapsackItems, int index, List<IKnapsackItem> selectedItems, int lastBoundItem, ref int indexToAdd)
        {
            if (!(lastBoundItem < 0))
            {
                // If, we get in here i.e. there are items already in the selected Knapsack list
                // Compare the current and last selected Knapsack items based on their Weight and Value to see which item should be added or replaced in the list
                if (knapsackItems[index].DiffWeightValue < selectedItems[lastBoundItem].DiffWeightValue)
                {
                    // Swap out the last item added / selected
                    indexToAdd = lastBoundItem;
                }
                // Lets go back in and compare and get any other item(s)
                return CanAddAsNextKnaspackItem(knapsackItems, index, selectedItems, lastBoundItem, ref indexToAdd);
            }
            if (indexToAdd > -1)
            {
                // Add the newly selected item to the list
                selectedItems.Insert(indexToAdd, knapsackItems[index]);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds the specified Knapsack item to the list of selected Knapsack items
        /// </summary>
        /// <param name="knapsackItem">the Knapsack item to add</param>
        private void AddItem(IKnapsackItem knapsackItem)
        {
            if ((TotalWeight + knapsackItem.Weight) <= MaximumWeight)
            {
                KnapsackContents.Add(knapsackItem);
            }
        }

        /// <summary>
        /// Empties the Knapsack / Removes all items added to the Knapsack
        /// Returns true if the Knapsack is emptied successfully, false if otherwise
        /// </summary>
        /// <returns>bool</returns>
        public bool EmptyKnapsack()
        {
            KnapsackContents.Clear();
            return KnapsackContents.Count() == 0;
        }
        #endregion Internal Methods

        #region IEnumerator Methods
        IEnumerator<IKnapsackItem> IEnumerable<IKnapsackItem>.GetEnumerator()
        {
            foreach(IKnapsackItem knapsackItem in KnapsackContents)
            {
                yield return knapsackItem;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return KnapsackContents.GetEnumerator();
        }
        #endregion IEnumerator Methods
    }
}
