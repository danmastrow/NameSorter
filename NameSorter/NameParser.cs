namespace NameSorter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class NameParser : INameParser
    {
        /// <summary>
        /// Parses a list of strings into Name's based upon the patterns provided.
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="seperator"></param>
        /// <param name="givenNamePattern"></param>
        /// <param name="surnamePattern"></param>
        /// <returns>A list of the Parsed Names</returns>
        public IList<IName> ParseString(IList<string> inputs, string seperator, string givenNamePattern, string surnamePattern)
        {
            IList<IName> result = new List<IName>();

            foreach (string input in inputs)
            {
                var givenNames = Regex.Replace(input, givenNamePattern, String.Empty).Trim();
                var surname = Regex.Replace(input, surnamePattern, String.Empty).Trim();

                var name = new Name()
                {
                    GivenNames = givenNames.Split(seperator).ToList(),
                    Surname = surname
                };
                result.Add(name);
            }
            return result;  
        }
    }
}
