using System;
using System.Collections.Generic;

namespace GlobalLogicTask
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(SortedDictionary<string, List<int>> dict)
        {
            foreach (var item in dict)
            {
                Console.Write(item.Key + " - ");
                PrintCollection(item.Value);
                Console.WriteLine();
            }
        }
        public void PrintCollection(List<int> col)
        {
            Console.Write(col[0]);
            for (int i = 1; i < col.Count; i++)
            {
                Console.Write(", " + col[i]);
            }
        }
    }
}
