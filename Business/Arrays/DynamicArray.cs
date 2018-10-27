using System.Collections.Generic;
using System.ComponentModel;

namespace Business
{
    [Description("https://www.hackerrank.com/challenges/dynamic-array/problem")]
    public static class DynamicArray
    {
        public static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            var result = new List<int>();

            var seqList = new List<List<int>>();

            for( var i = 0; i < n; i++)
            {
                seqList.Add(new List<int>());
            }

            var lastAnswer = 0;

            foreach(var query in queries)
            {
                var type = query[0];
                var x = query[1];
                var y = query[2];

                if (type == 1)
                {
                    var index = (x ^ lastAnswer) % n;
                    seqList[index].Add(y);
                }

                if (type == 2)
                {
                    var index = (x ^ lastAnswer) % n;

                    var size = seqList[index].Count;

                    lastAnswer = seqList[index][y % size];

                    result.Add(lastAnswer);
                }
            }

            return result;
        }
    }
}
