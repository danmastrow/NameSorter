namespace NameSorter.Tests
{
    using System.Collections.Generic;
    using Xunit;

    public class NameParserTests
    {
        public static IEnumerable<object[]> GetTestUnsortedNames()
        {
            yield return new object[]
            {
                    "Robert De Niro",
                    "Jack Nicholson",
                    "Marlon Brando",
                    "Tom Hanks",
                    "Brad C Pitt",
                    "Leonardo DiCaprio",
                    "Leonardo DiCaprion",
                    "Humphrey Bogart",
                    "Johnny Depp",
                    "Marlon Brandon",
                    "Al Pacino",
                    "Denzel Washington",
                    "Laurence Olivier",
                    "Brad Pitt",
                    "Brad A Pitt"
            };
        }

        [Fact]
        public void NameParserTest()
        {
            // TODO:
        }
    }
}
