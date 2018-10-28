using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class CountingSorting
    {
        public static List<int> Sort(IList<int> list, int maxValue)
        {
            if (list?.Any() != true || maxValue <= 0)
            {
                return new List<int>();
            }

            var counts = Enumerable
                .Range(0, maxValue + 1)
                .Select(x => 0)
                .ToList();

            foreach(var x in list)
            {
                counts[x]++;
            }

            var result = new List<int>();

            for (var i = 0; i <= maxValue; i++)
            {
                for (var j = 0; j < counts[i]; j++)
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}
