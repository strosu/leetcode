using System.Text;

namespace Mathworks;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var res1 = GetMinDivisor("bcdbcdbcdbcd", "bcdbcd"); // 3
        var res2 = GetMinDivisor("bcdbcdbcd", "bcdbcd"); // -1

        Console.ReadLine();
    }

    static int GetMinDivisor(string s, string t)
    {
        var smallStringCharrArray = t.ToCharArray();
        var largeStringCharArray = s.ToCharArray();

        if (!Divides(smallStringCharrArray, largeStringCharArray, smallStringCharrArray.Length))
        {
            return -1;
        }

        var divisorCandidate = new char[smallStringCharrArray.Length];

        for (var i = 0; i < t.Length; i++)
        {
            divisorCandidate[i] = smallStringCharrArray[i];

            if (Divides(divisorCandidate, smallStringCharrArray, i + 1))
            {
                return i + 1;
            }
        }

        return -1;
    }

    static bool Divides(char[] candidate, char[] targetString, int candidateSize)
    {
        if (targetString.Length % candidateSize != 0)
        {
            return false;
        }

        var candidateIndex = 0;
        var targetStringIndex = 0;

        while (targetStringIndex < targetString.Length)
        {
            if (candidate[candidateIndex] != targetString[targetStringIndex])
            {
                return false;
            }

            candidateIndex = (candidateIndex + 1) % candidateSize;
            targetStringIndex++;
        }

        return true;
    }
}

