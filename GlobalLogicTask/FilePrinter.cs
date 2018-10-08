using System.Collections.Generic;
using System.IO;

namespace GlobalLogicTask
{
    public class FilePrinter : IPrinter
    {
        private string fileName;

        public FilePrinter(string fileName)
        {
            this.fileName = fileName;
        }

        public void Print(SortedDictionary<string, List<int>> dict)
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                foreach (var item in dict)
                {
                    outputFile.Write(item.Key + " - ");
                    PrintCollection(item.Value, outputFile);
                    outputFile.WriteLine();
                }
            }
        }
        public void PrintCollection(List<int> col, StreamWriter outputFile)
        {
            outputFile.Write(col[0]);
            for (int i = 1; i < col.Count; i++)
            {
                outputFile.Write(", " + col[i]);
            }
        }
    }
}
