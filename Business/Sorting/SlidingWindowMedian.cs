using System.Collections.Generic;

namespace Business
{
    public static class SlidingWindowMedian
    {
        public static int activityNotifications(int[] expenditure, int trailingNumber)
        {
            var notificationCount = 0;

            var list = new List<long>();
            for (var i = 0; i <= 200; i++)
            {
                list.Add(0);
            }

            for (var i = 0; i < trailingNumber; i++)
            {
                list[expenditure[i]]++;
            }

            for (var i = trailingNumber; i < expenditure.Length; i++)
            {
                var median = GetMedian(list);
                var limit = 2 * median;

                if (expenditure[i] >= limit)
                {
                    notificationCount++;
                }

                list[expenditure[i - trailingNumber]]--;
                list[expenditure[i]]++;
            }

            return notificationCount;
        }

        private static double GetMedian(IReadOnlyList<long> list)
        {
            var i = 0;
            var j = 200;

            long leftCount = list[i];
            long rightCount = list[j];

            while (i != j)
            {
                if ((i + 1) == j && leftCount == rightCount)
                {
                    return i + 0.5;
                }

                if (leftCount <= rightCount)
                {
                    i++;
                    leftCount += list[i];
                }
                else
                {
                    j--;
                    rightCount += list[j];
                }
            }

            return i;
        }
        
    }
}
