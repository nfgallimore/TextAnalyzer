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
            List<string> words = TextAnalyzer.GetWords(text);

            // Assert
            words.Count.ShouldBe(8);
            words.ShouldContain("The");
            words.ShouldContain("quick");
            words.ShouldContain("brown");
            words.ShouldContain("fox");
            words.ShouldContain("jumps");
            words.ShouldContain("over");
            words.ShouldContain("the");
            words.ShouldContain("lazy");
            words.ShouldContain("dog");
        }
    }
}
