using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class BubbleSorting
    {
        public static List<int> Sort(IList<int> list)
        {
            if (list?.Any() != true)
            {
                return new List<int>();
            }

            var n = list.Count;

            var sorted = false;

            while(!sorted)
            {
                sorted = true;

                for (var i = 1; i < n; i++)
                {
                    if (list[i - 1] > list[i])
                    {
                        list.Swap(i - 1, i);
                        sorted = false;
                    }
                }
            }

            return list.ToList();
        }
    }
}
