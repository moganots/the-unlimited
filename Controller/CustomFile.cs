using Common;
using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CustomFile : ICustomFile
    {
        #region Internal Properties
        /// <summary>
        /// Gets or Sets the fully qualified path of the file to be used
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// Gets or Sets the entire text contained in the file to be used
        /// </summary>
        public string FileText { get; set; }
        /// <summary>
        /// Gets or Sets the entire contents contained in the file to be used
        /// </summary>
        public string[] FileContents { get; set; }
        #endregion Internal Properties

        #region Constructor
        /// <summary>
        /// Instantiates an instance of the CustomFile
        /// </summary>
        public CustomFile() { }
        /// <summary>
        /// Instantiates an instance of the CustomFile, with the specified file path
        /// </summary>
        /// <param name="filePath">The fully qualified path to of the file to be used</param>
        public CustomFile(string filePath)
        {
            FilePath = filePath;
        }
        #endregion Constructor

        #region Internal Methods
        /// <summary>
        /// Checks true if a file exists, false if otherwise
        /// </summary>
        /// <returns>bool</returns>
        public bool FileExists()
        {
            return Helpers.IsSet(FilePath) && File.Exists(FilePath);
        }
        /// <summary>
        /// Checks true if a file is accessible, false if otherwise
        /// </summary>
        /// <returns>bool</returns>
        public bool FileInUse()
        {
            try
            {
                using (FileStream stream = File.Open(FilePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                return true;
            }
            return false;

        }
        /// <summary>
        /// Opens and Reads all text from a file
        /// </summary>
        /// <returns>string</returns>
        public string ReadAllText()
        {
            return (FileText = (FileExists() && !FileInUse()) ? File.ReadAllText(FilePath) : null);
        }
        /// <summary>
        /// Opens and reads each content and/text from a file line by line and returns it as an array
        /// </summary>
        /// <returns>string[]</returns>
        public string[] ReadAllLines()
        {
            return (FileContents = (FileExists() && !FileInUse()) ? File.ReadAllLines(FilePath) : null);
        }
        #endregion Internal Methods
    }
}
