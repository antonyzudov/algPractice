using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Business.Arrays
{
    [Description("https://www.hackerrank.com/challenges/array-left-rotation/problem")]
    public static class ArrayLeftRotation
    {
        public static List<int> LeftRotate(IList<int> list, int d)
        {
            if (list?.Any() != true)
            {
                return new List<int>();
            }

            var n = list.Count;

            var result = new List<int>();
            for (var i = 0; i < n; i++)
            {
                result.Add(0);
            }

            for (var i = 0; i < n; i++)
            {
                var index = GetIndex(i, d, n);

                result[index] = list[i];
            }

            return result;
        }

        private static int GetIndex(int i, int d, int n)
        {
            var index = i - d;

            if (index < 0)
            {
                index += n;
            }

            return index;
        }
    }
}
