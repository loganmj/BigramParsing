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
        /// <param name="filter"></param>
        /// <returns></returns>
        string SelectFile(string filter);

        #endregion
    }
}
