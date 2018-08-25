using System.Collections.Generic;
using System.ComponentModel;

namespace algPractice
{
    [Description("https://www.hackerrank.com/challenges/insertionsort1/problem")]
    public class InsertionSort1
    {
        public static List<string> Sort(int[] arr)
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

                    result.Add(ToResultString(arr));

                    j--;
                }

                if (arr[j + 1] != x)
                {
                    arr[j + 1] = x;
                    result.Add(ToResultString(arr));
                }
            }

            return result;
        }

        private static string ToResultString(int[] arr)
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
