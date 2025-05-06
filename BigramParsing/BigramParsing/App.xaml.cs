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
            var mainWindowViewModel = new MainWindowViewModel();
            var mainWindow = new MainWindow(mainWindowViewModel);
            mainWindow.Show();
        }

        #endregion
    }

}
