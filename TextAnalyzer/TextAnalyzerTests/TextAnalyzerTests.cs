using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextAnalyzer
{
    [TestFixture]
    public class TextAnalyzerShould
    {
        [Test]
        public void GetAllNonAlphaWords()
        {
            // Arrange
            string text = "`~ ** 的  :) The quick   ** @#! brown fox jumps  @#! . >< over the lazy dog. :) بِيَ";

            // Act
            Dictionary<string, int> words = TextAnalyzer.GetWords(text);

            // Assert
            words.Count.ShouldBe(8);
            words["the"].ShouldBe(2);
            words["quick"].ShouldBe(1);
            words["brown"].ShouldBe(1);
            words["fox"].ShouldBe(1);
            words["jumps"].ShouldBe(1);
            words["over"].ShouldBe(1);
            // note omitting "the", should be case insensitive and combine duplicate words
            words["lazy"].ShouldBe(1);
            words["dog"].ShouldBe(1);
        }

        [Test]
        public void RemoveStopWords()
        {
            // Arrange
            List<string> stopWords = new List<string>()
            {
                "foo",
                "bar",
                "baz"
            };

            Dictionary<string, int> dictionaryInput = new Dictionary<string, int>
            {
                { "the", 2 },
                { "quick", 1 },
                { "brown", 1 },
                { "fox", 1 },
                { "jumps", 1 },
                { "over", 1 },
                { "lazy", 1 },
                { "dog", 1 },
                { "foo", 1 },
                { "bar", 2 },
                { "baz", 3 }
            };

            // Act
            Dictionary<string, int> result = TextAnalyzer.RemoveStopWords(dictionaryInput, stopWords);

            // Assert
            result.Count.ShouldBe(8);
            result.ShouldNotContainKey("foo");
            result.ShouldNotContainKey("bar");
            result.ShouldNotContainKey("baz");
            result.ShouldContain(new KeyValuePair<string, int>("the", 2));
            result.ShouldContain(new KeyValuePair<string, int>("quick", 1));
            result.ShouldContain(new KeyValuePair<string, int>("brown", 1));
            result.ShouldContain(new KeyValuePair<string, int>("fox", 1));
            result.ShouldContain(new KeyValuePair<string, int>("jumps", 1));
            result.ShouldContain(new KeyValuePair<string, int>("over", 1));
            result.ShouldContain(new KeyValuePair<string, int>("lazy", 1));
            result.ShouldContain(new KeyValuePair<string, int>("dog", 1));
        }
    }
}
