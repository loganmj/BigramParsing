using BigramParser.Services;
using System.Windows;

namespace BigramParser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Event Handlers

        /// <summary>
        /// Performs necessary code at startup.
        /// </summary>
        /// <param name="sender">The source of the startup event, typically the application instance.</param>
        /// <param name="e">The event data containing information about the startup process.</param>
        public void OnStartup(object sender, StartupEventArgs e)
        {
            // Build services
            var fileDialogService = new FileDialogService();

            // Create main window
            var mainWindowViewModel = new MainWindowViewModel(fileDialogService);
            var mainWindow = new MainWindow(mainWindowViewModel);
            mainWindow.Show();
        }

        #endregion
    }

}
