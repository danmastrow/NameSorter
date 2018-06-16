namespace NameSorter.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    /// <summary>Tests for the NameSorter Class.</summary>
    public class NameSorterTests
    {
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
                    new Name() { Surname = "Washington", GivenNames = "Denzel" },
                    new Name() { GivenNames = "Brad A", Surname = "Pitt" },
                    new Name() { GivenNames = "Al", Surname = "Pacino" },
                    new Name() { GivenNames = "Brad A A", Surname = "Pitt" },
                    new Name() { GivenNames = "Brad", Surname = "Pitt" }
                },
                // The expected outcome after sorting.
                new object[]
                {
                    new Name() { GivenNames = "Al", Surname = "Pacino" },
                    new Name() { GivenNames = "Brad", Surname = "Pitt" },
                    new Name() { GivenNames = "Brad A", Surname = "Pitt" },
                    new Name() { GivenNames = "Brad A A", Surname = "Pitt" },
                    new Name() { Surname = "Washington", GivenNames = "Denzel" }
                }
            };
        }

        /// <summary>Tests the name sorter sorts correctly.</summary>
        /// <param name="unsortedNames">The unsorted names.</param>
        /// <param name="expectedResult">The expected result.</param>
        [Theory]
        [MemberData(nameof(SetupTestSortData))]
        public void TestValidNameSort(IName[] unsortedNames, IName[] expectedResult)
        {
            // Quick check to make sure that the test is valid (unsorted and expected result are same length)
            Assert.Equal(unsortedNames.Length, expectedResult.Length);

            // Arrange
            var nameSorter = new NameSorter();

            // Act
            var sortedNames = nameSorter.SortNames(unsortedNames.ToList(), stringComparer);

            // Assert
            Assert.Equal(expectedResult, sortedNames);
        }
    }

}

