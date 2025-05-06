using System.Windows;

namespace BigramParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="viewModel">The ViewModel instance that provides data and commands for the MainWindow, used to set the DataContext for data binding.</param>
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}