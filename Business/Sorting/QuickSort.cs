using System.Linq;

namespace Business
{
    public static class QuickSort
    {
        public static int[] LomutoPartition(int[] arr)
        {
            var n = arr.Count();

            if (n == 0)
            {
                return arr;
            }

            var pivot = arr[0];
            int i = n - 1;

            for (int j = n - 1; j >= 0; j--)
            {
                if (arr[j] > pivot)
                {
                    var buf = arr[j];
                    arr[j] = arr[i];
                    arr[i] = buf;

                    i--;
                }
            }
            arr[0] = arr[i];
            arr[i] = pivot;

            return arr;
        }
    }
}