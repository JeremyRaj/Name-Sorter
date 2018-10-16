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
            var inputfileLocation = args[0];

            if (string.IsNullOrEmpty(inputfileLocation))
            {
                Console.WriteLine("Error. Please provide a file path");
                Console.ReadLine();
                Environment.Exit(0);
            }
            var directory = Path.GetDirectoryName((Path.GetDirectoryName(Environment.CurrentDirectory)));

            var outputfileLocation = directory + "\\sorted-names-list.txt";

            var fileProcessor = new FileProcessor(inputfileLocation, outputfileLocation);
            IDataReader inputFile = new FileReader(fileProcessor);

            var data = inputFile.GetData();

            ISort sortEngine = new Sort();
            var sortedList = sortEngine.GetSortedData(data, new char[] { ' ' });

            // use a factory. We can extend the factory to support sending to other outputs if required.Open/Closed principal
            var output = new OutputFactory(fileProcessor);
            foreach (var writers in output.GetWriters())
            {
                writers.WriteData(sortedList);
            }
        }
    }
}
