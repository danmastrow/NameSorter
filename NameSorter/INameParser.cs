namespace NameSorter
{
    using System.Collections.Generic;

    /// <summary>The interface of a parser for names.</summary>
    public interface INameParser
    {
        /// <summary>Parses a list of input strings into Names.</summary>
        /// <param name="inputs">List of input strings.</param>
        /// <returns>A list of parsed names.</returns>
        IList<IName> ParseString(IList<string> inputs);
    }
}