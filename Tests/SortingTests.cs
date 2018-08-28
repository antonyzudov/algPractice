using System.Collections.Generic;
using System.ComponentModel;
using Business;
using Xunit;

namespace Tests
{
    public class SortingTests
    {
        [Fact]
        [Description("https://www.hackerrank.com/challenges/big-sorting/problem")]
        public void bigSorting_Test()
        {
            var inputArray = new List<string>
            {
                "1",
                "2",
                "100",
                "12303479849857341718340192371",
                "3084193741082937",
                "3084193741082938",
                "111",
                "200"
            };

            var actual = BigSorting.bigSorting(inputArray.ToArray());

            var expected = new List<string>
            {
                "1",
                "2",
                "100",
                "111",
                "200",
                "3084193741082937",
                "3084193741082938",
                "12303479849857341718340192371"
            };

            Assert.Equal(expected, actual);
        }

        [Fact]
        [Description("https://www.hackerrank.com/challenges/insertionsort1/problem")]
        public void insertionSort1_Test()
        {
            var inputArr = new List<int> {2, 4, 6, 8, 3};

            var actual = InsertionSort1.Sort(inputArr.ToArray());

            var expected = new List<string>
            {
                "2 4 6 8 8",
                "2 4 6 6 8",
                "2 4 4 6 8",
                "2 3 4 6 8"
            };
 
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Description("https://www.hackerrank.com/challenges/insertionsort2/problem")]
        public void insertionSort2_Test()
        {
            var arr = new List<int> {3, 4, 7, 5, 6, 2, 1};

            var actual = InsertionSort2.Sort(arr.ToArray());

            var expected = new List<string>
            {
                "3 4 7 5 6 2 1",
                "3 4 7 5 6 2 1",
                "3 4 5 7 6 2 1",
                "3 4 5 6 7 2 1",
                "2 3 4 5 6 7 1",
                "1 2 3 4 5 6 7"
            };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void insertionSort2_Test2()
        {
            var arr = new List<int> { 1, 4, 3, 5, 6, 2 };

            var actual = InsertionSort2.Sort(arr.ToArray());

            var expected = new List<string>
            {
                "1 4 3 5 6 2",
                "1 3 4 5 6 2",
                "1 3 4 5 6 2",
                "1 3 4 5 6 2",
                "1 2 3 4 5 6"
            };

            Assert.Equal(expected, actual);
        }

        [Fact]
        [Description("https://www.hackerrank.com/challenges/runningtime/problem")]
        public void runningTime_Test()
        {
            var arr = new List<int> {2, 1, 3, 1, 2,};

            var actual = RunningTime.Calculate(arr.ToArray());

            Assert.Equal(4, actual);
        }

        [Fact]
        [Description("https://www.hackerrank.com/challenges/quicksort1/problem")]
        public void quickSort_Test()
        {
            var arr = new List<int> {4, 5, 3, 7, 2};

            var actual = QuickSort.GetLeftPivotRight(arr);

            Assert.Equal(new List<int>{ 3, 2, 4, 5, 7, }, actual);
        }
    }
}
