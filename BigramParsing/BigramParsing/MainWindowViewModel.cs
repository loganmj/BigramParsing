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

        private const string SELECTED_FILE_PATH_PLACEHOLDER_VALUE = "Select file ...";
        private const string SUPPORTED_FILE_TYPES_FILTER = "Text Files (*.txt)|*.txt|Markdown Files (*.md)|*.md|Text and Markdown Files (*.txt;*.md)|*.txt;*.md";

        #endregion

        #region Fields

        private IFileDialogService _fileDialogService;

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
        public MainWindowViewModel(IFileDialogService fileDialogService)
        {
            _fileDialogService = fileDialogService;
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
            var filePath = _fileDialogService.SelectFile(SUPPORTED_FILE_TYPES_FILTER);

            if (string.IsNullOrEmpty(filePath))
            {
                // Retain the placeholder value
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
            if (StringInputTypeSelected)
            {
                OutputText = StringInput;
            }
            else if (FileInputTypeSelected)
            {
                // TODO: Parse the file and output the text
                OutputText = SelectedFilePath;
            }
        }

        #endregion
    }
}
