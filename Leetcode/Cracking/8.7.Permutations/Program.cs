using System.Text;

namespace _8._7.Permutations;
class Program
{
    static void Main(string[] args)
    {
        var res = Permute("abcd".ToCharArray(), new StringBuilder(), new HashSet<int>());

        Console.ReadLine();
    }

    static List<string> Permute(char[] input, StringBuilder currentCandidate, HashSet<int> usedPositions)
    {
        var result = new List<string>();

        if (currentCandidate.Length == input.Length)
        {
            result.Add(currentCandidate.ToString());
        }

        for (var i = 0; i < input.Length; i++)
        {
            if (usedPositions.Contains(i))
            {
                continue;
            }

            currentCandidate.Append(input[i]);

            usedPositions.Add(i);

            result.AddRange(Permute(input, currentCandidate, usedPositions));

            currentCandidate.Length--;
            usedPositions.Remove(i);
        }

        return result;
    }
}

