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
        /// Isolates all numbers and special characters from a string with the following exceptions:
        /// - Any hyphens that are part of a compound word
        /// - Any apostrophe that is part of a contraction
        /// Regex breakdown:
        /// - (?<![a-zA-Z])['\-]: Matches ' or - not preceded by a letter
        /// - ['\-](?![a-zA-Z]): Matches ' or - not followed by a letter.
        /// - [^a-zA-Z'\- ]: Matches any character that is not a letter, apostrophe, hyphen, or space.
        /// </summary>
        /// <returns></returns>
        [GeneratedRegex(@"(?<![a-zA-Z])['\-]|['\-](?![a-zA-Z])|[^a-zA-Z'\- ]")]
        private static partial Regex SpecialCharactersRegex();



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

            // Filter out all unwanted characters from the text
            filteredText = SpecialCharactersRegex().Replace(filteredText, "");

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

            // Iterate through words to form pairs and count them
            var wordPairCounts = new Dictionary<(string, string), int>();

            for (int i = 0; i < words.Length - 1; i++)
            {
                var word1 = words[i];
                var word2 = words[i + 1];
                var pair = (word1, word2);

                // If the map contains the word pair, increment the value at that entry
                // Otherwise, add an entry for the pair
                if (wordPairCounts.TryGetValue(pair, out int value))
                {
                    wordPairCounts[pair] = ++value;
                }
                else
                {
                    wordPairCounts.Add(pair, 1);
                }
            }

            // Convert dictionary to list of DTOs
            var result = wordPairCounts.Select(pairData => new WordPairCountDTO
            {
                Word1 = pairData.Key.Item1,
                Word2 = pairData.Key.Item2,
                Count = pairData.Value
            })
                .OrderByDescending(dto => dto.Count)
                .ToList();

            return result;
        }

        #endregion
    }
}
