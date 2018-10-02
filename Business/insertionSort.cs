using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Business
{
    [Description("https://www.hackerrank.com/challenges/insertion-sort/problem")]
    public static class insertionSort
    {
        public static long CountShifts(int[] mas)
        {
            var list = mas.ToList();
            return MergeSort(list, 0, list.Count - 1);
        }

        private static long MergeSort(IList<int> list, int left, int right)
        {
            if (left >= right)
            {
                return 0;
            }

            var middle = left + (right - left) / 2;

            var leftShifts = MergeSort(list, left, middle);
            var rightShifts = MergeSort(list, middle + 1, right);

            var mergeShifts = Merge(list, left, middle + 1, right);

            return leftShifts + rightShifts + mergeShifts;
        }

        private static long Merge(IList<int> list, int left, int middle, int right)
        {
            long result = 0;

            var i = left;
            var j = middle;

            var temp = new List<int>();
            
            while (i < middle && j <= right)
            {
                if (list[i] <= list[j])
                {
                    temp.Add(list[i]);
                    i++;
                }
                else
                {
                    temp.Add(list[j]);
                    j++;
                    result += middle - i;
                }
            }

            while (i < middle)
            {
                temp.Add(list[i]);
                i++;
            }
            while (j <= right)
            {
                temp.Add(list[j]);
                j++;
            }

            var k = 0;
            while (left <= right)
            {
                list[left] = temp[k];
                left++;
                k++;
            }

            return result;
        }
    }
}
