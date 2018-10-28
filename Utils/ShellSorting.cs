using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class ShellSorting
    {
        public static List<int> Sort(IList<int> list)
        {
            if (list?.Any() != true)
            {
                return new List<int>();
            }

            var d = GetNextDistance(list.Count());

            while (d >= 1)
            {
                for (var i = 0; i < d; i++)
                {
                    InsertionSort(list, i, d);
                }

                d = GetNextDistance(d);
            }

            return list.ToList();
        }

        private static int GetNextDistance(int d)
        {
            return d / 2;
        }


        private static List<int> InsertionSort(IList<int> list, int start, int d)
        {
            if (list?.Any() != true)
            {
                return new List<int>();
            }

            var n = list.Count;

            for (var i = start + d; i < n; i += d)
            {
                var index = start;
                var current = list[i];

                for (; index < i; index += d)
                {
                    if (list[index] > current)
                    {
                        break;
                    }
                }

                for (var j = i - d; j >= index; j -= d)
                {
                    list[j + d] = list[j];
                }

                list[index] = current;
            }

            return list.ToList();
        }
    }
}
