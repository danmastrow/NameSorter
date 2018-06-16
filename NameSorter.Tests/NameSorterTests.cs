namespace NameSorter.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class NameSorterTests
    {
        private static readonly string givenNameRegexPattern = "\\s(\\w+)$";
        private static readonly string nameConcat = "\r\n";
        private static readonly string surnameRegexPattern = "(.+)(?=\\W)";
        private static readonly StringComparer stringComparer = StringComparer.InvariantCultureIgnoreCase;

        public static IEnumerable<object[]> TestUnsortedDataAndExpectedOutcome()
        {
            yield return new object[]
            {
                // The unsorted list.
                new object[]
                {
                    "Robert DeNiro",
                    "Jack Nicholson" ,
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
                },
                // The expected outcome after sorting.
                new object[]
                {
                    "Humphrey Bogart",
                    "Marlon Brando",
                    "Marlon Brandon",
                    "Robert DeNiro",
                    "Johnny Depp",
                    "Leonardo DiCaprio",
                    "Leonardo DiCaprion",
                    "Tom Hanks",
                    "Jack Nicholson" ,
                    "Laurence Olivier",
                    "Al Pacino",
                    "Brad Pitt",
                    "Brad A Pitt",
                    "Brad C Pitt",
                    "Denzel Washington"
                }
            };
        }

        [Theory]
        [MemberData(nameof(TestUnsortedDataAndExpectedOutcome))]
        public void NameSorterTest(string[] unSortedNames, string[] expectedResult)
        {
            // Quick check to make sure that the test is valid (unsorted and expected result are same length)
            Assert.Equal(unSortedNames.Length, expectedResult.Length);

            // Arrange
            var nameParser = new NameParser(givenNameRegexPattern, surnameRegexPattern);
            var nameSorter = new NameSorter();

            // Act
            IList<IName> names = nameParser.ParseString(unSortedNames);
            string[] sortedNames = String.Join(nameConcat, nameSorter.SortNames(names, stringComparer)).Split(nameConcat);

            // Assert
            Assert.Equal(expectedResult, sortedNames);
        }
    }

}

