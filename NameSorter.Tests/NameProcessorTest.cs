namespace NameSorter.Tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    /// <summary>Unit tests for the NameProcessorClass.</summary>
    public class NameProcessorTest
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
                    "Jack First AAAA" ,
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
                // The expected sorted list.
                new object[]
                {
                    "Jack First AAAA",
                    "Humphrey Bogart",
                    "Marlon Brando",
                    "Marlon Brandon",
                    "Robert DeNiro",
                    "Johnny Depp",
                    "Leonardo DiCaprio",
                    "Leonardo DiCaprion",
                    "Tom Hanks",
                    "Laurence Olivier",
                    "Al Pacino",
                    "Brad Pitt",
                    "Brad A Pitt",
                    "Brad C Pitt",
                    "Denzel Washington"
                }
            };
        }

        /// <summary>Tests the name processer works correctly.</summary>
        /// <param name="unsortedNames">The unsorted names.</param>
        /// <param name="expectedResultArray">The expected result array.</param>
        [Theory]
        [MemberData(nameof(SetupTestSortData))]
        public void TestValidNameProcess(string[] unsortedNames, string[] expectedResultArray)
        {
            // Quick check to make sure that the test is valid (unsorted and expected result are same length)
            Assert.Equal(unsortedNames.Length, expectedResultArray.Length);

            // Arrange
            var expectedResult = String.Join("\r\n", expectedResultArray);
            var nameParser = new NameParser(givenNameRegexPattern, surnameRegexPattern);
            var nameSorter = new NameSorter();
            var nameProcessor = new NameProcessor(nameSorter, nameParser);

            // Act
            var sortedNames = nameProcessor.ProcessFile(unsortedNames, nameConcat, stringComparer);

            // Assert
            Assert.Equal(expectedResult, sortedNames);
        }
    }
}
