namespace NameSorter.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class NameParserTests
    {
        public static IEnumerable<object[]> SetupTestSortData()
        {

            yield return new object[]
            {
                new object[]
                {
                    new Name() { Surname = "DeNiro", GivenNames = "Robert Anthony" },
                    new Name() { Surname = "Nicholson", GivenNames = "Jack" },
                    new Name() { Surname = "Brando", GivenNames = "Marlon Tarlen Scarlen" },
                    new Name() { Surname = "Johnson", GivenNames = "Dave Jeff" }
                },
                new object[]
                {
                    "Robert Anthony DeNiro",
                    "Jack Nicholson" ,
                    "Marlon Tarlen Scarlen Brando",
                    "Dave Jeff Johnson"
                },
                new object[]
                {
                    "\\s(\\w+)$"
                },
                new object[]
                {
                    "(.+)(?=\\W)"
                }
            };
        }

        [Theory]
        [MemberData(nameof(SetupTestSortData))]
        public void NameParserTest(IName[] names, string[] unsortedInput, string[] givenNameRegexPattern, string[] surnameRegexPattern)
        {
            // Could also iterate over every given and surname pattern, and check the according expected output.
            var nameParser = new NameParser(givenNameRegexPattern[0], surnameRegexPattern[0]);

            var parsedData = nameParser.ParseString(unsortedInput).ToList();
            
            Assert.Equal(names.ToList(), parsedData);
        }
    }
}
