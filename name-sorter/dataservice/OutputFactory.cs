using System.Collections.Generic;

namespace name_sorter.dataservice
{
    public class OutputFactory
    {
        private IFileProcessor _fileProcessor;
        public OutputFactory(IFileProcessor fileProcessor)
        {
            _fileProcessor = fileProcessor;
        }

        /// <summary>
        /// Factory to get all types of output writers.
        /// </summary>
        /// <returns></returns>
        public virtual List<IDataWriter> GetWriters()
        {
            var writers = new List<IDataWriter>();
            var fileWriter = new FileWriter(_fileProcessor);
            var screenWriter = new ScreenWriter();
            writers.Add(fileWriter);
            writers.Add(screenWriter);
            return writers;
        }
    }
}
