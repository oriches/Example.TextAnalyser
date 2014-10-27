namespace Example.TextAnalyser.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class TextHelperFixtures
    {
        [Test]
        public void null_text_returns_no_words()
        {
            // GIVEN
            // WHEN
            var results = TextHelper.WordCount(null);

            // THEN
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void empty_text_returns_no_words()
        {
            // GIVEN
            var text = string.Empty;

            // WHEN
            var results = TextHelper.WordCount(text);

            // THEN
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void whitespace_text_returns_no_words()
        {
            // GIVEN
            var text = "     ";

            // WHEN
            var results = TextHelper.WordCount(text);

            // THEN
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void text_with_some_capital_letters_returns_words()
        {
            // GIVEN
            var text = "text Text text this IS is THis TEXT";

            var expectedResult = new Dictionary<string, int>
                                 {
                                     { "text", 4 },
                                     { "this", 2 },
                                     { "is", 2 },
                                 };
            // WHEN
            var results = TextHelper.WordCount(text);

            // THEN
            Assert.That(results.SequenceEqual(expectedResult), Is.True);
        }

        [Test]
        public void text_with_spurious_spaces_returns_words()
        {
            // GIVEN
            var text = "text   with extra spaces  in  the   text";

            var expectedResult = new Dictionary<string, int>
                                 {
                                     { "text", 2 },
                                     { "with", 1 },
                                     { "extra", 1 },
                                     { "spaces", 1 },
                                     { "in", 1 },
                                     { "the", 1 },
                                 };
            // WHEN
            var results = TextHelper.WordCount(text);

            // THEN
            Assert.That(results.SequenceEqual(expectedResult), Is.True);
        }
        
        [Test]
        public void text_with_no_punctuation_returns_words()
        {
            // GIVEN
            var text = "text text text this is is";

            var expectedResult = new Dictionary<string, int>
                                 {
                                     { "text", 3 },
                                     { "this", 1 },
                                     { "is", 2 },
                                 };
            // WHEN
            var results = TextHelper.WordCount(text);

            // THEN
            Assert.That(results.SequenceEqual(expectedResult), Is.True);
        }

        [Test]
        public void text_with_punctuation_return_words()
        {
            // GIVEN
            var text = "This is a statement, and so is this.";

            var expectedResult = new Dictionary<string, int>
                                 {
                                     { "this", 2 },
                                     { "is", 2 },
                                     { "a", 1 },
                                     { "statement", 1 },
                                     { "and", 1 },
                                     { "so", 1 },
                                 };
            // WHEN
            var results = TextHelper.WordCount(text);

            // THEN
            Assert.That(results.SequenceEqual(expectedResult), Is.True);
        }
    }
}
