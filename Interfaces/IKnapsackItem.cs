using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// Defines the properties, methods, structure and syntax for handling a Knapsack item
    /// </summary>
    public interface IKnapsackItem
    {
        #region Internal Properties
        /// <summary>
        /// Gets or Sets the name of the Knapsack item
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Gets or Sets the weight of the Knapsack item
        /// </summary>
        int Weight { get; set; }
        /// <summary>
        /// Gets or Sets the value of the Knapsack item
        /// </summary>
        int Value { get; set; }
        /// <summary>
        /// Gets the difference of the Weight from the Value i.e. what is the importance / signifance of this item
        /// </summary>
        int DiffWeightValue { get; }
        #endregion Internal Properties
    }
}
