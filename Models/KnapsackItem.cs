using Common;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Defines the properties, methods, structure and syntax for handling a Knapsack item
    /// </summary>
    public class KnapsackItem : IKnapsackItem
    {
        #region Internal Properties
        /// <summary>
        /// Gets or Sets the name of the Knapsack item
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or Sets the weight of the Knapsack item
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// Gets or Sets the value of the Knapsack item
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// Gets the difference of the Weight from the Value i.e. what is the importance / signifance of this item
        /// </summary>
        public int DiffWeightValue => Weight - Value;
        public override string ToString()
        {
            return $"Name: {Name}, Value: {Value}, Weight: {Weight}";
        }
        #endregion Internal Properties

        #region Constructor Methods
        /// <summary>
        /// Instantiates a new instance of a Knapsack item
        /// </summary>
        public KnapsackItem() { }
        /// <summary>
        /// Instantiates a new instance of a Knapsack item, using the details from the specified item and delimiter
        /// </summary>
        /// <param name="item">the Knapsack item to be used</param>
        /// <param name="delimiter">the delimiter</param>
        public KnapsackItem(string item, string delimiter = ","): this()
        {
            if (Helpers.IsSet(item))
            {
                Name = item.Split(delimiter)[0];
                Weight = Helpers.ToInt32(item.Split(delimiter)[1]);
                Value = Helpers.ToInt32(item.Split(delimiter)[2]);
            }
        }
        #endregion Constructor Methods
    }
}
