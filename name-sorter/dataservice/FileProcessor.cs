using System;
using System.IO;

namespace name_sorter.dataservice
{
    public class FileProcessor : IFileProcessor
    {
        private string _inputFileLocation;
        private string _outputFileLocation;
        public FileProcessor(string inputFileLocation, string outputFileLocation)
        {
            _inputFileLocation = inputFileLocation;
            _outputFileLocation = outputFileLocation;
        }
        public string[] GetFileContents()
        {
            try
            {
                var contents = File.ReadAllLines(_inputFileLocation);

                return contents;
            }
            catch(Exception ex)
            {
                //to do logging
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public void WriteFileContents(string[] dataToWrite)
        {
            try
            {
                File.WriteAllLines(_outputFileLocation, dataToWrite);
            }
            catch (Exception ex)
            {
                // to do logging
                Console.WriteLine(ex.Message);
            }
        }
    }
}
