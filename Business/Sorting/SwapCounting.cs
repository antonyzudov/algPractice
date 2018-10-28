using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Business
{
    [Description("https://www.hackerrank.com/challenges/lilys-homework/problem")]
    public static class SwapCounting
    {
        public static int lilysHomework(int[] arr)
        {
            if (arr?.Any() != true)
            {
                return 0;
            }

            var ascendingList = arr.ToList();
            ascendingList.Sort();

            var descendingList = new List<int>();
            for (var i = ascendingList.Count - 1; i >= 0; i--)
            {
                descendingList.Add(ascendingList[i]);
            }

            var ascendingResult = GetSwapCount(arr, ascendingList);
            var descendingResult = GetSwapCount(arr, descendingList);

            return Math.Min(ascendingResult, descendingResult);
        }

        private static int GetSwapCount(int[] arr, IList<int> sortedList)
        {
            var list = arr.ToList();

            var result = 0;

            var dict = new Dictionary<int, int>();
            for (var i = 0; i < list.Count; i++)
            {
                dict.Add(list[i], i);
            }

            for (var i = 0; i < list.Count; i++)
            {
                if (list[i] != sortedList[i])
                {
                    result++;

                    var buf = list[dict[sortedList[i]]];
                    list[dict[sortedList[i]]] = list[i];
                    dict[list[i]] = dict[sortedList[i]];
                    list[i] = buf;
                }
            }

            return result;
        }
    }
}
