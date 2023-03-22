namespace _8._10.PaintFill;
class Program
{
    static void Main(string[] args)
    {
        var res = new Solution().FloodFill(new[] { new[] { 1, 1, 1 }, new[] { 1, 1, 0 }, new[] { 1, 0, 1 } }, 1, 1, 2);

        Console.ReadLine();
    }

    public class Solution
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            var rowNum = image.Length;
            var colNum = image[0].Length;

            var result = new int[rowNum][];

            for (var i = 0; i < rowNum; i++)
            {
                result[i] = new int[colNum];
                for (var j = 0; j < colNum; j++)
                {
                    result[i][j] = image[i][j];
                }
            }

            var visited = new HashSet<Point>();
            var queue = new Queue<Point>();
            queue.Enqueue(new Point
            {
                Row = sr,
                Col = sc
            });

            var initialColor = image[sr][sc];

            while (queue.Any())
            {

                var current = queue.Dequeue();
                result[current.Row][current.Col] = color;
                visited.Add(current);

                var neighbors = GetNeighbors(image, current, initialColor, visited);
                foreach (var neigh in neighbors)
                {
                    queue.Enqueue(neigh);
                }
            }

            return result;
        }

        public IList<Point> GetNeighbors(int[][] image, Point current, int color, HashSet<Point> visited)
        {
            var result = new List<Point>();

            result.Add(new Point
            {
                Row = current.Row - 1,
                Col = current.Col
            });

            result.Add(new Point
            {
                Row = current.Row + 1,
                Col = current.Col
            });

            result.Add(new Point
            {
                Row = current.Row,
                Col = current.Col - 1
            });

            result.Add(new Point
            {
                Row = current.Row,
                Col = current.Col + 1
            });

            return result.Where(x => ShouldReturn(image, x, color, visited)).ToList();
        }

        private bool ShouldReturn(int[][] image, Point point, int color, HashSet<Point> visited)
        {
            return point.Row >= 0 && point.Row < image.Length
            && point.Col >= 0 && point.Col < image[0].Length
            && image[point.Row][point.Col] == color
            && !visited.Contains(point);
        }

        public struct Point
        {
            public int Row { get; set; }
            public int Col { get; set; }
        }
    }
}

