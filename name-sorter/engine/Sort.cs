using CuttingEdge.Conditions;
using name_sorter.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter.engine
{
    public class Sort : ISort
    {
        public string[] GetSortedData(List<string> dataToSort, char[] delimiters)
        {
            var reversedList = new List<Name>();

            Condition.Requires(dataToSort, "dataToSort").IsNotNull().IsNotEmpty();
            Condition.Requires(delimiters, "delimiters").IsNotNull().IsNotEmpty();

            foreach (var data in dataToSort)
            {
                string[] parts = data.Split(delimiters);

                Name name = new Name();

                for (int i = 0; i < parts.Length; i++)
                {
                    if (i == parts.Length - 1)
                    {
                        name.LastName = parts[i];
                    }
                    else
                    {
                        name.GivenName += parts[i] + " ";
                    }
                }

                // lets remove extra whitespaces
                var givenName = name.GivenName.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s));
                name.GivenName = string.Join(" ", givenName);

                reversedList.Add(name);
            }

            var sortedList = reversedList.OrderBy(s => s.LastName).ThenBy(s => s.GivenName)
                .Select(i => (i.GivenName + " " + i.LastName).ToString()).ToArray();


            return sortedList;
        }
    }
}
