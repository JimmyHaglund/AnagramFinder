using System;
using System.IO;

namespace AnagramDetector {
    class TextFileReader {
        private string[] _value;

        public string[] ReadAll() {
            return _value;
        }

        public void LoadFromFile(string filePath) {
            _value = File.ReadAllLines(filePath);
        }
    }
}
