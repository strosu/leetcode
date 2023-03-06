namespace _1._7.RotateMatrix;
class Program
{
    static void Main(string[] args)
    {
        var matrix = new int[5][];
        matrix[0] = new int[] { 1, 2, 3, 4, 5 };
        matrix[1] = new int[] { 6, 7, 8, 9, 10 };
        matrix[2] = new int[] { 11, 12, 13, 14, 15 };
        matrix[3] = new int[] { 16, 17, 18, 19, 20 };
        matrix[4] = new int[] { 21, 22, 23, 24, 25 };

        Rotate90Degrees(matrix);

        Console.ReadLine();
    }

    static void Rotate90Degrees(int[][] input)
    {
        var maxIndex = (input.Length + 1) / 2;

        for (var i = 0; i < maxIndex; i++)
        {
            for (var j = 0; j < maxIndex; j++)
            {
                var points = GetComplements(i, j, input.Length);
                Swap(points, input);
            }
        }
    }

    static void Swap(Point[] points, int[][] input)
    {
        var temp = input[points[0].X][points[0].Y];

        input[points[0].X][points[0].Y] = input[points[3].X][points[3].Y];
        input[points[3].X][points[3].Y] = input[points[2].X][points[2].Y];
        input[points[2].X][points[2].Y] = input[points[1].X][points[1].Y];

        input[points[1].X][points[1].Y] = temp;
    }

    static Point[] GetComplements(int x, int y, int n)
    {
        var result = new Point[4];
        result[0] = new Point(x, y);
        result[1] = new Point(y, n - x - 1);
        result[2] = new Point(x - x - 1, n - y - 1);
        result[3] = new Point(x - y - 1, x);

        return result;
    }

    class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}

