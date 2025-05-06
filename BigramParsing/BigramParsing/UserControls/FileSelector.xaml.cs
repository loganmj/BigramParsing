using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BigramParser.UserControls
{
    /// <summary>
    /// Interaction logic for FileSelector.xaml
    /// </summary>
    public partial class FileSelector : UserControl
    {
        #region Properties

        /// <summary>
        /// The selected file path.
        /// </summary>
        public string SelectedFilePath
        {
            get => (string)GetValue(SelectedFilePathProperty);
            set => SetValue(SelectedFilePathProperty, value);
        }

        /// <summary>
        /// A command that gets fired when the user requests to select a file.
        /// </summary>
        public ICommand SelectFileCommand
        {
            get => (ICommand)GetValue(SelectFileCommandProperty);
            set => SetValue(SelectFileCommandProperty, value);
        }

        #endregion

        #region Dependency Properties

        /// <summary>
        /// Exposes the SelectedFilePath property as a Dependency Property, allowing for data binding.
        /// </summary>
        public static readonly DependencyProperty SelectedFilePathProperty =
            DependencyProperty.Register(nameof(SelectedFilePath),
                                        typeof(string),
                                        typeof(FileSelector),
                                        new PropertyMetadata(string.Empty));

        /// <summary>
        /// Exposes the SelectFileCommand property as a Dependency Property, allowing for data binding.
        /// </summary>
        public static readonly DependencyProperty SelectFileCommandProperty =
            DependencyProperty.Register(nameof(SelectFileCommand),
                                        typeof(ICommand),
                                        typeof(FileSelector),
                                        new PropertyMetadata(null));

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public FileSelector()
        {
            InitializeComponent();
        }

        #endregion
    }
}
