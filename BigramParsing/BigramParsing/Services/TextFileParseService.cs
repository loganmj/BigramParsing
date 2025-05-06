using System.IO;
using System.Text.RegularExpressions;

namespace BigramParser.Services
{
    /// <summary>
    /// A service for parsing text files (.txt).
    /// </summary>
    public partial class TextFileParseService : ITextFileParseService
    {
        #region Regex

        /// <summary>
        /// A regex filter that removes all non-alphanumeric characters,
        /// leaving letters, numbers, and spaces.
        /// </summary>
        /// <returns></returns>
        [GeneratedRegex("[^a-zA-Z ]")]
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
            return File.ReadAllText(filePath);
        }

        #endregion
    }
}
