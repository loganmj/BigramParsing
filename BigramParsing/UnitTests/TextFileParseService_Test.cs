using BigramParser.Services;

namespace UnitTests
{
    /// <summary>
    /// Unit test class for TextFileParseService.
    /// </summary>
    [TestClass]
    public sealed class TextFileParseService_Test
    {
        #region Fields

        private TextFileParseService _textFileParseService;

        #endregion

        #region Setup

        /// <summary>
        /// Setup the service.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _textFileParseService = new TextFileParseService();
        }

        #endregion

        #region Unit Tests

        /// <summary>
        /// Tests a simple file parse of a valid, existing file.
        /// </summary>
        [TestMethod]
        public void Parse_FileExists()
        {
            var expected = "Hello world!";

            // Create temporary file
            var tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, expected);

            // Parse the file
            var actual = _textFileParseService.Parse(tempFilePath);

            // Assert
            Assert.AreEqual(expected, actual);

            // Delete the temporary file
            File.Delete(tempFilePath);
        }

        /// <summary>
        /// Tests the case where the file does not exist
        /// </summary>
        [TestMethod]
        public void Parse_ReturnsEmptyString_WhenFileDoesNotExist()
        {
            var expected = string.Empty;
            var actual = _textFileParseService.Parse(string.Empty);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        #endregion
    }
}
