namespace BigramParser.Data
{
    /// <summary>
    /// A data transfer object for word pairs and their counts.
    /// </summary>
    public class WordPairCountDTO
    {
        #region Properties

        /// <summary>
        /// The first word of the pair.
        /// </summary>
        public string? Word1 { get; set; }

        /// <summary>
        /// The second word of the pair.
        /// </summary>
        public string? Word2 { get; set; }

        /// <summary>
        /// The number of occurrences of this word pair.
        /// </summary>
        public int Count { get; set; }

        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"\"{Word1} {Word2}\": {Count}";
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is WordPairCountDTO other
                   && string.Equals(Word1, other.Word1, StringComparison.OrdinalIgnoreCase)
                   && string.Equals(Word2, other.Word2, StringComparison.OrdinalIgnoreCase)
                   && Count == other.Count;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Word1?.ToLowerInvariant(),
                                    Word2?.ToLowerInvariant(),
                                    Count);
        }


        #endregion
    }
}
