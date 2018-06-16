namespace NameSorter.Tests
{
    using System;
    using System.IO;
    using Xunit;
    public class NameSorterTests
    {
        //[Theory]
        //[InlineData(3)]
        //[InlineData(5)]
        //[InlineData(6)]

        //private readonly string testFile1Unsorted = "./Resources/testfile1-unsorted.txt";
        //private readonly string testFile1Sorted = "./Resources/testfile1-sorted.txt";
        private static readonly string givenNameRegexPattern = "\\s(\\w+)$";
        private static readonly string nameSeperator = " ";
        private static readonly string nameConcat = "\r\n";
        private static readonly string outputFileName = "/testoutput.txt";
        private static readonly string surnameRegexPattern = "(.+)(?=\\W)";


        public void SetupTestData()
        {

        }

        [Fact]
        public void FileManagerValidTest()
        {
            // Arrange
            var filePath = testFile1Unsorted;

            // Act
            var exception = Record.ExceptionAsync(() => FileManager.ReadFileAsync(filePath));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void FileManagerExceptionHandling()
        {
            // Arrange
            string filePath = null;

            // Act
            var exception = Record.ExceptionAsync(() => FileManager.ReadFileAsync(filePath));

            // Assert
            Assert.NotNull(exception);
            Assert.Equal("A valid file path must be provided.", exception.Result.Message);
        }

        [Fact]
        public void NameParserTest()
        {
            // Arrange
            var testFileContents = FileManager.ReadFileAsync(testFile1Unsorted);
            var nameParser = new NameParser();

            // Act
            var parsedString = nameParser.ParseString(testFileContents.Result, nameSeperator, givenNameRegexPattern, surnameRegexPattern);

            // Assert
            // TODO:

        }

        [Fact]
        public void NameSorterTest()
        {
            // Arrange
            var testFileUnsorted = FileManager.ReadFileAsync(testFile1Unsorted);
            var testFileSorted= FileManager.ReadFileAsync(testFile1Sorted);

            var nameSorter = new NameSorter();
            var nameParser = new NameParser();

            // Act
            var parsedStringUnsorted = nameParser.ParseString(testFileUnsorted.Result, nameSeperator, givenNameRegexPattern, surnameRegexPattern);
            var parsedStringSorted = nameParser.ParseString(testFileSorted.Result, nameSeperator, givenNameRegexPattern, surnameRegexPattern);
            var sortedFile = nameSorter.SortNames(parsedStringUnsorted);
            
            // Assert
            Assert.Equal(sortedFile, parsedStringSorted);

        }

    }
}
