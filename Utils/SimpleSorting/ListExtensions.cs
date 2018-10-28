using System.Collections.Generic;

namespace Utils
{
    public static class ListExtensions
    {
        public static void Swap(this IList<int> list, int i, int j)
        {
            if (i == j)
            {
                return;
            }

            var buf = list[i];
            list[i] = list[j];
            list[j] = buf;
        }
    }
}
