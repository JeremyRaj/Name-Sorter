using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter.dataservice
{
    public class ScreenWriter : IDataWriter
    {
        public void WriteData(string[] dataToWrite)
        {
            foreach (var item in dataToWrite)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
