using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter.dataservice
{
    public class FileProcessor : IFileProcessor
    {
        public string[] GetFileContents(string fileLocation)
        {
            Condition.Requires(fileLocation, "fileLocation").IsNotNullOrEmpty();

            var contents = File.ReadAllLines(fileLocation);
           
            return contents;
        }
    }
}
