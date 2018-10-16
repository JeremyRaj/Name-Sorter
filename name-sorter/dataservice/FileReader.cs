using CuttingEdge.Conditions;
using System.Collections.Generic;

namespace name_sorter.dataservice
{
    public class FileReader : IDataReader
    {
        private IFileProcessor _fileProcessor;
        public FileReader(IFileProcessor fileProcessor)
        {
            _fileProcessor = fileProcessor;
        }
        /// <summary>
        /// Get data from file and load into list
        /// </summary>
        /// <returns></returns>
        public List<string> GetData()
        {
            var data = new List<string>();
            var lines = _fileProcessor.GetFileContents();

            Condition.Requires(lines, "File contents").IsNotNull().IsNotEmpty();

            for (var i = 0; i < lines.Length; i++)
            {
                data.Add(lines[i]);
            }

            return data;
        }
    }
}
