using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class SelectionSorting
    {
        public static List<int> Sort(IList<int> list)
        {
            if (list?.Any() != true)
            {
                return new List<int>();
            }

            var n = list.Count;

            for (var i = 0; i < n; i++)
            {
                var index = i;
                var min = list[i];

                for (var j = i; j < n; j++)
                {
                    if (min > list[j])
                    {
                        min = list[j];
                        index = j;
                    }
                }

                if (i != index)
                {
                    list.Swap(i, index);
                }
            }

            return list.ToList();
        }

    }
}