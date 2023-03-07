namespace _1._9.StringRotation;
class Program
{
    static void Main(string[] args)
    {
        var isSubstring = IsSubstring("abcdefabbcd", "defa");
        var isSubstring2 = IsSubstring("abcdefabbcd", "defbca");

        var isRotation = IsRotation("abcdefghij", "defghijabc");
        var isRotation2 = IsRotation("abcdefghij", "defghijabd");

        Console.ReadLine();
    }

    static bool IsRotation(string first, string second)
    {
        return IsSubstring(first + first, second);
    }

    static bool IsSubstring(string longer, string shorter)
    {
        for (var i = 0; i < longer.Length - shorter.Length; i++)
        {
            var subStringLength = 0;
            while (i + subStringLength < longer.Length && subStringLength < shorter.Length && longer[i + subStringLength] == shorter[subStringLength])
            {
                subStringLength++;
            }

            if (subStringLength == shorter.Length)
            {
                return true;
            }
        }

        return false;
    }
}

