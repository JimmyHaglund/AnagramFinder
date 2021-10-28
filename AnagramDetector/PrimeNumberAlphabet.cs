using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramDetector {
    static class PrimeNumberAlphabet {
        private static Dictionary<char, int> _alphabet = new Dictionary<char, int>() {
            {'a', 2}, { 'b', 3}, {'c', 5 }, {'d', 7}, {'e', 11 },
            {'f', 13}, { 'g', 17}, {'h', 19 }, {'i', 23}, {'j', 29 },
            {'k', 31}, { 'l', 37}, {'m', 41 }, {'n', 43}, {'o', 47 },
            {'p', 53}, { 'q', 59}, {'r', 61 }, {'s', 67}, {'t', 71 },
            {'u', 73}, { 'v', 79}, {'w', 83 }, {'x', 89}, {'y', 97 },
            {'z', 101}, { 'å', 103}, {'ä', 107 }, {'ö', 109}
        };

        public static int ToNumber(string value) {
            if (value.Length == 0) return 0;
            var result = ToNumber(value[0]);
            for (var n = 1; n < value.Length; n++) {
                result *= ToNumber(value[n]);
            }
            return result;
        }

        private static int ToNumber(char value) {
            return _alphabet[value];
        }
    }
}
