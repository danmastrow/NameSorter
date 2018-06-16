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
            this.nameSorter = nameSorter ?? throw new Exception();
            this.nameParser = nameParser ?? throw new Exception();
        }

        public IList<IName> ProcessFile(IList<string> file, string seperator, string givenNamePattern, string surnamePattern)
        {
            var parsedNames = this.nameParser.ParseString(file, seperator, givenNamePattern, surnamePattern);
            var sortedNames = this.nameSorter.SortNames(parsedNames);
            return sortedNames;
        }
    }
}
