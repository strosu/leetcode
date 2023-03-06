namespace _1._5.OneAway;
class Program
{
    static void Main(string[] args)
    {
        var res1 = AreOneAway("pale", "ple"); // true
        var res2 = AreOneAway("pales", "pale"); // true
        var res3 = AreOneAway("pale", "bale"); // true
        var res4 = AreOneAway("pale", "bake"); // false

        Console.ReadLine();
    }

    static bool AreOneAway(string first, string second)
    {
        var lengthDiff = first.Length - second.Length;

        if (Math.Abs(lengthDiff) > 1)
        {
            return false;
        }

        var alreadyModified = false;

        var firstIndex = 0;
        var secondIndex = 0;

        while (firstIndex < first.Length && secondIndex < second.Length)
        {
            if (first[firstIndex] == second[secondIndex])
            {
                firstIndex++;
                secondIndex++;
                continue;
            }

            if (alreadyModified)
            {
                return false;
            }

            alreadyModified = true;

            MoveIndexes(ref firstIndex, ref secondIndex, first.Length, second.Length);
        }

        return true;
    }

    static void MoveIndexes(ref int firstIndex, ref int secondIndex, int firstLength, int secondLength)
    {
        if (firstLength == secondLength)
        {
            firstIndex++;
            secondIndex++;
            return;
        }

        if (firstLength > secondLength)
        {
            firstIndex++;
            return;
        }

        secondIndex++;
    }
}

