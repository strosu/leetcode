namespace _8._13.RussianDolls;
class Program
{
    static void Main(string[] args)
    {
        var res = new Program().MaxEnvelopes(new[] { new[] { 5, 4 }, new[] { 6, 4 }, new[] { 6, 7 }, new[] { 2, 3 } });
        var res2 = new Program().MaxEnvelopes(new[] { new[] { 1, 1 }, new[] { 1, 1 }, new[] { 1, 1 } });
        var res3 = new Program().MaxEnvelopes(new[] { new[] { 1, 1 } });
        Console.ReadLine();
    }

    public int MaxEnvelopes(int[][] envelopes)
    {
        Array.Sort(envelopes, (a, b) => a[0] == b[0] ? b[1] - a[1] : a[0] - b[0]);

        return LongestIncrementingSequence(envelopes.Select(x => x[1]));

        //var ordered = envelopes.Select(x => new Envelope
        //{
        //    Width = x[0],
        //    Height = x[1]
        //}).OrderByDescending(x => x.Height).ToList();

        //return MaxStartingFrom(ordered, 0, null, 0);
    }

    public int LongestIncrementingSequence(IEnumerable<int> values)
    {
        var currentList = new List<int>
        {
            values.First()
        };

        foreach (var current in values)
        {
            if (current > currentList.Last())
            {
                currentList.Add(current);
                continue;
            }

            var toReplace = currentList.BinarySearch(current);
            if (toReplace >= 0)
            {
                currentList[toReplace] = current;
                continue;
            }

            var position = -(toReplace + 1);
            currentList[position] = current;
        }

        return currentList.Count;
    }

    private int MaxStartingFrom(List<Envelope> heightOrdered, int currentHeightIndex, Envelope last, int currentHeight)
    {
        var maxHeight = 0;

        for (var i = currentHeightIndex; i < heightOrdered.Count; i++)
        {
            if (last != null && last.Width <= heightOrdered[i].Width)
            {
                continue;
            }

            if (last == null || last.Width > heightOrdered[i].Width)
            {
                maxHeight = Math.Max(maxHeight, MaxStartingFrom(heightOrdered, i, heightOrdered[i], currentHeight + 1));
            }
        }

        return Math.Max(currentHeight, maxHeight);
    }

    public class Envelope
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }
}

