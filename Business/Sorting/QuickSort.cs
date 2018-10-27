using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public static class QuickSort
    {
        public static int[] LomutoPartition(int[] arr)
        {
            var n = arr.Count();

            if (n == 0)
            {
                return arr;
            }

            var pivot = arr[0];
            int i = n - 1;

            for (int j = n - 1; j >= 0; j--)
            {
                if (arr[j] > pivot)
                {
                    var buf = arr[j];
                    arr[j] = arr[i];
                    arr[i] = buf;

                    i--;
                }
            }
            arr[0] = arr[i];
            arr[i] = pivot;

            return arr;
        }

        private enum PyramidType
        {
            MinTop = 0,
            MaxTop = 1
        }

        private class Pyramid
        {
            public int Top { get; private set; }
            public int Count { get; private set; }

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

            public List<int> GetLR()
            {
                if (leftPyramid == null && rightPyramid == null)
                {
                    return new List<int>();
                }

                if (leftPyramid == null)
                {
                    return rightPyramid.GetLNR();
                }

                if (rightPyramid == null)
                {
                    return leftPyramid.GetLNR();
                }

                var result = new List<int>();
                if (leftPyramid.Top <= rightPyramid.Top)
                {
                    result.AddRange(leftPyramid.GetLNR());
                    result.AddRange(rightPyramid.GetLNR());
                }
                else
                {
                    result.AddRange(rightPyramid.GetLNR());
                    result.AddRange(leftPyramid.GetLNR());
                }

                return result;
            }

            private List<int> GetLNR()
            {
                var result = new List<int>();

                if (type == PyramidType.MinTop)
                {
                    result.Add(Top);
                }

                if (leftPyramid == null)
                {
                    result.AddRange(rightPyramid?.GetLNR() ?? new List<int>());
                }

                if (rightPyramid == null)
                {
                    result.AddRange(leftPyramid?.GetLNR() ?? new List<int>());
                }

                if (leftPyramid != null && rightPyramid != null)
                {
                    if (leftPyramid.Top <= rightPyramid.Top)
                    {
                        result.AddRange(leftPyramid.GetLNR());
                        result.AddRange(rightPyramid.GetLNR());
                    }
                    else
                    {
                        result.AddRange(rightPyramid.GetLNR());
                        result.AddRange(leftPyramid.GetLNR());
                    }
                }

                if (type == PyramidType.MaxTop)
                {
                    result.Add(Top);
                }

                return result;
            }
        }
    }
}