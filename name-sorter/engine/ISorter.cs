using System.Collections.Generic;

namespace name_sorter.engine
{
    interface ISorter
    {
        string[] GetSortedData(List<string> dataToSort, char[] delimiters);
    }
}
