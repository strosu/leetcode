using System.Numerics;

namespace NumberOfCombinations;

partial class Program
{
    public class Solution
    {
        int[][] dp; // Let dp[i][j] be the number of combinations for the first i characters, when the last number has a length of j + 1
        //int[][] subSums;

        int modulo = (int)Math.Pow(10, 9) + 7;

        public int NumberOfCombinations(string num)
        {
            if (num.StartsWith('0'))
            {
                return 0;
            }

            var n = num.Length;
            dp = new int[n][];
            //subSums = new int[n][];

            for (var i = 0; i < n; i++)
            {
                dp[i] = new int[n];
                //subSums[i] = new int[n];
            }

            for (var i = 0; i < n; i++)
            {
                dp[i][i] = 1;
            }

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j <= i; j++)
                {
                    for (var k = 1; k < j; k++)
                    {
                        dp[i][j] = (dp[i][j] + dp[i - j][k]) % modulo;
                    }
                    //if (subSums[i - j][j] == 0)
                    //{
                    //    for (var k = 0; k < j; k++)
                    //    {
                    //        subSums[i - j][j] += dp[i - j][k] % modulo;
                    //    }
                    //}

                    //dp[i][j] = subSums[i - j][j];

                    if (AddLastNumber(i, j, num))
                    {
                        dp[i][j] = (dp[i][j] + dp[i - j][j]) % modulo;
                    }
                }
            }

            var result = 0;
            for (var i = 0; i < n; i++)
            {
                result = (result + dp[n - 1][i]) % modulo;
            }

            return result;
            //return dp[n - 1][n - 1] % modulo;
        }

        private bool AddLastNumber(int i, int j, string num)
        {
            // Compares the substring i-j and i - 2 * j
            if (i < j * 2)
            {
                return true;
            }

            BigInteger current = BigInteger.Parse(num.Substring(i - j, j + 1));
            BigInteger previous = BigInteger.Parse(num.Substring(i - j - j, j + 1));
            return current >= previous;
        }
    }
}
