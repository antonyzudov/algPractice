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
    }
}
