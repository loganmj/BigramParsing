namespace BigramParser.Services
{
    /// <summary>
    /// Interface for a file dialog service.
    /// </summary>
    public interface IFileDialogService
    {
        #region Public Methods

        /// <summary>
        /// Creates a file dialog, allowing the user to browse the file explorer and select a file.
        /// </summary>
        /// <param name="filter">A string specifying the file type filter for the dialog. 
        /// For example, use "*.txt" to allow selection of text files only, or 
        /// "Image Files|*.png;*.jpg|All Files|*.*" for multiple filters.</param>
        /// <returns>A string representing the file path selected by the user, or an empty string if no file is selected.</returns>
        string SelectFile(string filter);

        #endregion
    }
}
