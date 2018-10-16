using name_sorter.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter.engine
{
    interface ISort
    {
        string[] GetSortedData(List<string> dataToSort, char[] delimiters);
    }
}
