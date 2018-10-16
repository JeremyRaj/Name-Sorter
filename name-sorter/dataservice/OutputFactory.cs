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
        public virtual IDataWriter GetWriters()
        {
            IDataWriter dataWriter = null;
            dataWriter = new FileWriter(_fileProcessor);
            dataWriter = new ScreenWriter();
            return dataWriter;
        }
    }
}
