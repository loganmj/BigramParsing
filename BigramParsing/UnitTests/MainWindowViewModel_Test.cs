using BigramParser;
using BigramParser.Data;
using BigramParser.Services;
using Moq;

namespace UnitTests
{
    /// <summary>
    /// Unit test class for MainWindowViewModel.
    /// </summary>
    [TestClass]
    public sealed class MainWindowViewModelTests
    {
        #region Fields

        private Mock<IFileDialogService> _mockFileDialogService;
        private Mock<ITextFileParseService> _mockFileParseService;
        private Mock<IStringProcessingService> _mockStringProcessingService;
        private MainWindowViewModel _viewModel;

        #endregion

        #region Setup/Teardown

        /// <summary>
        /// Sets up the data required for testing.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _mockFileDialogService = new Mock<IFileDialogService>();
            _mockFileParseService = new Mock<ITextFileParseService>();
            _mockStringProcessingService = new Mock<IStringProcessingService>();

            _viewModel = new MainWindowViewModel(_mockFileDialogService.Object,
                                                 _mockFileParseService.Object,
                                                 _mockStringProcessingService.Object);
        }

        #endregion

        #region Unit Tests

        /// <summary>
        /// Tests the output of the SelectFileCommand when the file dialog service returns an empty string.
        /// </summary>
        [TestMethod]
        public void SelectFileCommand_FileDialogServiceReturnsEmptyString()
        {
            // Mock up the file dialog service to return an empty string from its SelectFile() method.
            var filePath = string.Empty;
            _mockFileDialogService.Setup(mock => mock.SelectFile(It.IsAny<string>())).Returns(filePath);

            // Execute SelectFileCommand
            _viewModel.SelectFileCommand.Execute(null);

            // Check that SelectedFilePath got updated correctly
            Assert.AreEqual("Select file", _viewModel.SelectedFilePath);
        }

        /// <summary>
        /// Tests that SelectedFilePath gets updated with the file path returned by the file dialog service.
        /// </summary>
        [TestMethod]
        public void SelectFileCommand_SelectedFilePathUpdatedCorrectly()
        {
            // Setup file dialog service to return the specified file path
            var filePath = "C:\\test.txt";
            _mockFileDialogService.Setup(mock => mock.SelectFile(It.IsAny<string>())).Returns(filePath);

            // Execute SelectFileCommand
            _viewModel.SelectFileCommand.Execute(null);

            // Check that SelectedFilePath got updated correctly
            Assert.AreEqual(filePath, _viewModel.SelectedFilePath);
        }

        /// <summary>
        /// Tests that the output text is derived from the StringInput property when the string input type switch is set to true.
        /// </summary>
        [TestMethod]
        public void SubmitCommand_HandleEmptyList()
        {
            var wordPairList = new List<WordPairCountDTO>();
            var expected = string.Empty;

            // Setup mock string processing service
            _mockStringProcessingService.Setup(mock => mock.CreateWordPairDistribution(It.IsAny<string>())).Returns(wordPairList);

            // Execute SubmitCommand
            _viewModel.SubmitCommand.Execute(null);
            var actual = _viewModel.OutputText;

            // Validate output text
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that the output text is derived from the StringInput property when the string input type switch is set to true.
        /// </summary>
        [TestMethod]
        public void SubmitCommand_TestParams1()
        {
            var expected = "\"unit test\": 1";

            // Setup mock string processing service
            var wordPairList = new List<WordPairCountDTO>()
            {
                new()
                {
                    Word1 = "unit",
                    Word2 = "test",
                    Count = 1
                }
            };

            _mockStringProcessingService.Setup(mock => mock.CreateWordPairDistribution(It.IsAny<string>())).Returns(wordPairList);

            // Execute SubmitCommand
            _viewModel.SubmitCommand.Execute(null);
            var actual = _viewModel.OutputText;

            // Validate output text
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that the output text is correct given a specified set of parameters.
        /// </summary>
        [TestMethod]
        public void SubmitCommand_TestParams2()
        {
            var expected = "\"unit test\": 2\n\"test words\": 1";

            // Setup mock string processing service
            var wordPairList = new List<WordPairCountDTO>()
            {
                new()
                {
                    Word1 = "unit",
                    Word2 = "test",
                    Count = 2
                },

                new()
                {
                    Word1 = "test",
                    Word2 = "words",
                    Count = 1
                },
            };

            _mockStringProcessingService.Setup(mock => mock.CreateWordPairDistribution(It.IsAny<string>())).Returns(wordPairList);

            // Execute SubmitCommand
            _viewModel.SubmitCommand.Execute(null);
            var actual = _viewModel.OutputText;

            // Validate output text
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
