namespace NameSorter
{
    using System.Collections.Generic;
    using System.IO;
    using System;
    using System.Threading.Tasks;

    public static class FileManager
    {
        /// <summary>Reads a file into a string.</summary>
        /// <param name="filePath">The full path of the file to read.</param>
        /// <exception cref="ArgumentNullException">Thrown if the filepath parameter is null.</exception>
        /// <returns>Returns the file's contents.</returns>
        public static async Task<IList<string>> ReadFileAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                var message = "A valid file path must be provided.";
                throw new ArgumentNullException(filePath, message);
            }

            return await File.ReadAllLinesAsync(filePath);
        }

       /// <summary>
       /// Write the contents of a string to a file in a specific filepath.
       /// If the file already exists it is overwritten.
       /// </summary>
       /// <param name="filePath">The path and filename to write to.</param>
       /// <param name="contents">The contents of the file to write.</param>
       public static async Task WriteFileAsync(string filePath, string contents)
       {
            if (string.IsNullOrEmpty(filePath))
            {
                var message = "A valid file path must be provided.";
                throw new ArgumentNullException(filePath, message);
            }

            // Empty string contents are acceptable for a file, but a null is not.
            if (contents == null)
            {
                var message = "The contents of the file to write must be specified.";
                throw new ArgumentNullException(contents, message);
            }
            await File.WriteAllTextAsync(filePath, contents);
        }
    }
}
