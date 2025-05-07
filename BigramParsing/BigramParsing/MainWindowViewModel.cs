using BigramParser.Data;
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

        private const string SELECTED_FILE_PATH_PLACEHOLDER_VALUE = "Select file";
        private const string SUPPORTED_FILE_TYPES_FILTER = "Text Files (*.txt)|*.txt|Markdown Files (*.md)|*.md|Text and Markdown Files (*.txt;*.md)|*.txt;*.md";

        #endregion

        #region Fields

        private IFileDialogService _fileDialogService;
        private ITextFileParseService _fileParseService;
        private IStringProcessingService _stringProcessingService;

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

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileDialogService"></param>
        /// <param name="fileParseService"></param>
        public MainWindowViewModel(IFileDialogService fileDialogService, ITextFileParseService fileParseService, IStringProcessingService stringFilterService)
        {
            _fileDialogService = fileDialogService;
            _fileParseService = fileParseService;
            _stringProcessingService = stringFilterService;
            Title = "Bigram Parser";
            StringInputTypeSelected = true;
            StringInput = string.Empty;
            FileInputTypeSelected = false;
            SelectedFilePath = SELECTED_FILE_PATH_PLACEHOLDER_VALUE;
            OutputText = string.Empty;
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
                SelectedFilePath = SELECTED_FILE_PATH_PLACEHOLDER_VALUE;
            }
            else
            {
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
            var wordPairs = _stringProcessingService.CreateWordPairDistribution(textToProcess);

            // Output the word pairs
            OutputText = string.Join('\n', wordPairs ?? Enumerable.Empty<WordPairCountDTO>());
        }

        #endregion
    }
}
