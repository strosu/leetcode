namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static string[][] GetNextIterataion(string[][] current)
        {
            var result = new string[current.Length][];

            for (var i = 0; i < current.Length; i++)
            {
                result[i] = new string[current[i].Length];

                for (var j = 0; j < current[i].Length; j++)
                {
                    var states = GetNeighborStates(i, j, current);

                    var currentlyAlive = current[i][j] == "x";

                    if (currentlyAlive)
                    {
                        var aliveNeighbors = states.Count(x => x);

                        if (aliveNeighbors >= 2 && aliveNeighbors <= 3)
                        {
                            result[i][j] = "x";
                            continue;
                        }

                        result[i][j] = string.Empty;
                        continue;
                    }

                    var deadNeighbors = states.Count(x => !x);
                    if (deadNeighbors == 3)
                    {
                        result[i][j] = "x";
                    }
                    else
                    {
                        result[i][j] = string.Empty;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// True for alive, false otherwise
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        static List<bool> GetNeighborStates(int x, int y, string[][] current)
        {
            var neighbors = GetNeighbors(x, y, current.Length, current[0].Length);
            return neighbors.Select(point => current[point.X][point.Y] == "x").ToList();
        }

        static List<Point> GetNeighbors(int x, int y, int maxRow, int maxColumn)
        {
            var candidates = new List<Point>();

            candidates.Add(new Point(x - 1 , y - 1));
            candidates.Add(new Point(x - 1 , y));
            candidates.Add(new Point(x - 1 , y + 1));
            
            candidates.Add(new Point(x, y - 1));
            candidates.Add(new Point(x, y + 1));

            candidates.Add(new Point(x + 1, y - 1));
            candidates.Add(new Point(x + 1, y));
            candidates.Add(new Point(x + 1, y + 1));

            return candidates.Where(point => IsWithinMatrix(point, maxRow, maxColumn)).ToList();
        }

        static bool IsWithinMatrix(Point point, int maxRow, int maxColumn)
        {
            return point.X >= 0 && point.X <= maxColumn
                && point.Y >= 0 && point.Y <= maxRow;
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
}