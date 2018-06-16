namespace NameSorter.Tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    /// <summary>Tests for the NameSorter Class</summary>
    public class NameSorterTests
    {
        private static readonly string givenNameRegexPattern = "\\s(\\w+)$";
        private static readonly string nameConcat = "\r\n";
        private static readonly string surnameRegexPattern = "(.+)(?=\\W)";
        private static readonly StringComparer stringComparer = StringComparer.InvariantCultureIgnoreCase;

        /// <summary>Sets up the test sort data.</summary>
        /// <returns>Unsorted data and Expected Sorted Result.</returns>
        public static IEnumerable<object[]> SetupTestSortData()
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

        /// <summary>Tests the name sorter sorts correctly.</summary>
        /// <param name="unSortedNames">The unsorted names.</param>
        /// <param name="expectedResult">The expected result.</param>
        [Theory]
        [MemberData(nameof(SetupTestSortData))]
        public void TestNameSorterSortsCorrectly(string[] unsortedNames, string[] expectedResult)
        {
            // Quick check to make sure that the test is valid (unsorted and expected result are same length)
            Assert.Equal(unsortedNames.Length, expectedResult.Length);

            // Arrange
            var nameParser = new NameParser(givenNameRegexPattern, surnameRegexPattern);
            var nameSorter = new NameSorter();

            // Act
            IList<IName> names = nameParser.ParseString(unsortedNames);
            string[] sortedNames = String.Join(nameConcat, nameSorter.SortNames(names, stringComparer)).Split(nameConcat);

            // Assert
            Assert.Equal(expectedResult, sortedNames);
        }
    }

}

