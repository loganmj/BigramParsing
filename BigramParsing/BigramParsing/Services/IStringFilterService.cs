namespace BigramParser.Services
{
    /// <summary>
    /// An interface for a string filter service.
    /// </summary>
    public interface IStringFilterService
    {
        #region Public Methods

        /// <summary>
        /// Removes all non-alpha characters, leaving only letters/words separated by a single space.
        /// leaving only 
        /// </summary>
        /// <returns>A string object with all numbers, newline characters, and special characters removed.</returns>
        public string RemoveNonAlphaCharacters(string text);

        #endregion
    }
}
