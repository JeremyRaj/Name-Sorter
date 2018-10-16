using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter.dataservice
{
    public interface IFileProcessor
    {
        string[] GetFileContents(string fileLocation);
    }
}
