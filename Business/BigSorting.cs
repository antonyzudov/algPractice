using System.ComponentModel;
using System.Linq;

namespace Business
{
    [Description("https://www.hackerrank.com/challenges/big-sorting/problem")]
    public class BigSorting
    {
        public static string[] bigSorting(string[] unsorted)
        {
            var list = unsorted.ToList();

            list.Sort(Compare);

            return list.ToArray();
        }

        private static int Compare(string x, string y)
        {
            if (x == y || string.IsNullOrEmpty(x) && string.IsNullOrEmpty(y))
            {
                return 0;
            }

            var xLength = (x?.Length).GetValueOrDefault(0);
            var yLength = (y?.Length).GetValueOrDefault(0);

            if (xLength < yLength)
            {
                return -1;
            }

            if (xLength > yLength)
            {
                return 1;
            }

            return CompareStringsWithSameLength(x, y);
        }

        private static int CompareStringsWithSameLength(string x, string y)
        {
            while (true)
            {
                if (string.IsNullOrEmpty(x))
                {
                    return 0;
                }

                if (x[0] < y[0])
                {
                    return -1;
                }

                if (x[0] > y[0])
                {
                    return 1;
                }

                x = x.Substring(1);
                y = y.Substring(1);
            }
        }
    }
}