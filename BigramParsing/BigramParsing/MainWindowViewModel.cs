using BigramParser.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BigramParser
{
    /// <summary>
    /// A view model for the main window.
    /// </summary>
    public partial class MainWindowViewModel : ObservableObject
    {
        #region Constants

        private const string APP_TITLE = "Bigram Parser";
        private const string SELECTED_FILE_PATH_PLACEHOLDER_VALUE = "Select file";
        private const string SUPPORTED_FILE_TYPES_FILTER = "Text Files (*.txt)|*.txt|Markdown Files (*.md)|*.md|Text and Markdown Files (*.txt;*.md)|*.txt;*.md";
        private const string ERROR_MESSAGE_NO_FILE_PATH_SELECTED = "No file path selected.";
        private const string ERROR_MESSAGE_NO_WORD_PAIRS_FOUND = "No word pairs found.";

        #endregion

        #region Fields

        private readonly IFileDialogService _fileDialogService;
        private readonly ITextFileParseService _fileParseService;
        private readonly IStringProcessingService _stringProcessingService;

        #endregion

        #region Properties

        /// <summary>
        /// The window title.
        /// </summary>
        [ObservableProperty]
        private string _title;

        /// <summary>
        /// Is the string input type selected.
        /// </summary>
        [ObservableProperty]
        private bool _stringInputTypeSelected;

        /// <summary>
        /// The user input string value.
        /// </summary>
        [ObservableProperty]
        private string _stringInput;

        /// <summary>
        /// Is the file input type selected.
        /// </summary>
        [ObservableProperty]
        private bool _fileInputTypeSelected;

        /// <summary>
        /// The selected file path.
        /// </summary>
        [ObservableProperty]
        private string _selectedFilePath;

        /// <summary>
        /// The string retrieved from the user.
        /// </summary>
        [ObservableProperty]
        private string _outputText;

        /// <summary>
        /// Error message to display to user.
        /// </summary>
        [ObservableProperty]
        private string _errorMessage;

        /// <summary>
        /// Is the error message visible
        /// </summary>
        [ObservableProperty]
        private bool _errorMessageIsVisible;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileDialogService"></param>
        /// <param name="fileParseService"></param>
        /// <param name="stringProcessingService"></param>
        public MainWindowViewModel(IFileDialogService fileDialogService,
                                   ITextFileParseService fileParseService,
                                   IStringProcessingService stringProcessingService)
        {
            _fileDialogService = fileDialogService;
            _fileParseService = fileParseService;
            _stringProcessingService = stringProcessingService;
            Title = APP_TITLE;
            StringInputTypeSelected = true;
            StringInput = string.Empty;
            FileInputTypeSelected = false;
            SelectedFilePath = SELECTED_FILE_PATH_PLACEHOLDER_VALUE;
            OutputText = string.Empty;
            ErrorMessage = string.Empty;
            ErrorMessageIsVisible = false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Allows the user to select a file from the file browser.
        /// </summary>
        [RelayCommand]
        private void SelectFile()
        {
            // Allow user to select a file
            var filePath = _fileDialogService.SelectFile(SUPPORTED_FILE_TYPES_FILTER);

            // If the user does not select a file, or the service otherwise returns an empty string, use the placeholder value
            // Otherwise, get the file path
            if (string.IsNullOrEmpty(filePath))
            {
                DisplayError(ERROR_MESSAGE_NO_FILE_PATH_SELECTED);
                SelectedFilePath = SELECTED_FILE_PATH_PLACEHOLDER_VALUE;
            }
            else
            {
                ClearError();
                SelectedFilePath = filePath;
            }
        }

        /// <summary>
        /// Processes the text input by the user.
        /// </summary>
        [RelayCommand]
        private void Submit()
        {
            string textToProcess;

            if (StringInputTypeSelected)
            {
                textToProcess = StringInput;
            }
            else
            {
                // Parse the file
                textToProcess = _fileParseService.Parse(SelectedFilePath);
            }

            // Create word pairs list
            var wordPairsList = _stringProcessingService.CreateWordPairDistribution(textToProcess);

            // Output the word pairs
            if (wordPairsList == null || wordPairsList.Count <= 0)
            {
                DisplayError(ERROR_MESSAGE_NO_WORD_PAIRS_FOUND);
                OutputText = string.Empty;
                return;
            }

            ClearError();
            OutputText = string.Join('\n', wordPairsList);
        }

        /// <summary>
        /// Displays an error message to the user.
        /// </summary>
        /// <param name="message">The error message to display to the user.</param>
        private void DisplayError(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            ErrorMessage = message;
            ErrorMessageIsVisible = true;
        }

        /// <summary>
        /// Clears the error message.
        /// </summary>
        private void ClearError()
        {
            ErrorMessage = string.Empty;
            ErrorMessageIsVisible = false;
        }

        #endregion
    }
}
