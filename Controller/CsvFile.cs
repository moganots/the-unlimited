using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Contains the properties, methods, structure and syntax for handling a CSV file
    /// </summary>
    public class CsvFile : CustomFile, ICsvFile
    {
        #region Internal Methods
        /// <summary>
        /// Gets or Sets the contents with the first line item removed
        /// </summary>
        public string[] ContentsWithoutFirstLineItem { get; set; }
        #endregion Internal Methods

        #region Constructor
        /// <summary>
        /// Instantiates an instance of the CustomFile
        /// </summary>
        public CsvFile() :base(){ }
        /// <summary>
        /// Instantiates an instance of the CsvFile, with the specified file path
        /// </summary>
        /// <param name="filePath">The fully qualified path to the Csv file</param>
        public CsvFile(string filePath) : base(filePath)
        {
        }
        #endregion Constructor
    }
}
