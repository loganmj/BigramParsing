using System.Text.RegularExpressions;

namespace BigramParser.Services
{
    /// <summary>
    /// Implements the string filter service interface.
    /// </summary>
    public partial class StringFilterService : IStringFilterService
    {
        #region Regex

        /// <summary>
        /// A regex filter that removes all non-alpha characters,
        /// leaving only letters/words, and single spaces.
        /// </summary>
        /// <returns></returns>
        [GeneratedRegex("[^a-zA-Z ]")]
        private static partial Regex AlphaRegex();

        /// <summary>
        /// A regex filter that finds all instances of one or more successive space characters.
        /// </summary>
        /// <returns></returns>
        [GeneratedRegex(@"\s+")]
        private static partial Regex MultipleSpacesRegex();

        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public string RemoveNonAlphaCharacters(string text)
        {
            // Parse the file and replace newline characters with spaces
            var filteredText = text
                .Replace("\r\n", " ")
                .Replace("\n", " ")
                .Replace("\r", " ");


            // Remove all characters except letters, digits, and spaces
            filteredText = AlphaRegex().Replace(filteredText, " ");

            // Replace multiple spaces with a single space
            filteredText = MultipleSpacesRegex().Replace(filteredText, " ").Trim();

            return filteredText;
        }

        #endregion
    }
}
