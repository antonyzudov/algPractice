using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Business
{
    [Description("https://www.hackerrank.com/challenges/countingsort4/problem")]
    public static class countSort
    {
        public static string StableCountingSort(List<List<string>> arr)
        {
            var halfLength = (int) arr.Count / 2;

            for (var i = 0; i < halfLength; i++)
            {
                arr[i][1] = "-";
            }

            const int k = 100;

            var b = new List<List<string>>();
            foreach (var ai in arr)
            {
                b.Add(new List<string>());
            }

            var c = new List<int>();
            for (var i = 0; i < k; i++)
            {
                c.Add(0);
            }

            foreach (var ai in arr)
            {
                c[Convert.ToInt16(ai[0])] += 1;
            }

            for (var j = 1; j < k; j++)
            {
                c[j] += c[j - 1];
            }

            for (var i = arr.Count - 1; i >= 0; i--)
            {
                var ind = Convert.ToInt16(arr[i][0]);
                c[ind] -= 1;
                b[c[ind]] = arr[i];
            }

            return string.Join(" ", b.Select(x => x[1]).ToList());
        }
    }
}