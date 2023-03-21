using System.Collections.Generic;

namespace _8._4.AllSubsets;
class Program
{
    static void Main(string[] args)
    {
        var result = new List<List<int>>();
        GetSubsets(new[] { 1, 2, 3 }, -1, result, new List<int>());

        Console.ReadLine();
    }

    static void GetSubsets(int[] input, int index, List<List<int>> results, List<int> currentList)
    {
        results.Add(currentList.ToList());

        for (var i = index + 1; i < input.Length; i++)
        {
            currentList.Add(input[i]);
            GetSubsets(input, i, results, currentList);
            currentList.Remove(input[i]);
        }
    }

    static List<List<int>> GetSubsetsBits(int[] input)
    {
        var result = new List<List<int>>();

        var max = 1 << input.Length;

        for (var i = 0; i < max; i++)
        {
            var current = ConvertToList(i, input);
            result.Add(current);
        }

        return result;
    }

    private static List<int> ConvertToList(int num, int[] input)
    {
        var result = new List<int>();
        int index = 0;
        for (var i = num; i > 0; i >>= 1, index++)
        {
            if ((i & 1) == 1)
            {
                result.Add(input[index]);
            }
        }

        return result;
    }
}

