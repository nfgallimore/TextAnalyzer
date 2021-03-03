using System;
using System.Collections.Generic;
using System.IO;

namespace TextAnalyzer
{
    public class Program
    {
        private const string DIRECTORY = "../../../../../";

        static void Main(string[] args)
        {
            string alice = TextAnalyzer.ReadFile(DIRECTORY + "Text1.txt");
            string declaration = TextAnalyzer.ReadFile(DIRECTORY + "Text2.txt");

            if (string.IsNullOrEmpty(alice) || string.IsNullOrEmpty(declaration))
            {
                Console.WriteLine("File contents were empty or not found");
                return;
            }

            Dictionary<string, int> aliceAnalysis = AnalyzeString(alice);
            Dictionary<string, int> declarationAnalysis = AnalyzeString(declaration);

            Console.WriteLine(TextAnalyzer.PrintableAnalysis(aliceAnalysis));
            Console.WriteLine(TextAnalyzer.PrintableAnalysis(declarationAnalysis));
        }

        private static Dictionary<string, int> AnalyzeString(string input)
        {
            List<string> stopWords = TextAnalyzer.GetStopWords(DIRECTORY + "stopwords.txt");
            Dictionary<string, int> alphabeticWords = TextAnalyzer.GetAlphabeticWordsFromString(input);
            Dictionary<string, int> alphabeticWordsWithoutStopwords = TextAnalyzer.RemoveStopWords(alphabeticWords, stopWords);
            Dictionary<string, int> stemmedWords = TextAnalyzer.StemWords(alphabeticWordsWithoutStopwords);

            return stemmedWords;
        }
    }
}
