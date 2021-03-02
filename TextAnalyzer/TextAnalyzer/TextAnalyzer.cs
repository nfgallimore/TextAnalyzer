using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextAnalyzer
{
    public class TextAnalyzer
    {
        public static string ReadFile(string filepath)
        {
            try
            {
                string content = "";
                using (StreamReader stringReader = File.OpenText(filepath))
                {
                    string line;
                    while ((line = stringReader.ReadLine()) != null)
                    {
                        content += line;
                    }
                }

                return content;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"{filepath} was not found!");
                return "";
            }
        }

        public static List<string> GetStopWords(string filepath)
        {
            List<string> words = new List<string>();
            try
            {
                using (StreamReader stringReader = File.OpenText(filepath))
                {
                    string line;
                    while ((line = stringReader.ReadLine()) != null)
                    {
                        words.Add(line);
                    }
                }

                return words;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"{filepath} was not found!");
                return words;
            }
        }

        public static Dictionary<string, int> GetAlphabeticWordsFromString(string text)
        {
            text = text.ToLower();

            Regex notAlphaOrSpace = new Regex("[^a-zA-Z\\s]");
            text = notAlphaOrSpace.Replace(text, string.Empty);

            string[] words = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word]++;
                } 
                else
                {
                    dictionary.Add(word, 1);
                }
            }

            return dictionary;
        }

        public static Dictionary<string, int> RemoveStopWords(Dictionary<string, int> dictionary, List<string> stopWords)
        {
            foreach(string key in dictionary.Keys)
            {
                if (stopWords.Contains(key))
                {
                    dictionary.Remove(key);
                }
            }
            return dictionary;
        }

        public static Dictionary<string, int> StemWords(Dictionary<string, int> dictionary)
        {
            PorterStemmer porterStemmer = new PorterStemmer();

            Dictionary<string, int> stemDictionary = new Dictionary<string, int>();

            foreach(KeyValuePair<string, int> word in dictionary)
            {
                string stem = porterStemmer.StemWord(word.Key);
                if (stemDictionary.ContainsKey(stem))
                {
                    stemDictionary[stem] += word.Value;
                }
                else
                {
                    stemDictionary.Add(stem, word.Value);
                }
            }

            return stemDictionary;
        }

        public static string PrintableAnalysis(Dictionary<string, int> words)
        {
            // Order by the word alphabetically ascending first, then order by word frequency
            Dictionary<string, int> orderedWords = words.OrderBy(word => word.Key).OrderByDescending(word => word.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            string output = "";

            for (int i = 0; i < 20; i++)
            {
                KeyValuePair<string, int> word = orderedWords.ElementAt(i);
                output += $"{word.Key} {word.Value}\n";
            }

            return output;
        }
    }
}
