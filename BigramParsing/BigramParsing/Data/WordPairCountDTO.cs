namespace BigramParser.Data
{
    /// <summary>
    /// A data transfer object for word pairs and their counts.
    /// </summary>
    public class WordPairCountDTO : IComparable<WordPairCountDTO>
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


        /// <summary>
        /// Compares this instance with another WordPairCountDTO based on Count.
        /// </summary>
        public int CompareTo(WordPairCountDTO? other)
        {
            if (other == null) return 1;
            return Count.CompareTo(other.Count);
        }


        #endregion
    }
}
