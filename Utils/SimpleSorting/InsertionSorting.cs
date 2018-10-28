using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class InsertionSorting
    {
        public static List<int> Sort(IList<int> list)
        {
            if (list?.Any() != true)
            {
                return new List<int>();
            }

            var n = list.Count;

            for (var i = 1; i < n; i++)
            {
                var index = 0;
                var current = list[i];

                for (; index < i; index++)
                {
                    if (list[index] > current)
                    {
                        break;
                    }
                }

                for (var j = i - 1; j >= index; j--)
                {
                    list[j + 1] = list[j];
                }

                list[index] = current;
            }

            return list.ToList();
        }
    }
}
