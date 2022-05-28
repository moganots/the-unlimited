using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// Defines the properties, methods, structure and syntax for handling a file and its contents
    /// </summary>
    public interface ICustomFile
    {
        #region Internal Properties
        /// <summary>
        /// Gets or Sets the fully qualified path of the file to be used
        /// </summary>
        string FilePath {get;set; }
        /// <summary>
        /// Gets or Sets the entire text contained in the file to be used
        /// </summary>
        string FileText { get; set; }
        /// <summary>
        /// Gets or Sets the entire contents contained in the file to be used
        /// </summary>
        string[] FileContents { get; set; }
        #endregion Internal Properties

        #region Internal Methods
        /// <summary>
        /// Checks true if a file exists, false if otherwise
        /// </summary>
        /// <returns>bool</returns>
        bool FileExists();
        /// <summary>
        /// Checks true if a file is accessible, false if otherwise
        /// </summary>
        /// <returns>bool</returns>
        bool FileInUse();
        /// <summary>
        /// Opens and Reads all text from a file
        /// </summary>
        /// <returns>string</returns>
        string ReadAllText();
        /// <summary>
        /// Opens and reads each content and/text from a file line by line and returns it as an array
        /// </summary>
        /// <returns>string[]</returns>
        string[] ReadAllLines();
        #endregion Internal Methods
    }
}
