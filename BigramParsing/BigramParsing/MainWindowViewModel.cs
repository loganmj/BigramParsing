using CommunityToolkit.Mvvm.ComponentModel;

namespace BigramParser
{
    /// <summary>
    /// A view model for the main window.
    /// </summary>
    public partial class MainWindowViewModel : ObservableObject
    {
        #region Fields

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private bool _stringInputTypeSelected;

        [ObservableProperty]
        private bool _fileInputTypeSelected;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindowViewModel()
        {
            Title = "Bigram Parser";
            StringInputTypeSelected = true;
            FileInputTypeSelected = false;
        }

        #endregion
    }
}
