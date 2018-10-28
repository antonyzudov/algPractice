using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class HeapSorting
    {
        public static List<int> Sort(IList<int> arr)
        {
            if (arr?.Any() != true)
            {
                return new List<int>();
            }

            var list = arr.ToList();

            MakeHeap(list, list.Count);

            SortHeap(list);

            return list;
        }

        private static void MakeHeap(IList<int> list, int n)
        {
            for (var i = n / 2; i >= 0; i--)
            {
                Heapify(list, i, n);
            }
        }

        private static void Heapify(IList<int> list, int i, int n)
        {
            var left = 2 * i + 1;
            var right = 2 * i + 2;

            var largest = i;

            if (left < n && list[left] > list[largest])
            {
                largest = left;
            }

            if (right < n && list[right] > list[largest])
            {
                largest = right;
            }

            if (i != largest)
            {
                list.Swap(i, largest);
                Heapify(list, largest, n);
            }
        }

        private static void SortHeap(IList<int> list)
        {
            var n = list.Count;
            for (var i = list.Count - 1; i >= 0; i--)
            {
                list.Swap(i, 0);
                n--;
                Heapify(list, 0, n);
            }
        }
    }
}
