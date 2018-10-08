using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GlobalLogicTask
{
    public class StringOperations
    {
        private IPrinter _printer;

        public StringOperations(IPrinter printer)
        {
            this._printer = printer;
        }
        
        public void PrintIndexText(string fileName)
        {
            _printer.Print(ReadAndSaveToDict(fileName));
        }

        private SortedDictionary<string, List<int>> ReadAndSaveToDict(string fileName)
        {
            int lineNumber = 0;
            SortedDictionary<string, List<int>> wordsToLinesPosDictionary = new SortedDictionary<string, List<int>>();
            using (var fileStream = File.OpenRead(fileName))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        lineNumber++;
                        SaveLineToDictByWords(Simplify(line), lineNumber, wordsToLinesPosDictionary);
                    }
                }
            return wordsToLinesPosDictionary;
        }

        private void SaveLineToDictByWords(string[] words, int lineNumber, SortedDictionary<string, List<int>> wordsToLinesPosDictionary)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (wordsToLinesPosDictionary.TryGetValue(words[i], out List<int> value))
                {
                    value.Add(lineNumber);
                }
                else
                {
                    wordsToLinesPosDictionary.Add(words[i], new List<int> { lineNumber });
                }
            }
        }

        private static string[] Simplify(string text)
        {
            return new string(text.Where(c => !(char.IsPunctuation(c))).ToArray()).ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
