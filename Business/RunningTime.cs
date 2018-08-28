using System.ComponentModel;

namespace Business
{
    [Description("https://www.hackerrank.com/challenges/runningtime/problem")]
    public static class RunningTime
    {
        public static int Calculate(int[] arr)
        {
            var numberOfShifts = 0;

            var n = arr.Length;

            for (var i = 1; i < n; i++)
            {
                var x = arr[i];
                var j = i - 1;

                while (j >= 0 && arr[j] > x)
                {
                    arr[j + 1] = arr[j];

                    numberOfShifts++;

                    j--;
                }

                arr[j + 1] = x;
            }

            return numberOfShifts;
        }
    }
}
