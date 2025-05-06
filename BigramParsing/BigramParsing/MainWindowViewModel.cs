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
        /// Is the file input type selected.
        /// </summary>
        [ObservableProperty]
        private bool _fileInputTypeSelected;

        /// <summary>
        /// The selected file path.
        /// </summary>
        [ObservableProperty]
        private string _selectedFilePath;

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
            FileInputTypeSelected = false;
            SelectedFilePath = "Select file ...";
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Allows the user to select a file from the file browser.
        /// </summary>
        [RelayCommand]
        private void SelectFile()
        {
            SelectedFilePath = _fileDialogService.SelectFile(SUPPORTED_FILE_TYPES_FILTER);
        }

        #endregion
    }
}
