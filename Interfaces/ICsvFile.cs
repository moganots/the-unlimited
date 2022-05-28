using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// Contains the properties, methods, structure and syntax for handling a CSV file
    /// </summary>
    public interface ICsvFile : ICustomFile
    {
        #region Internal Methods
        /// <summary>
        /// Gets or Sets the contents with the first line item removed
        /// </summary>
        string[] ContentsWithoutFirstLineItem { get; set; }
        #endregion Internal Methods
    }
}
