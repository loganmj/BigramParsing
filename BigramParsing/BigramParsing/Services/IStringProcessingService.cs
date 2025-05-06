using BigramParser.Data;

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
        /// Creates a collection of word pair DTOs from a given string.
        /// Each word pair DTO keeps track of how many times that word pair has appeared.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>A collection of WordPairCountDTO objects.</returns>
        List<WordPairCountDTO> CreateWordPairDistribution(string text);

        #endregion
    }
}
