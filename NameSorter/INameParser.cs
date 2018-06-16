namespace NameSorter
{
    using System.Collections.Generic;

    /// <summary>The interface of a Parser for Names.</summary>
    public interface INameParser
    {
        /// <summary>
        /// Parses a list of input strings into a IList of Names.
        /// </summary>
        /// <param name="inputs">Input string</param>
        /// <param name="seperator"></param>
        /// <param name="givenNamePattern"></param>
        /// <param name="surnamePattern"></param>
        /// <returns></returns>
        IList<IName> ParseString(IList<string> inputs, string seperator, string givenNamePattern, string surnamePattern);
    }
}