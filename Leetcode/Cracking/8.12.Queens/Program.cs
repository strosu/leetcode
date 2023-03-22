namespace _8._12.Queens;
class Program
{
    static void Main(string[] args)
    {
        var res = new Program().SolveNQueens(4);

        Console.ReadLine();
    }

    public IList<IList<string>> SolveNQueens(int n)
    {
        return CountQueensRecurse(new LinkedList<Position>(), n);
    }

    static IList<IList<string>> CountQueensRecurse(LinkedList<Position> currentPositions, int n)
    {
        if (currentPositions.Count == n)
        {
            return new List<IList<string>> { Transform(currentPositions) };
        }

        var result = new List<IList<string>>();

        var potentials = GetPotentialNext(currentPositions, n);
        foreach (var next in potentials)
        {
            currentPositions.AddLast(next);

            result.AddRange(CountQueensRecurse(currentPositions, n));

            currentPositions.RemoveLast();
        }

        return result;
    }

    static List<string> Transform(LinkedList<Position> positions)
    {
        var boardSize = positions.Count;

        var strings = Enumerable.Range(0, boardSize).Select(x => Enumerable.Range(0, boardSize).Select(y => '.').ToArray()).ToList();

        foreach (var position in positions)
        {
            strings[position.Row][position.Col] = 'Q';
        }

        return strings.Select(x => new string(x)).ToList();
    }

    static List<Position> GetPotentialNext(LinkedList<Position> current, int maxCol)
    {
        var currentRow = current.Count;
        return Enumerable.Range(0, maxCol).Select(x => new Position
        {
            Row = currentRow,
            Col = x
        }).Where(c => !current.Any(x => Attacks(c, x))).ToList();
    }

    static bool Attacks(Position first, Position second)
    {
        if (first.Row == second.Row || first.Col == second.Col)
        {
            return true;
        }

        if (Math.Abs(first.Row - second.Row) == Math.Abs(first.Col - second.Col))
        {
            return true;
        }

        return false;
    }

    class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}

