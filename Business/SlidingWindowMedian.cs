using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public static class SlidingWindowMedian
    {
        public static int activityNotifications(int[] expenditure, int d)
        {
            int n = expenditure.Length;

            if (n == 0)
            {
                return 0;
            }

            var hourglass = new Hourglass(expenditure.First());

            int i = 1;
            for (; i < d; i++)
            {
                hourglass.Add(expenditure[i]);
            }

            int result = 0;
            for (; i < n; i++)
            {
                var median = hourglass.Median;
                var limit = 2 * median;

                if (expenditure[i] >= limit)
                {
                    result++;
                }

                hourglass.Remove(expenditure[i - d]);
                hourglass.Add(expenditure[i]);
            }

            return result;
        }

        private class Hourglass
        {
            private int count;
            bool toUpper;

            private Pyramid upperPyramid;
            private Pyramid bottomPyramid;

            public int Median => upperPyramid.Top;

            public Hourglass(int firstVertex)
            {
                upperPyramid = new Pyramid(PyramidType.MinTop, firstVertex);
                bottomPyramid = new Pyramid(PyramidType.MaxTop, firstVertex);
                count = 1;
                toUpper = true;
            }

            public void Add(int vertex)
            {
                count++;
                if (toUpper)
                {
                    bottomPyramid.AddVertex(vertex);
                    if (bottomPyramid.Top != upperPyramid.Top)
                    {
                        upperPyramid.SetTop(bottomPyramid.Top);
                        bottomPyramid.SetTop(upperPyramid.Top);
                    }
                }
                else
                {
                    upperPyramid.AddVertex(vertex);
                    if (upperPyramid.Top != bottomPyramid.Top)
                    {
                        bottomPyramid.SetTop(upperPyramid.Top);
                        upperPyramid.SetTop(bottomPyramid.Top);
                    }
                }
                toUpper = !toUpper;
            }

            public void Remove(int vertex)
            {
                if(vertex > Median)
                {
                    var removed = upperPyramid.RemoveVertex(vertex);
                }
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

                public void RemoveVertex(int vertex)
                {
                    
                }
            }
        }
    }
}
