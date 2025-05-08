using System.IO;

namespace BigramParser.Services
{
    /// <summary>
    /// A service for parsing text files (.txt).
    /// </summary>
    public partial class TextFileParseService : ITextFileParseService
    {
        #region Public Methods

        /// <inheritdoc/>
        public string Parse(string filePath)
        {
            // Validate inputs
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File does not exist at path '{filePath}'.");
                return string.Empty;
            }

            // Parse the file
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
                return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return string.Empty;
            }
        }

        #endregion
    }
}
