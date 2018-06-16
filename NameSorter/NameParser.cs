namespace NameSorter
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>Parser for parsing Names.</summary>
    /// <seealso cref="NameSorter.INameParser" />
    public class NameParser : INameParser
    {
        private readonly string givenNameRegexPattern, surnameRegexPattern;

        /// <summary>Constructor for the NameParser class.</summary>
        /// <param name="givenNameRegexPattern">The</param>
        /// <param name="surnameRegexPattern">The surname regex pattern.</param>
        /// <exception cref="ArgumentNullException">GivenName and Surname regex patterns must not be null.</exception>
        public NameParser(string givenNameRegexPattern, string surnameRegexPattern)
        {
            this.givenNameRegexPattern = givenNameRegexPattern ?? throw new ArgumentNullException("givenNameRegexPattern");
            this.surnameRegexPattern = surnameRegexPattern ?? throw new ArgumentNullException("surnameRegexPattern");
        }

        /// <summary>Parses a list of strings into Names.</summary>
        /// <param name="inputs">List of strings to Parse into Names.</param>
        /// <returns>A list of the Parsed Names</returns>
        public IList<IName> ParseString(IList<string> inputs)
        {
            var result = new List<IName>();

            foreach (string input in inputs)
            {
                // Match the Given Names and Surnames to their respective Regex Patterns
                string givenNames = Regex.Replace(input, givenNameRegexPattern, String.Empty).Trim();
                string surname = Regex.Replace(input, surnameRegexPattern, String.Empty).Trim();

                result.Add(new Name()
                {
                    GivenNames = givenNames,
                    Surname = surname
                });
            }
            return result;
        }

    }
}
