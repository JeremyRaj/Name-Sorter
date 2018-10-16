using System.Collections.Generic;

namespace name_sorter.engine
{
    interface ISort
    {
        string[] GetSortedData(List<string> dataToSort, char[] delimiters);
    }
}
