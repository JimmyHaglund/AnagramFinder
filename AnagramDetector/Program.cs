using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace AnagramDetector {
    internal class Program {
        private static string SamplePath => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"SampleDictionary.txt");

        private static void Main(string[] args) {
            var filePath = args.Length > 0 ? args[0] : SamplePath;
            var reader = new TextFileReader();
            reader.LoadFromFile(filePath);
            var dictionary = new AnagramDictionary();
            dictionary.AddWords(reader.ReadAll());
            
            if (dictionary.MostCommonAnagrams.Count == 0) {
                Console.WriteLine("No anagrams found!");
                return;
            }
            PrintResults(dictionary);
        }

        private static void PrintResults(AnagramDictionary dictionary) {
            var result = dictionary.MostCommonAnagrams;
            var resultCount = dictionary.HighestCount;
            Console.WriteLine($"Number of words in most occuring anagram: {resultCount}.");
            Console.WriteLine($"There were {result.Count} sets of anagrams with this number of words.");
            Console.WriteLine("The anagrams are: ");
            var n = 0;
            foreach (var anagramSet in result) {
                if (result.Count > 1) {
                    Console.WriteLine($"Anagrams in set {n + 1}:");
                }
                PrintAll(anagramSet.Words);
                n++;
            }
        }

        private static void PrintAll(IEnumerable<string> lines) {
            foreach(var line in lines) {
                Console.WriteLine(line);
            }
        }
    }
}
