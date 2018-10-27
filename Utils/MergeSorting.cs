using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class MergeSorting
    {
        public static List<int> Sort(IList<int> list)
        {
            if (list?.Any() != true)
            {
                return new List<int>();
            }

            MergeSort(list, 0, list.Count - 1);

            return list.ToList();
        }

        private static void MergeSort(IList<int> list, int fromIndex, int toIndex)
        {
            if (fromIndex >= toIndex)
            {
                return;
            }

            var middle = ((int)((toIndex - fromIndex) / 2)) + fromIndex;
            var i = 0;
            var j = 0;

            MergeSort(list, fromIndex, middle);
            MergeSort(list, middle + 1, toIndex);

            var leftList = new List<int>();
            for (i = fromIndex; i <= middle; i++)
            {
                leftList.Add(list[i]);
            }

            i = 0;
            j = middle + 1;
            var k = fromIndex;
            for (; i < leftList.Count && j <= toIndex; k++)
            {
                if (leftList[i] <= list[j])
                {
                    list[k] = leftList[i];
                    i++;
                }
                else
                {
                    list[k] = list[j];
                    j++;
                }
            }

            for (; i < leftList.Count; i++)
            {
                list[k] = leftList[i];
                k++;
            }
        }
    }
}
