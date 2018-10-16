using name_sorter.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter.dataservice
{
    public interface IDataReader
    {
        List<string> GetData();
    }
}
