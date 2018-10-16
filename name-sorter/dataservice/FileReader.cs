using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuttingEdge.Conditions;
using name_sorter.engine;
using name_sorter.model;

namespace name_sorter.dataservice
{
    public class FileReader : IDataReader
    {
        private IFileProcessor _fileProcessor;
        private string _fileLocation;
        public FileReader(string fileLocation, IFileProcessor fileProcessor)
        {
            _fileProcessor = fileProcessor;
            _fileLocation = fileLocation;
        }
        public List<string> GetData()
        {
            var data = new List<string>();
            var lines = _fileProcessor.GetFileContents(_fileLocation);

            Condition.Requires(lines, "lines").IsNotNull().IsNotEmpty();

            for (var i = 0; i < lines.Length; i++)
            {
                data.Add(lines[i]);
            }

            return data;
        }
    }
}
