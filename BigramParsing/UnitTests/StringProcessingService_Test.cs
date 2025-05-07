using BigramParser.Data;
using BigramParser.Services;

namespace UnitTests
{
    /// <summary>
    /// Unit test class for StringProcessingService.
    /// </summary>
    [TestClass]
    public sealed class StringProcessingService_Test
    {
        #region Constants

        private const string TEST_STRING_SIMPLE_1 = "Unit test";
        private const string TEST_STRING_SIMPLE_2 = "Hello my baby, hello my honey";
        private const string TEST_STRING_SIMPLE_3 = "Karma, karma, karma, karma, karma chameleon";
        private const string TEST_STRING_LEET_SPEAK = "1337 5p34k h3r0";
        private const string TEST_STRING_QUOTES_AND_CONTRACTIONS = "\"He says 'I can't cant'\", but he can.";
        private const string TEST_STRING_SKAVEN_SPEAK = "-- Yes-yes! Warpstone for me-me! Glory-Honour for the Horned Rat! --";
        private const string TEST_STRING_NONSENSE = "g#7'Lp-q2 @v9-T'z!3 m'1$-Xp&4 ^R7*e'W-0 z'8&-L$kQ ~T'z3!-v9 xP@#7-r$'M";

        #endregion

        #region Fields

        IStringProcessingService _stringProcessingService;

        #endregion

        #region Setup/Teardown

        /// <summary>
        /// Sets up the data required for testing.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _stringProcessingService = new StringProcessingService();
        }

        #endregion

        #region Unit Tests

        /// <summary>
        /// Tests that the RemoveNonAlphaCharacters() method can handle an empty string input.
        /// </summary>
        [TestMethod]
        public void RemoveNonAlphaCharacters_NullInput()
        {
            var expected = string.Empty;
            var actual = _stringProcessingService.RemoveNonAlphaCharacters(string.Empty);

            // Validate output text
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the RemoveNonAlphaCharacters() with a given input.
        /// </summary>
        [TestMethod]
        public void RemoveNonAlphaCharacters_TestSimpleParams1()
        {
            var inputString = TEST_STRING_SIMPLE_1;
            var expected = "Unit test";
            var actual = _stringProcessingService.RemoveNonAlphaCharacters(inputString);

            // Validate output text
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the RemoveNonAlphaCharacters() with a given input.
        /// </summary>
        [TestMethod]
        public void RemoveNonAlphaCharacters_TestSimpleParams2()
        {
            var inputString = TEST_STRING_SIMPLE_2;
            var expected = "Hello my baby hello my honey";
            var actual = _stringProcessingService.RemoveNonAlphaCharacters(inputString);

            // Validate output text
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the RemoveNonAlphaCharacters() with a given input.
        /// </summary>
        [TestMethod]
        public void RemoveNonAlphaCharacters_TestSimpleParams3()
        {
            var inputString = TEST_STRING_SIMPLE_3;
            var expected = "Karma karma karma karma karma chameleon";
            var actual = _stringProcessingService.RemoveNonAlphaCharacters(inputString);

            // Validate output text
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the RemoveNonAlphaCharacters() with a given input.
        /// </summary>
        [TestMethod]
        public void RemoveNonAlphaCharacters_TestWithNumbers()
        {
            var inputString = TEST_STRING_LEET_SPEAK;
            var expected = "pk hr";
            var actual = _stringProcessingService.RemoveNonAlphaCharacters(inputString);

            // Validate output text
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the RemoveNonAlphaCharacters() with a given input.
        /// </summary>
        [TestMethod]
        public void RemoveNonAlphaCharacters_TestWithQuotes()
        {
            var inputString = TEST_STRING_QUOTES_AND_CONTRACTIONS;
            var expected = "He says I can't cant but he can";
            var actual = _stringProcessingService.RemoveNonAlphaCharacters(inputString);

            // Validate output text
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the RemoveNonAlphaCharacters() with a given input.
        /// </summary>
        [TestMethod]
        public void RemoveNonAlphaCharacters_TestWithHyphens()
        {
            var inputString = TEST_STRING_SKAVEN_SPEAK;
            var expected = "Yes-yes Warpstone for me-me Glory-Honour for the Horned Rat";
            var actual = _stringProcessingService.RemoveNonAlphaCharacters(inputString);

            // Validate output text
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the RemoveNonAlphaCharacters() with a given input.
        /// </summary>
        [TestMethod]
        public void RemoveNonAlphaCharacters_TestWithMixed()
        {
            var inputString = TEST_STRING_NONSENSE;
            var expected = "gLp-q vT'z mXp Re'W zLkQ T'zv xPrM";
            var actual = _stringProcessingService.RemoveNonAlphaCharacters(inputString);

            // Validate output text
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that the RemoveNonAlphaCharacters() method can handle an empty string input.
        /// </summary>
        [TestMethod]
        public void CreateWordPairDistribution_NullInput()
        {
            var inputString = string.Empty;
            List<WordPairCountDTO> expected = [];
            var actual = _stringProcessingService.CreateWordPairDistribution(inputString);

            // Validate output text
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the RemoveNonAlphaCharacters() with a given input.
        /// </summary>
        [TestMethod]
        public void CreateWordPairDistribution_TestSimpleParams1()
        {
            var inputString = TEST_STRING_SIMPLE_1;
            var expected = new List<WordPairCountDTO>()
            {
                new()
                {
                    Word1 = "unit",
                    Word2 = "test",
                    Count = 1
                }
            };

            var actual = _stringProcessingService.CreateWordPairDistribution(inputString);

            // Validate output text
            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion
    }
}