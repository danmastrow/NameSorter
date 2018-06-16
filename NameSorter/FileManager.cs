namespace NameSorter
{
    using System.Collections.Generic;
    using System.IO;
    using System;
    using System.Threading.Tasks;

    /// <summary>Utility class to manage the IO File Operations.</summary>
    public static class FileManager
    {
        /// <summary>Reads a file into a string.</summary>
        /// <param name="filePath">The full path of the file to read.</param>
        /// <returns>Returns the file's contents.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the filepath parameter is null.</exception>
        public static async Task<IList<string>> ReadFileAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                var message = "A valid file path must be provided.";
                throw new ArgumentNullException(filePath, message);
            }

            if (!File.Exists(filePath))
            {
                var message = "The file does not exist.";
                throw new FileNotFoundException(message, filePath);
            }

            return await File.ReadAllLinesAsync(filePath);
        }

        /// <summary>
        /// Write the contents of a string to a file in a specific filepath.
        /// If the file already exists it is overwritten.
        /// </summary>
        /// <param name="filePath">The path and filename to write to.</param>
        /// <param name="contents">The contents of the file to write.</param>
        /// <returns>Task.</returns>
        /// <exception cref="ArgumentNullException">Throws an null exception if the filepath or file contents are null.</exception>
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
