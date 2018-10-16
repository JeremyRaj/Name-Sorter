using name_sorter.dataservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter.dataservice
{
    public class OutputFactory
    {
        private readonly string _outputFileLocation;
        public OutputFactory(string fileLocation)
        {
            _outputFileLocation = fileLocation;
        }
        public virtual IDataWriter GetWriters()
        {
            IDataWriter dataWriter = null;
            dataWriter = new FileWriter(_outputFileLocation);
            dataWriter = new ScreenWriter();
            return dataWriter;
        }
    }
}
