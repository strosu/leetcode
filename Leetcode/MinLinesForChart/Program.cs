namespace MinLinesForChart;
class Program
{
    static void Main(string[] args)
    {
        var prices = new int[4][];
        prices[0] = new[] { 3, 4 };
        prices[1] = new[] { 1, 2 };
        prices[2] = new[] { 7, 8 };
        prices[3] = new[] { 2, 3 };

        var result = new Solution().MinimumLines(prices);

        var prices2 = new int[8][];
        prices2[0] = new[] { 1, 7 };
        prices2[1] = new[] { 2, 6 };
        prices2[2] = new[] { 3, 5 };
        prices2[3] = new[] { 4, 4 };
        prices2[4] = new[] { 5, 4 };
        prices2[5] = new[] { 6, 3 };
        prices2[6] = new[] { 7, 2 };
        prices2[7] = new[] { 8, 1 };

        var result2 = new Solution().MinimumLines(prices2);

        var prices3 = new int[3][];
        prices3[0] = new[] { 1, 1 };
        prices3[1] = new[] { 500000000, 499999999 };
        prices3[2] = new[] { 1000000000, 999999998 };

        var result3 = new Solution().MinimumLines(prices3);

        Console.ReadLine();
    }

    public class Solution
    {
        public int MinimumLines(int[][] stockPrices)
        {
            if (stockPrices.Length <= 2)
            {
                return stockPrices.Length - 1;
            }

            var prices = stockPrices.OrderBy(x => x[0]).ToArray();

            var minLines = 1;
            var angle = GetAngle(prices[0][0], prices[0][1], prices[1][0], prices[1][1]);

            for (var i = 1; i < prices.Length - 1; i++)
            {
                var newAngle = GetAngle(prices[i][0], prices[i][1], prices[i + 1][0], prices[i + 1][1]);
                if (angle.Item1 == newAngle.Item1 && angle.Item2 == newAngle.Item2)
                {
                    continue;
                }

                if (newAngle == (0, 0))
                {
                    if (angle == (0, 0))
                    {
                        continue;
                    }

                    angle = (0, 0);
                    minLines++;
                    continue;
                }

                if (angle == (0, 0))
                {
                    angle = newAngle;
                    minLines++;
                    continue;
                }

                // The top values must be perfectly divisible
                if (angle.Item1 >= newAngle.Item1)
                {
                    var divisor = angle.Item1 / newAngle.Item1;
                    var remainder = angle.Item1 % newAngle.Item1;
                    if (remainder == 0 && angle.Item2 == newAngle.Item2 * divisor)
                    {
                        continue;
                    }
                    else
                    {
                        angle = newAngle;
                        minLines++;
                    }
                }

                var divisor2 = newAngle.Item1 / angle.Item1;
                var remainder2 = newAngle.Item1 % angle.Item1;
                if (remainder2 == 0 && newAngle.Item2 == angle.Item2 * divisor2)
                {
                    continue;
                }

                angle = newAngle;
                minLines++;
            }

            return minLines;
        }

        private (int, int) GetAngle(int firstX, int firstY, int secondX, int secondY)
        {
            if (firstY == secondY)
            {
                return (0, 0);
            }

            return (secondX - firstX, secondY - firstY);
        }
    }
}

