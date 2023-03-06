namespace _1._1.IsUnique;
class Program
{
    static void Main(string[] args)
    {
        var res1 = ContainsOnlyUniqueChars("adfwrg23r42314e123r234"); // false;
        var res2 = ContainsOnlyUniqueChars("asdfghtreuqi3092"); //true

        var res11 = ContainsOnlyUniqueNoExtraSpace("adfwrg23r42314e123r234"); // false;
        var res22 = ContainsOnlyUniqueNoExtraSpace("asdfghtreuqi3092"); //true

        var r2 = IsUniqueBitVector("abcdef");
        var r3 = IsUniqueBitVector("abcdefa");

        Console.ReadLine();
    }

    static bool IsUniqueBitVector(string input)
    {
        var bitVector = 0;
        foreach (var current in input)
        {
            var power = current - 'a' + 1;
            var shift = 1 << power;
            if ((bitVector & shift) > 0)
            {
                return false;
            }

            bitVector |= power;
        }

        return true;
    }

    static bool ContainsOnlyUniqueNoExtraSpace(string input)
    {
        var chars = input.ToCharArray();
        Array.Sort(chars);

        for (var i = 0; i < chars.Length - 1; i++)
        {
            if (chars[i] == chars[i + 1])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Uses additional space, O(N) space, time
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    static bool ContainsOnlyUniqueChars(string input)
    {
        var set = new HashSet<char>();

        foreach (var currentChar in input)
        {
            if (set.Contains(currentChar))
            {
                return false;
            }

            set.Add(currentChar);
        }

        return true;
    }
}

