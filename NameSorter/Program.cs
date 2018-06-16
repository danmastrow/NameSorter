namespace NameSorter
{
    using System;
    using System.Collections.Generic;

    /// <summary>The Main Program logic and argument input.</summary>
    public class Program
    {
        private static readonly string givenNameRegexPattern = "\\s(\\w+)$";
        private static readonly string surnameRegexPattern = "(.+)(?=\\W)";
        private static readonly string nameConcat = "\r\n";
        private static readonly string outputFileName = "/sorted-names-list.txt";
        private static readonly StringComparer stringComparer = StringComparer.InvariantCultureIgnoreCase;

        /// <summary>The main entry point for the program.</summary>
        /// <param name="args">The array of arguments passed to the program.</param>
        /// <exception cref="ArgumentNullException">args[0] - A valid filepath must be supplied.</exception>
        public static void Main(string[] args)
        {
            try
            {
                // Validate FilePath argument
                if (args.Length == 0)
                    throw new ArgumentNullException("args[0]", "A valid filepath must be supplied.");

                var nameProcessor = new NameProcessor(new NameSorter(), 
                                    new NameParser(givenNameRegexPattern,surnameRegexPattern));

                // Read the file
                IList<string> fileContents = FileManager.ReadFileAsync(args[0]).Result;

                // Process the file contents (Parse, Sort and Combine into a single string)
                string processedFile = nameProcessor.ProcessFile(
                            fileContents, 
                            nameConcat,
                            stringComparer);
                
                // Output processed file to file and console.
                Console.WriteLine(processedFile);
                FileManager.WriteFileAsync(Environment.CurrentDirectory + outputFileName, processedFile).Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
