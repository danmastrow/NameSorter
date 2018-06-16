namespace NameSorter.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    /// <summary>Tests for the NameParser class.</summary>
    public class NameParserTests
    {
        /// <summary>Sets up the test sort data for NameParser.</summary>
        /// <returns></returns>
        public static IEnumerable<object[]> SetupTestSortData()
        {

            yield return new object[]
            {
                // The Parsed NameData.
                new object[]
                {
                    new Name() { Surname = "DeNiro", GivenNames = "Robert Anthony" },
                    new Name() { Surname = "Nicholson", GivenNames = "Jack" },
                    new Name() { Surname = "Brando", GivenNames = "Marlon Tarlen Scarlen" },
                    new Name() { Surname = "Johnson", GivenNames = "Dave Jeff" }
                },
                // The UnParsed NameData.
                new object[]
                {
                    "Robert Anthony DeNiro",
                    "Jack Nicholson" ,
                    "Marlon Tarlen Scarlen Brando",
                    "Dave Jeff Johnson"
                },
                // GivenName Parse Regex Pattern
                new object[]
                {
                    "\\s(\\w+)$"
                },
                // Surname Parse Regex Pattern
                new object[]
                {
                    "(.+)(?=\\W)"
                }
            };
        }

        /// <summary>Tests the NameParser class.</summary>
        /// <param name="expectedParsedNames">The expected parsed names.</param>
        /// <param name="unsortedInput">The unsorted input.</param>
        /// <param name="givenNameRegexPattern">The given name regex pattern.</param>
        /// <param name="surnameRegexPattern">The surname regex pattern.</param>
        [Theory]
        [MemberData(nameof(SetupTestSortData))]
        public void NameParserTest(IName[] expectedParsedNames, string[] unsortedInput, string[] givenNameRegexPattern, string[] surnameRegexPattern)
        {
            // Could also iterate over every given and surname pattern, and check the according expected output.
            var nameParser = new NameParser(givenNameRegexPattern[0], surnameRegexPattern[0]);

            var parsedData = nameParser.ParseString(unsortedInput).ToList();

            Assert.Equal(expectedParsedNames.ToList(), parsedData);
        }
    }
}
