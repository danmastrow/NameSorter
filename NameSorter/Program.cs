namespace NameSorter
{
    using System;

    /// <summary>The Program logic and argument handling.</summary>
    public class Program
    {
        private static readonly string givenNameRegexPattern = "\\s(\\w+)$";
        private static readonly string nameSeperator = " ";
        private static readonly string nameConcat = "\r\n";
        private static readonly string outputFileName = "/sorted-names-list.txt";
        private static readonly string surnameRegexPattern = "(.+)(?=\\W)";

        /// <summary>The main entry point for the program.</summary>
        /// <param name="args">The array of arguments passed to the program.</param>
        public static void Main(string[] args)
        {
            try
            {
                var file = FileManager.ReadFileAsync(args[0]);
                var nameProcessor = new NameProcessor(new NameSorter(), new NameParser());

                var processedFile = nameProcessor.ProcessFile(file.Result, nameSeperator, givenNameRegexPattern, surnameRegexPattern);
                string processedFileContents = String.Join(nameConcat, processedFile);

                Console.WriteLine(processedFileContents);
                FileManager.WriteFileAsync(Environment.CurrentDirectory + outputFileName, processedFileContents).Wait();

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
