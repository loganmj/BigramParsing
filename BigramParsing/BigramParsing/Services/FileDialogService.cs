using Microsoft.Win32;

namespace BigramParser.Services
{
    /// <summary>
    /// Implements the file dialog service.
    /// </summary>
    public class FileDialogService : IFileDialogService
    {
        #region Public Methods

        /// <inheritdoc/>
        /// <param name="filter"></param>
        /// <returns></returns>
        public string SelectFile(string filter)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = filter
            };

            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : string.Empty;
        }

        #endregion
    }
}
