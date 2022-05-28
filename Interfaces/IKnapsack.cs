using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// Defines the properties, methods, structure and syntax for handling a Knapsack and its contents
    /// </summary>
    public interface IKnapsack:IEnumerable<IKnapsackItem>
    {
        #region Internal Properties
        /// <summary>
        /// Gets or Sets the maximum weight for the Knapsack
        /// </summary>
        int MaximumWeight { get; set; }
        /// <summary>
        /// Gets or Sets the potential items to be placed inside the Knapsack
        /// </summary>
        public List<IKnapsackItem> KnapsackItems { get; set; }
        /// <summary>
        /// Gets or Sets the contents / items in the Knapsack
        /// </summary>
        List<IKnapsackItem> KnapsackContents { get; set; }
        /// <summary>
        /// Gets the current total weight of Knapsack contents / items
        /// </summary>
        int TotalWeight { get; }
        #endregion Internal Properties

        #region Internal Methods
        /// <summary>
        /// Adds items to the Knapsack, returns the list of added / selected Knapsack items
        /// </summary>
        /// <returns>List<IKnapsackItem></returns>
        List<IKnapsackItem> AddItems();
        /// <summary>
        /// Empties the Knapsack / Removes all items added to the Knapsack
        /// </summary>
        /// <returns>returns true if Knapsack is empty, false if otherwise</returns>
        bool EmptyKnapsack();
        #endregion Internal Methods
    }
}
