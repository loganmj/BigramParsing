using BigramParser;
using BigramParser.Services;
using Moq;

namespace UnitTests
{
    [TestClass]
    public sealed class MainWindowViewModel_Test
    {

        [TestClass]
        public class MainWindowViewModelTests
        {
            #region Fields

            private Mock<IFileDialogService> _mockFileDialogService;
            // private Mock<ITextFileParseService> _mockFileParseService;
            // private Mock<IStringProcessingService> _mockStringProcessingService;
            private MainWindowViewModel _viewModel;

            #endregion

            #region Setup/Teardown

            [TestInitialize]
            public void Setup()
            {
                _mockFileDialogService = new Mock<IFileDialogService>();
                // _mockFileParseService = new Mock<ITextFileParseService>();
                // _mockStringProcessingService = new Mock<IStringProcessingService>();

                _viewModel = new MainWindowViewModel(
                _mockFileDialogService.Object,
                new TextFileParseService(),
                new StringProcessingService()
                );
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
                _mockFileDialogService.Setup(mock => mock.SelectFile(It.IsAny<string>())).Returns(string.Empty);

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
            /// Tests that the output text is correct given a specified set of parameters.
            /// </summary>
            [TestMethod]
            public void SubmitCommand_TestParams1()
            {
                var inputText = "Unit test";
                var expectedOutput = "\"unit test\": 1";

                // Setup view model
                _viewModel.StringInputTypeSelected = true;
                _viewModel.StringInput = inputText;

                // Execute SubmitCommand
                _viewModel.SubmitCommand.Execute(null);

                // Validate output text
                Assert.AreEqual(expectedOutput, _viewModel.OutputText);
            }

            /// <summary>
            /// Tests that the output text is correct given a specified set of parameters.
            /// </summary>
            [TestMethod]
            public void SubmitCommand_TestParams2()
            {
                var inputText = "Hello my baby, hello my honey";
                var expectedOutput = "\"hello my\": 2\n"
                                     + "\"my baby\": 1\n"
                                     + "\"baby hello\": 1\n"
                                     + "\"my honey\": 1";

                // Setup view model
                _viewModel.StringInputTypeSelected = true;
                _viewModel.StringInput = inputText;

                // Execute SubmitCommand
                _viewModel.SubmitCommand.Execute(null);

                // Validate output text
                Assert.AreEqual(expectedOutput, _viewModel.OutputText);
            }

            /// <summary>
            /// Tests that the output text is correct given a specified set of parameters.
            /// </summary>
            [TestMethod]
            public void SubmitCommand_TestParams3()
            {
                var inputText = "Karma, karma, karma, karma, karma chameleon";
                var expectedOutput = "\"karma karma\": 4\n"
                                     + "\"karma chameleon\": 1";

                // Setup view model
                _viewModel.StringInputTypeSelected = true;
                _viewModel.StringInput = inputText;

                // Execute SubmitCommand
                _viewModel.SubmitCommand.Execute(null);

                // Validate output text
                Assert.AreEqual(expectedOutput, _viewModel.OutputText);
            }

            /// <summary>
            /// Tests that the output text is correct given a specified set of parameters.
            /// </summary>
            [TestMethod]
            public void SubmitCommand_HandleNumbers()
            {
                var inputText = "1337 5p34k h3r0";
                var expectedOutput = "\"pk hr\": 1";

                // Setup view model
                _viewModel.StringInputTypeSelected = true;
                _viewModel.StringInput = inputText;

                // Execute SubmitCommand
                _viewModel.SubmitCommand.Execute(null);

                // Validate output text
                Assert.AreEqual(expectedOutput, _viewModel.OutputText);
            }

            /// <summary>
            /// Tests that the output text is correct given a specified set of parameters.
            /// </summary>
            [TestMethod]
            public void SubmitCommand_HandleQuotes()
            {
                var inputText = "\"He says 'I can't cant'\", but he can.";
                var expectedOutput = "\"he says\": 1\n"
                                     + "\"says i\": 1\n"
                                     + "\"i can't\": 1\n"
                                     + "\"can't cant\": 1\n"
                                     + "\"cant but\": 1\n"
                                     + "\"but he\": 1\n"
                                     + "\"he can\": 1";

                // Setup view model
                _viewModel.StringInputTypeSelected = true;
                _viewModel.StringInput = inputText;

                // Execute SubmitCommand
                _viewModel.SubmitCommand.Execute(null);

                // Validate output text
                Assert.AreEqual(expectedOutput, _viewModel.OutputText);
            }

            /// <summary>
            /// Tests that the output text is correct given a specified set of parameters.
            /// </summary>
            [TestMethod]
            public void SubmitCommand_HandleCompoundWords()
            {
                var inputText = "Yes-yes! Warpstone for me-me! Glory for the Horned Rat!";
                var expectedOutput = "\"yes-yes warpstone\": 1\n"
                                     + "\"warpstone for\": 1\n"
                                     + "\"for me-me\": 1\n"
                                     + "\"me-me glory\": 1\n"
                                     + "\"glory for\": 1\n"
                                     + "\"for the\": 1\n"
                                     + "\"the horned\": 1\n"
                                     + "\"horned rat\": 1";

                // Setup view model
                _viewModel.StringInputTypeSelected = true;
                _viewModel.StringInput = inputText;

                // Execute SubmitCommand
                _viewModel.SubmitCommand.Execute(null);

                // Validate output text
                Assert.AreEqual(expectedOutput, _viewModel.OutputText);
            }

            /// <summary>
            /// Tests that the output text is correct given a specified set of parameters.
            /// </summary>
            [TestMethod]
            public void SubmitCommand_HandleNonsense()
            {
                var inputText = "g#7'Lp-q2 @v9-T'z!3 m'1$-Xp&4 ^R7*e'W-0 z'8&-L$kQ ~T'z3!-v9 xP@#7-r$'M";
                var expectedOutput = "\"glp-q vt'z\": 1\n"
                                     + "\"vt'z mxp\": 1\n"
                                     + "\"mxp re'w\": 1\n"
                                     + "\"re'w zlkq\": 1\n"
                                     + "\"zlkq t'zv\": 1\n"
                                     + "\"t'zv xprm\": 1";

                // Setup view model
                _viewModel.StringInputTypeSelected = true;
                _viewModel.StringInput = inputText;

                // Execute SubmitCommand
                _viewModel.SubmitCommand.Execute(null);

                // Validate output text
                Assert.AreEqual(expectedOutput, _viewModel.OutputText);
            }

            /*

            [TestMethod]
            public void Submit_WithFileInputTypeSelected_ProcessesFileInput()
            {
                _viewModel.StringInputTypeSelected = false;
                _viewModel.FileInputTypeSelected = true;
                _viewModel.SelectedFilePath = "C:\\test.txt";

                var fileContent = "file content";
                var expectedOutput = new[] { "file content" };

                _mockFileParseService.Setup(s => s.Parse("C:\\test.txt")).Returns(fileContent);
                _mockStringProcessingService.Setup(s => s.CreateWordPairDistribution(fileContent)).Returns(expectedOutput);

                _viewModel.SubmitCommand.Execute(null);

                Assert.AreEqual("file content", _viewModel.OutputText);
            }

            */

            #endregion
        }

    }
}
