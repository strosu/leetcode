using System;

namespace _123.Stocks3;
class Program
{
    static void Main(string[] args)
    {
        var res = new Solution().MaxProfit(new[] { 3, 3, 5, 0, 0, 3, 1, 4 });

        Console.ReadLine();
    }
}

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        // var maxAfter = new int[prices.Length];
        var maxSoFar = int.MinValue;

        var bestSum = new int[prices.Length];
        var bestSoFar = int.MinValue;

        for (var i = prices.Length - 1; i >= 0; i--)
        {
            maxSoFar = Math.Max(maxSoFar, prices[i]);
            // maxAfter[i] = maxSoFar;

            bestSoFar = Math.Max(bestSoFar, maxSoFar - prices[i]);
            bestSum[i] = bestSoFar;
        }

        var minSoFar = 0;
        var minBefore = new int[prices.Length];

        for (var i = 0; i < prices.Length; i++)
        {
            minSoFar = Math.Min(minSoFar, prices[i]);
            minBefore[i] = minSoFar;
        }

        var firstCandidate = 0;
        var bestTrades = 0;

        for (var i = 0; i < prices.Length; i++)
        {
            firstCandidate = Math.Max(firstCandidate, prices[i] - minBefore[i]);

            bestTrades = Math.Max(bestTrades, firstCandidate + bestSum[i]);
        }

        return bestTrades;

    }
}

