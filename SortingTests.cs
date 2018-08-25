using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xunit;

namespace algPractice
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

            var actual = SortingFunctions.bigSorting(inputArray.ToArray());

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

            var actual = SortingFunctions.InsertionSort1(inputArr.ToArray());

            var expected = new List<string>
            {
                "2 4 6 8 8",
                "2 4 6 6 8",
                "2 4 4 6 8",
                "2 3 4 6 8"
            };
 
            Assert.Equal(expected, actual);
        }
    }
}
