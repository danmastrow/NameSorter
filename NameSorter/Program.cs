namespace NameSorter
{
    using System;
    using System.Linq;

    /// <summary>
    /// The Program.
    /// </summary>
    public class Program
    {
        /// <summary>The main entry point for the program.</summary>
        /// <param name="args">The array of arguments passed to the program.</param>
        public static void Main(string[] args)
        {
            try
            {
                // Read and parse the input file (expected to be the first argument)
                var file = FileManager.ReadFile(args[0]);
                var parsedNames = new NameParser().ParseFile(file.Result.ToArray(), "^(\\w+\\s+){3}", "\\s(\\w+)$");

                // Sort the list and combine into a single string seperated by a newline.
                var sorted = Sorter.SortNames(parsedNames.ToList());
                var sortedContents = String.Join("\r\n", sorted);
                Console.WriteLine(sortedContents);

                // Write the contents to the file.
                FileManager.WriteFile(Environment.CurrentDirectory + "/sorted-names-list.txt", sortedContents);

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

       
    }
}
