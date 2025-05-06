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

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindowViewModel()
        {
            Title = "Bigram Parser";
        }

        #endregion
    }
}
