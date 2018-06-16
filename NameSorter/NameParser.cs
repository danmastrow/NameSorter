namespace NameSorter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class NameParser
    {

        // The expected format of the file is as follows:
        // GivenName PotentiallyGivenName2 PotentiallyGivenName3 Surname
        // TODO: Use a REGEX Pattern instead.
        public IEnumerable<IName> ParseFile(string[] file, string givenNamePattern, string surnamePattern)
        {
            List<Name> result = new List<Name>();

            foreach (string line in file)
            {
                var givenNames = Regex.Replace(line, givenNamePattern, String.Empty);

                Name name = new Name()
                {
                    GivenNames = givenNames.Split(" ").ToList(),
                    Surname = Regex.Replace(line, surnamePattern, String.Empty)
                };
                
                //var split = line.Split(lineDelimiter, System.StringSplitOptions.RemoveEmptyEntries);
                
                // 0 to potentially 2 (seperated by spaces) are Given Names
                // last value is Surname
                //var name = new Name() { Surname = split[split.Length - 1], GivenNames = new List<string>() };
                
                //for (int i = 0; i < split.Length - 1; i++)
                //{
                //    name.GivenNames.Add(split[i]);
                //}

                result.Add(name);
            }
            return result;  
        }
    }
}
