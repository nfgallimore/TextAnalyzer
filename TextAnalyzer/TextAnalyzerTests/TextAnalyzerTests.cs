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
        public void GetAllAlphabeticWordsFromString()
        {
            // Arrange
            string text = "`~ ** 的  :) The quick   ** @#! brown fox jumps  @#! . >< over the lazy dog. :) بِيَ";

            // Act
            Dictionary<string, int> words = TextAnalyzer.GetAlphabeticWordsFromString(text);

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

        [Test]
        public void RecordFrequencyForAllStemsOfWord()
        {
            // Arrange
            Dictionary<string, int> dictionaryInput = new Dictionary<string, int>
            {
                { "jumping", 2 },
                { "jump", 1 },
                { "jumped", 4 },
                { "jumps", 1 },
                { "run", 2 },
                { "running", 3 },
                { "runs", 1 }
            };

            // Act
            Dictionary<string, int> result = TextAnalyzer.StemWords(dictionaryInput);

            // Assert
            result.Count.ShouldBe(2);
            result.ShouldContainKey("jump");
            result.ShouldContainKey("run");
            result["jump"].ShouldBe(8);
            result["run"].ShouldBe(6);
        }

        [Test]
        public void CreateStringToPrintThe20MostCommonWordsInDescendingOrder()
        {
            // Arrange

            // note when there is a tie between two words that have same frequency, the word that comes first alphabetically wins
            Dictionary<string, int> words = new Dictionary<string, int>
            {
                { "apple", 999 },
                { "bananna", 999 },
                { "cucumber", 999 },
                { "jump", 1 },
                { "run", 2 },
                { "walk", 3 },
                { "swim", 4 },
                { "float", 5 },
                { "boat", 6 },
                { "fly", 7 },
                { "drive", 8 },
                { "tiptoe", 9 },
                { "sneak", 10 },
                { "venture", 11 },
                { "orange", 12 },
                { "tomato", 13 },
                { "kiwi", 14 },
                { "strawberry", 15 },
                { "mango", 16 },
                { "coconut", 17 },
                { "pineapple", 18 },
                { "blueberry", 19 },
                { "raspberry", 20 },
                { "grape", 21 },
                { "airplane", 22 },
                { "coffee", 23 },
                { "sleep", 24 },
                { "bed", 25 },
                { "wake", 26 },
                { "dream", 27 },
                { "wish", 28 },
                { "hope", 29 },
                { "strive", 30 }
            };

            // Act
            string result = TextAnalyzer.PrintableAnalysis(words);
            string[] resultSplit = result.Split("\n");

            // Assert
            resultSplit[0].ShouldBe("apple 999");
            resultSplit[1].ShouldBe("bananna 999");
            resultSplit[2].ShouldBe("cucumber 999");
            resultSplit[3].ShouldBe("strive 30");
            resultSplit[4].ShouldBe("hope 29");
            resultSplit[5].ShouldBe("wish 28");
            resultSplit[6].ShouldBe("dream 27");
            resultSplit[7].ShouldBe("wake 26");
            resultSplit[8].ShouldBe("bed 25");
            resultSplit[9].ShouldBe("sleep 24");
            resultSplit[10].ShouldBe("coffee 23");
            resultSplit[11].ShouldBe("airplane 22");
            resultSplit[12].ShouldBe("grape 21");
            resultSplit[13].ShouldBe("raspberry 20");
            resultSplit[14].ShouldBe("blueberry 19");
            resultSplit[15].ShouldBe("pineapple 18");
            resultSplit[16].ShouldBe("coconut 17");
            resultSplit[17].ShouldBe("mango 16");
            resultSplit[18].ShouldBe("strawberry 15");
            resultSplit[19].ShouldBe("kiwi 14");
            resultSplit[20].ShouldBe("tomato 13");
        }
    }
}
