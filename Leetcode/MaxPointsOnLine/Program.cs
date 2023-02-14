using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace MaxPointsOnLine;
class Program
{
    static void Main(string[] args)
    {
        //Input: points = [[1, 1],[3,2],[5,3],[4,1],[2,3],[1,4]]
        var points = new int[6][];
        points[0] = new int[] { 1, 1 };
        points[1] = new int[] { 3, 2 };
        points[2] = new int[] { 5, 3 };
        points[3] = new int[] { 4, 1 };
        points[4] = new int[] { 2, 3 };
        points[5] = new int[] { 1, 4 };

        var result = new Solution().MaxPoints(points);
        Console.ReadLine();
    }

    public class Solution
    {
        private static readonly Point root = new Point { X = 0, Y = 0 };
        private static readonly Point xAxis = new Point { X = 1, Y = 0 };
        private static readonly Point yAxis = new Point { X = 0, Y = 1 };

        public int MaxPoints(int[][] points)
        {
            var max = points.Length == 1 ? 1 : 2;

            var map = new Dictionary<(Point?, Point?), int>();
            for (var i = 0; i < points.Length - 1; i++)
            {
                for (var j = i + 1; j < points.Length; j++)
                {
                    var intersections = GetIntersections(
                        new Point
                        {
                            X = points[i][0],
                            Y = points[i][1]
                        },
                        new Point
                        {
                            X = points[j][0],
                            Y = points[j][1]
                        }
                    );

                    if (map.ContainsKey(intersections))
                    {
                        map[intersections]++;
                        max = Math.Max(max, map[intersections]);
                    }
                    else
                    {
                        map.Add(intersections, 2);
                    }
                }
            }

            return max;
        }

        public (Point? xIntersection, Point? yIntersection) GetIntersections(Point first, Point second)
        {
            // For a pair of points, return the intersections with the X/Y axes, if applicable (null for a line parallel with an axis)
            if (first.X == second.X)
            {
                return (new Point
                {
                    X = first.X,
                    Y = 0
                }, null);
            }

            if (first.Y == second.Y)
            {
                return (null, new Point
                {
                    X = 0,
                    Y = first.Y
                });
            }

            return (GetIntersection(first, second, root, xAxis), GetIntersection(first, second, root, yAxis));
        }

        public Point GetIntersection(Point first1, Point second1, Point first2, Point second2)
        {
            var a1 = second1.X - first1.X;
            var b1 = first1.Y - second1.Y;
            var c1 = a1 * first1.X + b1 * first1.Y;

            var a2 = second2.X - first2.X;
            var b2 = first2.Y - second2.Y;
            var c2 = a1 * first2.X + b2 * first2.Y;

            var determinant = a1 * b2 - a2 * b1;

            return new Point
            {
                X = b2 * c1 - b1 * c2,
                Y = a1 * c2 - a2 * c1
            };
        }
    }

    public struct Point
    {
        public double X { get; set; }

        public double Y { get; set; }
    }
}

