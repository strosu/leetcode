using System.Numerics;

namespace KnightDialer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var res = GetDifferentCombinations(1, 1); // 1
            var res2 = GetDifferentCombinations(6, 2); // 3
            var res3 = GetDifferentCombinations(2, 3); // 4
            var res4 = GetDifferentCombinations(2, 1000); // 4

            Console.ReadLine();
        }

        static BigInteger GetDifferentCombinations(int startingDigit, int jumps)
        {
            var next = new Dictionary<int, List<int>>()
            {
                { 1, new List<int>() { 6, 8 } },
                { 2, new List<int>() { 7, 9 } },
                { 3, new List<int>() { 4, 8 } },
                { 4, new List<int>() { 3, 9 } },
                { 5, new List<int>() },
                { 6, new List<int>() { 1, 7, 0 } },
                { 7, new List<int>() { 2, 6 } },
                { 8, new List<int>() { 1, 3 } },
                { 9, new List<int>() { 4, 2 } },
                { 0, new List<int>() { 4, 6 } }
            };

            var prevRow = new BigInteger[10];

            for (var i = 0; i < 10; i++)
            {
                if (i != 5)
                {
                    prevRow[i] = 1;
                }
            }

            for (var i = 1; i < jumps; i++)
            {
                var currentRow = new BigInteger[10];

                for (var j = 0; j < 10; j++)
                {
                    var children = next[j];
                    foreach (var child in children)
                    {
                        currentRow[j] += prevRow[child];
                    }

                }

                Array.Copy(currentRow, prevRow, 10);
            }

            return prevRow[startingDigit];
        }
    }
}