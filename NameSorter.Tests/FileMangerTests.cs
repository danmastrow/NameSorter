namespace NameSorter.Tests
{
    using Xunit;

    public class FileMangerTests
    {
        /// <summary>Tests the read null file path exception.</summary>
        [Fact]
        public void TestReadNullFilePathException()
        {
            // Arrange
            string filePath = null;

            // Act
            var readException = Record.ExceptionAsync(() => FileManager.ReadFileAsync(filePath));


            // Assert
            Assert.NotNull(readException);

            Assert.Equal("A valid file path must be provided.", readException.Result.Message);
        }

        /// <summary>Tests the ReadFile doesnt exist exception.</summary>
        [Fact]
        public void TestReadFileDoesntExistFilePathException()
        {
            // Arrange
            string filePath = "C:";

            // Act
            var readException = Record.ExceptionAsync(() => FileManager.ReadFileAsync(filePath));


            // Assert
            Assert.NotNull(readException);

            Assert.Equal("The file does not exist.", readException.Result.Message);
        }

        /// <summary>Tests the write null file path exception.</summary>
        [Fact]
        public void TestWriteNullFilePathException()
        {
            // Arrange
            string filePath = null;

            // Act
            var writeException = Record.ExceptionAsync(() => FileManager.WriteFileAsync(filePath, ""));

            // Assert
            Assert.NotNull(writeException);
            Assert.Equal("A valid file path must be provided.", writeException.Result.Message);
        }

        /// <summary>Tests the Null the file contents exception.</summary>
        [Fact]
        public void TestWriteNullFileContentsException()
        {
            // Arrange
            string filePath = "C:/";
            string fileContents = null;

            // Act
            var writeException = Record.ExceptionAsync(() => FileManager.WriteFileAsync(filePath, fileContents));

            // Assert
            Assert.NotNull(writeException);
            Assert.Equal("The contents of the file to write must be specified.", writeException.Result.Message);
        }
    }
}
