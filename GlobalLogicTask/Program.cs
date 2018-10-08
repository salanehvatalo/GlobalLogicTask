using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalLogicTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string mydocpath = Environment.CurrentDirectory;
            string fileName = Path.Combine(mydocpath, "test.txt");
            string outpitFileName = Path.Combine(mydocpath, "output.txt");
            StringOperations oper = new StringOperations(new FilePrinter(outpitFileName));
            oper.PrintIndexText(fileName);
        }
    }
}
