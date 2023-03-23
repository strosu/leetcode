namespace _8._13.StackOfBoxes;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    static int GetMaxHeight(int[][] boxes, int lastBox, int currentBox, Dictionary<int, int> partials)
    {
        if (partials.ContainsKey(currentBox))
        {
            return partials[currentBox];
        }

        if (currentBox == boxes.Length)
        {
            return 0;
        }

        var maxNext = 0;

        // Can we try the current box?
        if (lastBox == int.MinValue || Stacks(boxes, lastBox, currentBox))
        {
            maxNext = Math.Max(maxNext, 1 + GetMaxHeight(boxes, currentBox, currentBox + 1, partials));
        }

        maxNext = Math.Max(maxNext, GetMaxHeight(boxes, lastBox, currentBox + 1, partials));

        partials[currentBox] = maxNext;

        return maxNext;
    }

    static bool Stacks(int[][] boxes, int first, int second)
    {
        for (var i = 0; i < 3; i++)
        {
            if (boxes[first][i] < boxes[second][i])
            {
                return false;
            }
        }

        return true;
    }
}

