namespace NameSorter
{
    using System;
    using System.Collections.Generic;

    /// <summary>A Name Processor that parses and sorts Names.</summary>
    public class NameProcessor
    {
        private readonly INameSorter nameSorter;
        private readonly INameParser nameParser;

        /// <summary>
        /// Instantiates a NameProcessor with a NameSorter and NameParser.
        /// </summary>
        /// <param name="nameSorter">The interface for a sorter of Names.</param>
        /// <param name="nameParser">The interface of a Parser for Names.</param>
        public NameProcessor(INameSorter nameSorter, INameParser nameParser)
        {
            this.nameSorter = nameSorter ?? throw new ArgumentNullException("nameSorter");
            this.nameParser = nameParser ?? throw new ArgumentNullException("nameParser");
        }

        /// <summary>
        /// Parses and sorts a files contents and processes it into a single string.
        /// </summary>
        /// <param name="fileContents">The contents of a file.</param>
        /// <param name="givenNamePattern">The pattern to use for the GivenNames.</param>
        /// <param name="surnamePattern">The pattern to use for the Surname.</param>
        /// <param name="seperator">The new seperator between each line.</param>
        /// <returns>A string containing all Parsed and Sorted Names.</returns>
        public string ProcessFile(IList<string> fileContents, string givenNamePattern, string surnamePattern, string seperator)
        {
            var parsedNames = this.nameParser.ParseString(fileContents, givenNamePattern, surnamePattern);
            var sortedNames = this.nameSorter.SortNames(parsedNames);
            return String.Join(seperator, sortedNames);
        }
    }
}
