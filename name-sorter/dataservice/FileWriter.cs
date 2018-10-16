using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter.dataservice
{
    public class FileWriter : IDataWriter
    {
        private readonly string _fileLocation;
        public FileWriter(string fileLocation)
        {
            _fileLocation = fileLocation;
        }

        public void WriteData(string[] dataToWrite)
        {
            try
            {
                File.WriteAllLines(_fileLocation, dataToWrite);
            }
            catch (Exception ex)
            {
                // to do logging
            }
        }
    }
}
