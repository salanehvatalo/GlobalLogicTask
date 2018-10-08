using System.Collections.Generic;

namespace GlobalLogicTask
{
    public interface IPrinter
    {
        void Print(SortedDictionary<string, List<int>> dict);
    }
}
