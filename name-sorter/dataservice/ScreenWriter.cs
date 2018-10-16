using System;

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
