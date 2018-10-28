using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Business;
using Utils;
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
            var inputArr = new List<int> { 2, 4, 6, 8, 3 };

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
            var arr = new List<int> { 3, 4, 7, 5, 6, 2, 1 };

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
            var arr = new List<int> { 2, 1, 3, 1, 2, };

            var actual = RunningTime.Calculate(arr.ToArray());

            Assert.Equal(4, actual);
        }

        [Fact]
        [Description("https://www.hackerrank.com/challenges/find-the-median/problem")]
        public void FindMedian_Test()
        {
            var arr = new int[] { 0, 1, 2, 4, 6, 5, 3, };

            var actual = FindMedian.GetMedian(arr);

            Assert.Equal(3, actual);
        }

        [Fact]
        [Description("https://www.hackerrank.com/challenges/countingsort4/problem")]
        public void countSort_Test()
        {
            var arr = new List<List<string>>
            {
                new List<string> {"0", "abc"},
                new List<string> {"6", "cd"},
                new List<string> {"0", "ef"},
                new List<string> {"6", "gh"},
                new List<string> {"4", "ij"},
                new List<string> {"0", "ab"},
                new List<string> {"6", "cd"},
                new List<string> {"0", "ef"},
                new List<string> {"6", "gh"},
                new List<string> {"0", "ij"},
                new List<string> {"4", "that"},
                new List<string> {"3", "be"},
                new List<string> {"0", "to"},
                new List<string> {"1", "be"},
                new List<string> {"5", "question"},
                new List<string> {"1", "or"},
                new List<string> {"2", "not"},
                new List<string> {"4", "is"},
                new List<string> {"2", "to"},
                new List<string> {"4", "the"},
            };

            var actual = countSort.StableCountingSort(arr);

            Assert.Equal("- - - - - to be or not to be - that is the question - - - -", actual);
        }

        [Fact]
        [Description("https://www.hackerrank.com/challenges/insertion-sort/problem")]
        public void insertionSort_Test1()
        {
            var arr = new[] { 2, 1, 3, 1, 2 };

            var actual = insertionSort.CountShifts(arr);

            Assert.Equal(4, actual);
        }

        [Fact]
        [Description("https://www.hackerrank.com/challenges/insertion-sort/problem")]
        public void insertionSort_Test2()
        {
            var arr = new[] { 12, 15, 1, 5, 6, 14, 11 };

            var actual = insertionSort.CountShifts(arr);

            Assert.Equal(10, actual);
        }

        [Fact]
        [Description("https://www.hackerrank.com/challenges/fraudulent-activity-notifications/problem")]
        public void activityNotifications_Test()
        {
            var expenditure = new int[] { 2, 3, 4, 2, 3, 6, 8, 4, 5 };
            var d = 5;

            var actual = SlidingWindowMedian.activityNotifications(expenditure, d);

            Assert.Equal(2, actual);
        }

        [Fact]
        [Description("https://www.hackerrank.com/challenges/lilys-homework/problem")]
        public void lilysHomework_Test()
        {
            var arr = new int[] { 2, 5, 3, 1 };

            var actual = SwapCounting.lilysHomework(arr);

            Assert.Equal(2, actual);
        }

        [Fact]
        [Description("Тест на сортировку слиянием")]
        public void MergeSorting_Test()
        {
            var rand = new Random();

            var list = Enumerable
                .Range(1, 10000)
                .Select(x => rand.Next())
                .ToList();

            var actual = MergeSorting.Sort(list);

            list.Sort();

            Assert.Equal(list, actual);
        }

        [Fact]
        [Description("Тест на сортировку выбором")]
        public void SelectionSorting_Test()
        {
            var rand = new Random();

            var list = Enumerable
                .Range(1, 10000)
                .Select(x => rand.Next())
                .ToList();

            var actual = SelectionSorting.Sort(list);

            list.Sort();

            Assert.Equal(list, actual);
        }

        [Fact]
        [Description("Тест на сортировку вставками")]
        public void InsertionSorting_Test()
        {
            var rand = new Random();

            var list = Enumerable
                .Range(1, 10000)
                .Select(x => rand.Next())
                .ToList();

            var actual = InsertionSorting.Sort(list);

            list.Sort();

            Assert.Equal(list, actual);
        }

        [Fact]
        [Description("Тест на пузырьковую сортировку")]
        public void BubbleSorting_Test()
        {
            var rand = new Random();

            var list = Enumerable
                .Range(1, 10000)
                .Select(x => rand.Next())
                .ToList();

            var actual = BubbleSorting.Sort(list);

            list.Sort();

            Assert.Equal(list, actual);
        }

        [Fact]
        [Description("Тест на сортировку подсчётом")]
        public void CountingSorting_Test()
        {
            var rand = new Random();

            var maxValue = 200;

            var list = Enumerable
                .Range(1, 10000)
                .Select(x => rand.Next(maxValue))
                .ToList();

            var actual = CountingSorting.Sort(list, maxValue);

            list.Sort();

            Assert.Equal(list, actual);
        }

        [Fact]
        [Description("Тест на сортировку Хоара с разбиением Ломуто")]
        public void QuickSortingLomuto_Test()
        {
            var rand = new Random();

            var list = Enumerable
                .Range(1, 10000)
                .Select(x => rand.Next())
                .ToList();

            var actual = QuickSorting.Sort(list, PartitionType.Lomuto);

            list.Sort();

            Assert.Equal(list, actual);
        }

        [Fact]
        [Description("Тест на сортировку Хоара с разбиением Хоара")]
        public void QuickSortingHoar_Test()
        {
            var rand = new Random();

            var list = Enumerable
                .Range(1, 10000)
                .Select(x => rand.Next())
                .ToList();

            var actual = QuickSorting.Sort(list, PartitionType.Hoar);

            list.Sort();

            Assert.Equal(list, actual);
        }

        [Fact]
        [Description("Тест на сортировку Шелла")]
        public void ShellSorting_Test()
        {
            var rand = new Random();

            var list = Enumerable
                .Range(1, 10000)
                .Select(x => rand.Next())
                .ToList();

            var actual = ShellSorting.Sort(list);

            list.Sort();

            Assert.Equal(list, actual);
        }

        [Fact]
        [Description("Тест на пирамидальную сортировку")]
        public void HeapSorting_Test()
        {
            var rand = new Random();

            var list = Enumerable
                .Range(1, 10000)
                .Select(x => rand.Next())
                .ToList();

            var actual = HeapSorting.Sort(list);

            list.Sort();

            Assert.Equal(list, actual);
        }
    }
}
