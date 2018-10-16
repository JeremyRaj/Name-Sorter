namespace name_sorter.dataservice
{
    public class FileWriter : IDataWriter
    {
        private IFileProcessor _fileProcessor;
        public FileWriter(IFileProcessor fileProcessor)
        {
            _fileProcessor = fileProcessor;
        }

        /// <summary>
        /// Write data to file.
        /// </summary>
        /// <param name="dataToWrite"></param>
        public void WriteData(string[] dataToWrite)
        {
            this._fileProcessor.WriteFileContents(dataToWrite);
        }
    }
}
