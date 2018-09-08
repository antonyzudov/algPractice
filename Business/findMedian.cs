using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Business
{
    [Description("https://www.hackerrank.com/challenges/find-the-median/problem")]
    public static class FindMedian
    {
        public static int? GetMedian(IReadOnlyCollection<int> arr)
        {
            if (!arr.Any())
            {
                return null;
            }

            var list = arr.ToList();

            var upperPyramid = new Pyramid(PyramidType.MinTop, list.First());
            var bottomPyramid = new Pyramid(PyramidType.MaxTop, list.First());

            var toRight = true;
            for (var i = 1; i < list.Count; i++)
            {
                if (toRight)
                {
                    bottomPyramid.AddVertex(list[i]);
                    if (bottomPyramid.Top != upperPyramid.Top)
                    {
                        upperPyramid.SetTop(bottomPyramid.Top);
                        bottomPyramid.SetTop(upperPyramid.Top);
                    }
                }
                else
                {
                    upperPyramid.AddVertex(list[i]);
                    if (upperPyramid.Top != bottomPyramid.Top)
                    {
                        bottomPyramid.SetTop(upperPyramid.Top);
                        upperPyramid.SetTop(bottomPyramid.Top);
                    }
                }

                toRight = !toRight;
            }

            return upperPyramid.Top;
        }

        private enum PyramidType
        {
            MinTop = 0,
            MaxTop = 1
        }

        private class Pyramid
        {
            public int Top { get; private set; }
            private int Count { get; set; }

            private PyramidType type;
            private Pyramid leftPyramid;
            private Pyramid rightPyramid;


            public Pyramid(PyramidType type, int firstVertex)
            {
                this.type = type;
                Top = firstVertex;
                Count = 1;
            }

            public void AddVertex(int vertex)
            {
                Count++;

                int newVertex;
                if (type == PyramidType.MinTop && Top <= vertex
                    || type == PyramidType.MaxTop && Top >= vertex)
                {
                    newVertex = vertex;
                }
                else
                {
                    newVertex = Top;
                    Top = vertex;
                }

                if (leftPyramid == null)
                {
                    leftPyramid = new Pyramid(type, newVertex);
                    return;
                }

                if (rightPyramid == null)
                {
                    rightPyramid = new Pyramid(type, newVertex);
                    return;
                }

                if (rightPyramid.Count < leftPyramid.Count)
                {
                    rightPyramid.AddVertex(newVertex);
                }
                else
                {
                    leftPyramid.AddVertex(newVertex);
                }
            }

            public void SetTop(int newTop)
            {
                Top = newTop;

                if (leftPyramid == null)
                {
                    return;
                }

                if (rightPyramid == null)
                {
                    var sub = leftPyramid.Top;

                    if (type == PyramidType.MinTop && newTop <= sub
                        || type == PyramidType.MaxTop && newTop >= sub)
                    {
                        return;
                    }

                    Top = sub;
                    leftPyramid.SetTop(newTop);

                    return;
                }

                var left = leftPyramid.Top;
                var right = rightPyramid.Top;

                if (type == PyramidType.MinTop && newTop <= left && newTop <= right
                    || type == PyramidType.MaxTop && newTop >= left && newTop >= right)
                {
                    return;
                }

                if (type == PyramidType.MinTop && left < right
                    || type == PyramidType.MaxTop && left > right)
                {
                    Top = left;
                    leftPyramid.SetTop(newTop);
                }
                else
                {
                    Top = right;
                    rightPyramid.SetTop(newTop);
                }
            }
        }
    }
}
