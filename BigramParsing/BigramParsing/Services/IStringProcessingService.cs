namespace BigramParser.Services
{
    /// <summary>
    /// An interface for a string processing service.
    /// </summary>
    public interface IStringProcessingService
    {
        #region Public Methods

        /// <summary>
        /// Removes all non-alpha characters, leaving only letters/words separated by a single space.
        /// leaving only 
        /// </summary>
        /// <returns>A string object with all numbers, newline characters, and special characters removed.</returns>
        string RemoveNonAlphaCharacters(string text);

        /// <summary>
        /// Takes a string, filters out any non-alpha characters, and joins the remaining words into a list.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>A list of strings containing words from the given text.</returns>
        List<string> CreateWordList(string text);

        /// <summary>
        /// Takes a string, filters out any non-alpha characters, and creates pairs of successive words, adding them to a list.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>A list of strings containing pairs of words from the given text.</returns>
        List<string> CreateWordPairList(string text);

        #endregion
    }
}
