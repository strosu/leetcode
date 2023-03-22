namespace _8._11.CoinChange;
class Program
{
    static void Main(string[] args)
    {
        //var res = new Solution().Change2(500, new[] { 3, 5, 7, 8, 9, 10, 11 });
        var res = new Solution().Change2(5, new[] { 1, 2, 5 });

        var rr = new Solution().Change(5, new[] { 1, 2, 5 });

        Console.ReadLine();
    }

    public class Solution
    {
        public int Change(int amount, int[] coins)
        {
            var partial = new int[amount + 1];
            partial[0] = 1;

            foreach (var coin in coins)
            {
                for (var i = coin; i <= amount; i++)
                {
                    partial[i] += partial[i - coin];
                }
            }

            return partial[amount];
        }

        public int Change3(int amount, int[] coins)
        {
            return Change3Recursive(amount, coins, coins.Length - 1, new int[amount + 1, coins.Length]);
        }

        private int Change3Recursive(int amount, int[] coins, int maxCoinIndex, int[,] partials)
        {
            if (amount < 0 || maxCoinIndex < 0)
            {
                return 0;
            }

            if (partials[amount, maxCoinIndex] > 0)
            {
                return partials[amount, maxCoinIndex];
            }

            if (maxCoinIndex == 0)
            {
                return amount % coins[maxCoinIndex] == 0 ? 1 : 0;
            }

            var currentCoinValue = coins[maxCoinIndex];

            for (var current = 0; current < amount; current += currentCoinValue)
            {
                partials[amount, maxCoinIndex] += Change3Recursive(amount - current, coins, maxCoinIndex - 1, partials);
            }

            return partials[amount, maxCoinIndex];
        }

        public int Change2(int amount, int[] coins)
        {
            return GetChange2(amount, coins, 0, new int[amount + 1, coins.Length]);
        }

        public int GetChange2(int amount, int[] coins, int index, int[,] map)
        {
            if (map[amount, index] > 0)
            {
                return map[amount, index];
            }

            var value = coins[index];

            if (index == coins.Length - 1)
            {
                return amount % value == 0 ? 1 : 0;
            }

            var result = 0;
            for (var i = 0; i <= amount; i += value)
            {
                result += GetChange2(amount - i, coins, index + 1, map);
            }

            map[amount, index] = result;

            return result;
        }

        public int Change33(int amount, int[] coins)
        {
            return ChangeRecursively(amount, coins, 0);
        }

        public int ChangeRecursively(int amount, int[] coins, int index)
        {
            if (amount < 0)
            {
                return 0;
            }

            if (amount == 0)
            {
                return 1;
            }

            var result = 0;
            for (var i = index; i < coins.Length; i++)
            {
                result += ChangeRecursively(amount - coins[i], coins, i);
            }

            return result;
        }
    }
}

