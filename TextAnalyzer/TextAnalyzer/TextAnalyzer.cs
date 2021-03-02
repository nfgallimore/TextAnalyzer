using System;
using System.Collections.Generic;
using System.IO;

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

        public static List<string> GetWords(string input)
        {
            //MatchCollection matches = notAlpha.Matches(text);
            //bool isMatch = notAlpha.IsMatch(text);
            return new List<string>();
        }
    }
}
