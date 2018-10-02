using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Business
{
    [Description("https://www.hackerrank.com/challenges/insertion-sort/problem")]
    public static class insertionSort
    {
        public static int CountShifts(int[] arr)
        {
            var list = arr.ToList();
            return MergeSort(list, 0, list.Count - 1);
        }

        private static int MergeSort(IList<int> list, int left, int right)
        {
            if (left >= right)
            {
                return 0;
            }

            var middle = left + (right - left) / 2;

            var leftShifts = MergeSort(list, left, middle);
            var rightShifts = MergeSort(list, middle + 1, right);

            return Merge(list, left, middle, right)
                + leftShifts
                + rightShifts;
        }

        private static int Merge(IList<int> list, int left, int middle, int right)
        {
            var i = left;
            var j = middle + 1;
            var result = 0;
            var temp = new List<int>();

            while (i <= middle && j <= right)
            {
                if (list[i] <= list[j])
                {
                    temp.Add(list[i]);
                    i++;
                }
                else
                {
                    temp.Add(list[j]);

                    result += middle + 1 - i;

                    j++;
                }
            }

            for (; i <= middle; i++)
            {
                temp.Add(list[i]);
            }

            for (; j <= right; j++)
            {
                temp.Add(list[j]);
            }

            for (var k = 0; left <= right; left++, k++)
            {
                list[left] = temp[k];
            }

            return result;
        }
    }
}
