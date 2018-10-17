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
            try
            {
                var inputfile = args[0];

                if (string.IsNullOrEmpty(inputfile))
                {
                    Console.WriteLine("Error. Please provide a file path");
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                var inputfileLocation = Environment.CurrentDirectory + "\\" + inputfile.Replace("./", "");
                var outputfileLocation = Environment.CurrentDirectory + "\\sorted-names-list.txt";

                var fileProcessor = new FileProcessor(inputfileLocation, outputfileLocation);
                IDataReader inputFile = new FileReader(fileProcessor);

                var data = inputFile.GetData();

                ISorter sortEngine = new Sorter();
                var sortedList = sortEngine.GetSortedData(data, new char[] { ' ' });

                // use a factory. We can extend the factory to support sending to other outputs if required.Open/Closed principal
                var output = new OutputFactory(fileProcessor);
                foreach (var writers in output.GetWriters())
                {
                    writers.WriteData(sortedList);
                }
            }

            catch (Exception ex)
            {
                // to do logging
                Console.WriteLine(ex.Message);

            }
        }

    }
}
