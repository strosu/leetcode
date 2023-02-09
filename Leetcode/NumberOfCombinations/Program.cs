using System.ComponentModel;
using System.Numerics;

namespace NumberOfCombinations;
class Program
{
    static void Main(string[] args)
    {
        //var x1 = new Solution().NumberOfCombinations("1023"); // 3
        //var x2 = new Solution().NumberOfCombinations("9999999999999"); // 101

        var x1 = new Solution2().NumberOfCombinations("1023");
        var x2 = new Solution().NumberOfCombinations("1023");

        //var x1 = new Solution().NumberOfCombinations("181599706296201533688444310698720506149731032417146774186256527047743490211586938068687937416089");
        //var x2 = new Solution().NumberOfCombinations("092");
        //var x3 = new Solution().NumberOfCombinations("0");

        Console.ReadLine();
    }

    public class Solution2
    {
        private BigInteger _foundSoFar;

        public int NumberOfCombinations(string num)
        {
            if (num.StartsWith('0'))
            {
                return 0;
            }

            GetRecursive(0, 0, 0, num);

            BigInteger modulo = (BigInteger)(Math.Pow(10, 9) + 7);
            return (int)(_foundSoFar % modulo);
        }

        public void GetRecursive(BigInteger lastNumber, int lastNumberDigitCount, int currentIndex, string num)
        {
            if (currentIndex == num.Length)
            {
                _foundSoFar++;
                return;
            }

            if (lastNumberDigitCount > num.Length - currentIndex)
            {
                // The last number is too large to have another one after it
                //return;
            }

            var candidateDigit = num[currentIndex];

            if (candidateDigit == '0')
            {
                // The only thing we can do with a 0 is add it to the previous number
                //GetRecursive(lastNumber * 10, currentIndex + 1, num);
                return;
            }

            var nextCandidates = BuildNext(lastNumber, currentIndex, num);
            foreach (var (nextNum, digitCount, index) in nextCandidates)
            {
                GetRecursive(nextNum, digitCount, index, num);
            }
        }

        private IList<(BigInteger, int, int)> BuildNext(BigInteger lastNumber, int currentIndex, string num)
        {
            var result = new List<(BigInteger, int, int)>();
            BigInteger candidate = 0;

            var nextIndex = currentIndex;
            var digitCount = 0;

            do
            {
                candidate = candidate * 10 + (num[nextIndex] - '0');
                nextIndex++;
                digitCount++;
            }
            while (candidate < lastNumber && nextIndex < num.Length);

            if (candidate >= lastNumber)
            {
                result.Add((candidate, digitCount, nextIndex));
            }

            for (var i = nextIndex; i < num.Length; i++)
            {
                candidate = candidate * 10 + (num[nextIndex] - '0');
                nextIndex++;
                digitCount++;
                result.Add((candidate, digitCount, nextIndex));
            }

            return result;
        }
    }

    public class Solution
    {
        int[][] dp;
        int[][] subSums;
        int modulo = (int)Math.Pow(10, 9) + 7;

        public int NumberOfCombinations(string num)
        {
            if (num.StartsWith('0'))
            {
                return 0;
            }

            var n = num.Length;
            dp = new int[n][];
            subSums = new int[n][];

            for (var i = 0; i < n; i++)
            {
                dp[i] = new int[n];
                subSums[i] = new int[n];
            }

            for (var i = 0; i < n; i++)
            {
                dp[0][i] = 1;
            }

            for (var i = 1; i < n; i++)
            {
                for (var j = 1; j <= i; j++)
                {
                    if (subSums[i - j][j] == 0)
                    {
                        for (var k = 0; k < j; k++)
                        {
                            subSums[i - j][j] += dp[i - j][k] % modulo;
                        }
                    }

                    dp[i][j] = subSums[i - j][j];

                    if (AddLastNumber(i, j, num))
                    {
                        dp[i][j] = (dp[i][j] + dp[i - j][j]) % modulo;
                    }
                }
            }

            return dp[n - 1][n - 1] % modulo;
        }

        private bool AddLastNumber(int i, int j, string num)
        {
            // Compares the substring i-j and i - 2 * j
            if (i < j * 2)
            {
                return true;
            }

            BigInteger current = BigInteger.Parse(num.Substring(i - j, j));
            BigInteger previous = BigInteger.Parse(num.Substring(i - j - j, j));
            return current >= previous;
        }
    }
}
