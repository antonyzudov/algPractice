using System.Collections.Generic;
using System.ComponentModel;
using Business;
using Business.Arrays;
using Xunit;

namespace Tests
{
    public class ArraysTests
    {
        [Fact]
        [Description("https://www.hackerrank.com/challenges/dynamic-array/problem")]
        public void dynamicArray_Test()
        {
            var n = 2;
            var queries = new List<List<int>>
            {
                new List<int> { 1, 0, 5 },
                new List<int> { 1, 1, 7 },
                new List<int> { 1, 0, 3 },
                new List<int> { 2, 1, 0 },
                new List<int> { 2, 1, 1 }
            };

            var actual = DynamicArray.dynamicArray(n, queries);

            Assert.Equal(new List<int> { 7, 3 }, actual);
        }

        [Fact]
        [Description("https://www.hackerrank.com/challenges/array-left-rotation/problem")]
        public void LeftRotate_Test()
        {
            var d = 4;
            var list = new List<int> { 1, 2, 3, 4, 5 };

            var actual = ArrayLeftRotation.LeftRotate(list, d);

            Assert.Equal(new List<int> { 5, 1, 2, 3, 4 }, actual);
        }
    }
}
