using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class QuickSorting
    {
        private static readonly Dictionary<PartitionType, Func<List<int>, int, int, int>> Partitions = new Dictionary<PartitionType, Func<List<int>, int, int, int>>
        {
            {PartitionType.Lomuto, LomutoPartition },
            {PartitionType.Hoar, HoarPartition }
        };

        public static List<int> Sort(IList<int> list, PartitionType partitionType)
        {
            if (list?.Any() != true)
            {
                return new List<int>();
            }

            return QuickSort(list.ToList(), 0, list.Count - 1, partitionType);
        }

        private static List<int> QuickSort(List<int> list, int lo, int hi, PartitionType partitionType)
        {
            if (lo < hi)
            {
                var middle = Partitions[partitionType](list, lo, hi);

                QuickSort(list, lo, middle - 1, partitionType);
                QuickSort(list, middle + 1, hi, partitionType);
            }

            return list;
        }

        private static int LomutoPartition(List<int> list, int lo, int hi)
        {
            var pivot = list[hi];

            var i = lo;
            for (var j = lo; j < hi; j++)
            {
                if (list[j] < pivot)
                {
                    list.Swap(i, j);
                    i++;
                }
            }

            list[hi] = list[i];
            list[i] = pivot;

            return i;
        }

        private static int HoarPartition(List<int> list, int lo, int hi)
        {
            var pivot = GetPivot(list, lo, hi);

            var i = lo;
            var j = hi;

            while (i < j)
            {
                while (list[i] < pivot)
                {
                    i++;
                }

                while (list[j] > pivot)
                {
                    j--;
                }

                list.Swap(i, j);
            }

            return i;
        }

        private static int GetPivot(List<int> list, int lo, int hi)
        {
            return list[lo];
        }
    }

    public enum PartitionType
    {
        Lomuto = 0,
        Hoar = 1
    }
}
