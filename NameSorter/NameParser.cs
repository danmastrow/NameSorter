namespace NameSorter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class NameParser : INameParser
    {
        /// <summary>
        /// Parses a list of strings into Names based upon the patterns provided.
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="givenNamePattern"></param>
        /// <param name="surnamePattern"></param>
        /// <returns>A list of the Parsed Names</returns>
        public IList<IName> ParseString(IList<string> inputs, string givenNamePattern, string surnamePattern)
        {
            IList<IName> result = new List<IName>();

            foreach (string input in inputs)
            {
                // Match the Given Names and Surnames to their respective Regex Patterns
                string givenNames = Regex.Replace(input, givenNamePattern, String.Empty).Trim();
                string surname = Regex.Replace(input, surnamePattern, String.Empty).Trim();

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
