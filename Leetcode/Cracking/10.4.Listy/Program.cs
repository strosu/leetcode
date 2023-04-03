namespace _10._4.Listy;
class Program
{
    static void Main(string[] args)
    {
        var result = FindElement(new Listy(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }), 11);
        Console.ReadLine();
    }

    static int FindElement(Listy list, int target)
    {
        var count = GetHighBound(list);
        return Search(list, 0, count, target);
    }

    static int GetHighBound(Listy list)
    {
        if (list.Get(0) == -1)
        {
            return -1;
        }

        if (list.Get(1) == -1)
        {
            return 0;
        }

        var counter = 1;
        while (list.Get(counter) != -1)
        {
            counter *= 2;
        }

        return counter;
    }

    static int Search(Listy list, int start, int end, int target)
    {
        if (start > end)
        {
            return -1;
        }

        if (list.Get(start) > target)
        {
            return -1;
        }

        if (start == end)
        {
            return list.Get(start) == target ? start : -1;
        }

        var median = (start + end) / 2;
        var medianValue = list.Get(median);

        if (medianValue == target)
        {
            return median;
        }

        if (medianValue == -1 || target < medianValue)
        {
            return Search(list, start, median - 1, target);
        }

        return Search(list, median + 1, end, target);
    }

    public class Listy
    {
        private readonly List<int> Values;

        public Listy(int[] nums)
        {
            Values = new List<int>(nums);
        }

        public int Get(int index)
        {
            if (index >= Values.Count)
            {
                return -1;
            }

            return Values[index];
        }
    }
}

