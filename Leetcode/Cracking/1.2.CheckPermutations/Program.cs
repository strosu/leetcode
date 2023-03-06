namespace _1._2.CheckPermutations;
class Program
{
    static void Main(string[] args)
    {
        var res1 = IsPermutation("abcdefghijka", "kjhigfedcbaa"); // true
        var res11 = IsPermutation("abcdefghijkb", "kjihgfedcbaa"); // false

        Console.ReadLine();
    }

    static bool IsPermutation(string first, string second)
    {
        if (first.Length != second.Length)
        {
            return false;
        }

        var firstSet = GetCharFrequency(first);
        var secondSet = GetCharFrequency(second);

        foreach (var kvp in firstSet)
        {
            if (!secondSet.ContainsKey(kvp.Key) || secondSet[kvp.Key] != kvp.Value)
            {
                return false;
            }
        }

        return true;
    }

    static Dictionary<char, int> GetCharFrequency(string input)
    {
        var result = new Dictionary<char, int>();
        foreach (var currentChar in input)
        {
            if (!result.ContainsKey(currentChar))
            {
                result.Add(currentChar, 1);
                continue;
            }

            result[currentChar]++;
        }

        return result;
    }
}

