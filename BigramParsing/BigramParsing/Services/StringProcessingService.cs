using BigramParser.Data;
using System.Text.RegularExpressions;

namespace BigramParser.Services
{
    /// <summary>
    /// Implements the string filter service interface.
    /// </summary>
    public partial class StringProcessingService : IStringProcessingService
    {
        #region Regex

        /// <summary>
        /// A regex filter that removes all non-alpha characters,
        /// leaving only letters/words, and single spaces.
        /// </summary>
        /// <returns></returns>

        [GeneratedRegex("[^a-zA-Z\\-\' ]")]
        private static partial Regex AlphaRegex();

        /// <summary>
        /// Matches apostrophes or hyphens that are at start/end of a word or surrounded by spaces.
        /// </summary>
        [GeneratedRegex(@"(?<![a-zA-Z])['\-]|'\-")]
        private static partial Regex LoneSpecialCharRegex();

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

            // Remove all characters except letters, apostrophes, hyphens, and spaces
            filteredText = AlphaRegex().Replace(filteredText, " ");

            // Remove apostrophes and hyphens not between letters
            // This keeps contractions and compound words intact, but filters out floating special characters.
            filteredText = LoneSpecialCharRegex().Replace(filteredText, " ");

            // Normalize multiple spaces
            filteredText = MultipleSpacesRegex().Replace(filteredText, " ").Trim();

            return filteredText;
        }

        /// <inheritdoc/>
        public List<WordPairCountDTO> CreateWordPairDistribution(string text)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(text))
            {
                return [];
            }

            // Filter the text, make it all lowercase
            var filteredText = RemoveNonAlphaCharacters(text)
                .ToLowerInvariant();

            // Split the text into words
            var words = filteredText.Split([' '], StringSplitOptions.RemoveEmptyEntries);

            // Create the word pair list
            var wordPairData = new List<WordPairCountDTO>();

            for (int i = 0; i < words.Length - 1; i++)
            {
                // Get the word pair
                var word1 = words[i];
                var word2 = words[i + 1];

                // Check the list for existing word pair
                var existingPair = wordPairData.FirstOrDefault(dto => (dto?.Word1?.Equals(word1) ?? false) && (dto?.Word2?.Equals(word2) ?? false));

                // If word pair does not exist in the list, add it
                // Otherwise, increment the pair count
                if (existingPair == null)
                {
                    wordPairData.Add(new WordPairCountDTO()
                    {
                        Word1 = word1,
                        Word2 = word2,
                        Count = 1
                    });
                }
                else
                {
                    existingPair.Count++;
                }
            }

            // Sort the results in descending order
            wordPairData.Sort((DTO1, DTO2) => DTO2.CompareTo(DTO1));

            return wordPairData;
        }

        #endregion
    }
}
