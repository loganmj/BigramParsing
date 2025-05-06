namespace BigramParser.Services
{
    /// <summary>
    /// Interface for a file parsing service.
    /// </summary>
    public interface ITextFileParseService
    {
        #region Public Methods

        /// <summary>
        /// Reads all text from the given file.
        /// Removes any non-alphanumeric characters.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>A string object containing the text from the given file.</returns>
        public string Parse(string filePath);

        #endregion
    }
}
