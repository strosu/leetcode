namespace _8._3.MagicIndex;
class Program
{
    static void Main(string[] args)
    {
        var result = TryGetMagicIndex(new[] { 2, 3, 4, 5, 6 });
        var result2 = TryGetMagicIndex(new[] { 0, 1, 2, 3, 4, 5, 6 });
        var result3 = TryGetMagicIndex(new[] { -2, 1, 12, 13, 14, 15, 16 });
        var result4 = TryGetMagicIndex(new[] { 5, 5, 5, 5, 5, 5, 5 });

        Console.ReadLine();
    }

    static int TryGetMagicIndex(int[] values)
    {
        return TryGetWithDuplicates(values, 0, values.Length - 1);
    }

    static int TryGetWithDuplicates(int[] values, int start, int end)
    {
        if (start > end)
        {
            return -1;
        }

        var median = (start + end) / 2;
        if (values[median] == median)
        {
            return median;
        }

        var leftBound = Math.Min(median - 1, values[median]);
        var left = TryGetWithDuplicates(values, start, leftBound);

        if (left >= 0)
        {
            return left;
        }

        return TryGetWithDuplicates(values, median + 1, end);
    }

    static bool TryGetMagicIndexRecursively(int[] values, int start, int end, out int index)
    {
        if (start > end)
        {
            index = int.MinValue;
            return false;
        }

        var median = (start + end) / 2;

        if (values[median] == median)
        {
            index = median;
            return true;
        }

        if (values[median] > median)
        {
            return TryGetMagicIndexRecursively(values, start, median - 1, out index);
        }

        return TryGetMagicIndexRecursively(values, median + 1, end, out index);
    }
}

