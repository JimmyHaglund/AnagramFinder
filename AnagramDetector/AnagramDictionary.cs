using System.Collections.Generic;

namespace AnagramDetector {
    class AnagramDictionary {
        public class AnagramSet {
            private LinkedList<string> _words = new LinkedList<string>();
            public int WordCount => _words.Count;
            public IEnumerable<string> Words => _words;

            public void Add(string word) {
                _words.AddLast(word);
            }
        }
        private Dictionary<int, AnagramSet> _anagrams = new Dictionary<int, AnagramSet>();
        private int highestWordCount = 2;
        private LinkedList<AnagramSet> _mostCommonAnagrams = new LinkedList<AnagramSet>();

        public ICollection<AnagramSet> MostCommonAnagrams => _mostCommonAnagrams;
        public int HighestCount => highestWordCount;

        public void AddWords(string[] words) {
            foreach (var word in words) {
                AddWord(word);
            }
        }

        public void AddWord(string word) {
            var anagramValue = PrimeNumberAlphabet.ToNumber(word);
            AnagramSet anagram;
            if (!_anagrams.TryGetValue(anagramValue, out anagram)) {
                anagram = new AnagramSet();
                _anagrams.Add(anagramValue, anagram);
            }
            anagram.Add(word);
            RecountMostCommon(_anagrams[anagramValue]);
        }

        private void RecountMostCommon(AnagramSet value) {
            if (value.WordCount < highestWordCount) return;
            if (value.WordCount > highestWordCount) {
                highestWordCount = value.WordCount;
                _mostCommonAnagrams = new LinkedList<AnagramSet>();
            }
            _mostCommonAnagrams.AddLast(value);
        }
    }
}