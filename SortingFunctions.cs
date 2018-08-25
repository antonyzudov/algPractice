using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace algPractice
{
    [Description("https://www.hackerrank.com/challenges/big-sorting/problem")]
    public class SortingFunctions
    {
        public static string[] bigSorting(string[] unsorted)
        {
            var list = unsorted.ToList();

            list.Sort((Comparison<string>) Compare);

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

        public static List<string> InsertionSort1(int[] arr)
        {
            var result = new List<string>();

            var n = arr.Length;

            for (var i = n - 1; i >= 1; i--)
            {
                var x = arr[i];
                var j = i - 1;

                while (j >= 0 && arr[j] > x)
                {
                    arr[j + 1] = arr[j];

                    result.Add(arr.ToResultString());

                    j--;
                }

                if (arr[j + 1] != x)
                {
                    arr[j + 1] = x;
                    result.Add(arr.ToResultString());
                }
            }

            return result;
        }
    }

    public static class ArrExtensions
    {
        public static string ToResultString(this int[] arr)
        {
            var n = arr.Length;
            var s = "";
            for (int k = 0; k < n; k++)
            {
                s += k == n - 1
                    ? arr[k].ToString()
                    : arr[k] + " ";
            }
            return s;
        }
    }
}