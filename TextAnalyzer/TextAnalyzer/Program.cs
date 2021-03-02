using System;
using System.Collections.Generic;
using System.IO;

namespace TextAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string alice = TextAnalyzer.ReadFile("../../../../../Text1.txt");
            string declaration = TextAnalyzer.ReadFile("../../../../../Text2.txt");

            if (string.IsNullOrEmpty(alice) || string.IsNullOrEmpty(declaration))
            {
                Console.WriteLine($"File contents were empty or not found");
                return;
            }

            Console.WriteLine(alice);
        }
    }
}
