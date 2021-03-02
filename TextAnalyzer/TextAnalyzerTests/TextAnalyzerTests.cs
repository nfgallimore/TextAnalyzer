using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
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
    }
}
