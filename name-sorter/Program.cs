using name_sorter.dataservice;
using name_sorter.engine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    class Program
    {
        static void Main(string[] args)
        {

            var directory = Path.GetDirectoryName((Path.GetDirectoryName(Environment.CurrentDirectory)));
            var inputfileLocation = directory + "\\unsorted-names-list.txt";
            var outputfileLocation = directory + "\\sorted-names-list.txt";
            var fileProcessor = new FileProcessor();

            IDataReader inputFile = new FileReader(inputfileLocation, fileProcessor);
            char[] delimiters = new char[] { ' ' };

            var data = inputFile.GetData();

            ISort sortEngine = new Sort();
            var sortedList = sortEngine.GetSortedData(data, delimiters);


            // use a factory. We can extend the factory to support other outputs if required.Open/Closed principal
            var output = new OutputFactory(outputfileLocation);
            output.GetWriters().WriteData(sortedList);
        }
    }
}
