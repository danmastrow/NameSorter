namespace NameSorter
{
    using System;
    using System.Collections.Generic;

    /// <summary>A Name Processor that parses and sorts Names.</summary>
    public class NameProcessor
    {
        private readonly INameSorter nameSorter;
        private readonly INameParser nameParser;

        /// <summary>Constructor for the NameProcessor.</summary>
        /// <param name="nameSorter">The NameSorter interface.</param>
        /// <param name="nameParser">The NameParser interface.</param>
        /// <exception cref="ArgumentNullException">Thrown if nameSorter or nameParser are null.</exception>
        public NameProcessor(INameSorter nameSorter, INameParser nameParser)
        {
            this.nameSorter = nameSorter ?? throw new ArgumentNullException("nameSorter");
            this.nameParser = nameParser ?? throw new ArgumentNullException("nameParser");
        }

        /// <summary>
        /// Parses and sorts a files contents and processes it into a single string.
        /// </summary>
        /// <param name="fileContents">The contents of a file.</param>
        /// <param name="seperator">The new seperator between each line.</param>
        /// <param name="stringComparer">The string comparer.</param>
        /// <returns>A string containing all Parsed and Sorted Names.</returns>
        public string ProcessFile(IList<string> fileContents, string seperator, StringComparer stringComparer)
        {
            var parsedNames = this.nameParser.ParseString(fileContents);
            var sortedNames = this.nameSorter.SortNames(parsedNames, stringComparer);
            return String.Join(seperator, sortedNames);
        }
    }
}
