using System.Collections.Generic;
using System.ComponentModel;
using Business;
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
    }
}
