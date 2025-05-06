using System.IO;
using System.Text.RegularExpressions;

namespace BigramParser.Services
{
    /// <summary>
    /// A service for parsing text files (.txt).
    /// </summary>
    public partial class TextFileParseService : IFileParseService
    {
        #region Regex

        /// <summary>
        /// A regex filter that removes all non-alphanumeric characters,
        /// leaving letters, numbers, and spaces.
        /// </summary>
        /// <returns></returns>
        [GeneratedRegex("[^a-zA-Z0-9 ]")]
        private static partial Regex AlphaNumericRegex();

        /// <summary>
        /// A regex filter that finds all instances of one or more successive space characters.
        /// </summary>
        /// <returns></returns>
        [GeneratedRegex(@"\s+")]
        private static partial Regex MultipleSpacesRegex();

        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public string Parse(string filePath)
        {
            // Validate inputs
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File does not exist at path {filePath}");
                return string.Empty;
            }

            // Parse the file and replace newline characters with spaces
            var content = File.ReadAllText(filePath)
                .Replace("\r\n", " ")
                .Replace("\n", " ")
                .Replace("\r", " ");


            // Remove all characters except letters, digits, and spaces
            content = AlphaNumericRegex().Replace(content, "");

            // Replace multiple spaces with a single space
            content = MultipleSpacesRegex().Replace(content, " ").Trim();

            return content;
        }

        #endregion
    }
}
