namespace _8._2.Robot;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    static bool GetPath(Point current, LinkedList<Point> paths, Point dest, HashSet<Point> forbidden)
    {
        if (forbidden.Contains(current))
        {
            return false;
        }

        if (current.X == dest.X && current.Y == dest.Y)
        {
            return true;
        }

        if (current.X > dest.X || current.Y > dest.Y)
        {
            return false;
        }

        forbidden.Add(current);
        paths.AddLast(current);

        if (GetPath(current.Left, paths, dest, forbidden))
        {
            return true;
        }

        if (GetPath(current.Down, paths, dest, forbidden))
        {
            return true;
        }

        paths.RemoveLast();
        return false;
    }

    public class Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Point Left => new Point
        {
            X = this.X + 1,
            Y = this.Y + 1
        };

        public Point Down => new Point
        {
            X = this.X,
            Y = this.Y + 1
        };
    }
}

