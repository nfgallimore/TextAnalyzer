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

        public static Dictionary<string, int> GetWords(string text)
        {
            text = text.ToLower();

            Regex notAlphaOrSpace = new Regex("[^a-zA-Z\\s]");
            text = notAlphaOrSpace.Replace(text, string.Empty);

            string[] words = text.Split(' ');

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

            dictionary.Remove(string.Empty);
            return dictionary;
        }
    }
}
