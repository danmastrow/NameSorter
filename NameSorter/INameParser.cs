namespace NameSorter
{
    using System.Collections.Generic;

    /// <summary>The interface of a parser for names.</summary>
    public interface INameParser
    {
        /// <summary>
        /// Parses a list of input strings into a IList of Names.
        /// </summary>
        /// <param name="inputs">List of input strings.</param>
        /// <param name="seperator">The seperator for the parser.</param>
        /// <param name="givenNamePattern">The givenName pattern to parse on.</param>
        /// <param name="surnamePattern">The surname pattern to parse on.</param>
        /// <returns>A list of parsed names.</returns>
        IList<IName> ParseString(IList<string> inputs, string seperator, string givenNamePattern, string surnamePattern);
    }
}