namespace MaxSubarray;
class Program
{
    static void Main(string[] args)
    {
        var result = GetMaxSum(new[] { -2, -1, -3, -4, -1, 2, -1, 5, -4, -11, -22, -7 });
        Console.WriteLine(result.sum);
        Console.WriteLine(result.startPosition);
        Console.WriteLine(result.endPosition);

        //var result = new Solution().KConcatenationMaxSum(new[] { 1, 2 }, 3);
        //var result2 = new Solution().KConcatenationMaxSum(new[] { 1, -2, 1 }, 5);
        //var result3 = new Solution().KConcatenationMaxSum(new[] { -1, -2 }, 3);

        Console.ReadLine();
    }

    static (int sum, int startPosition, int endPosition) GetMaxSum(int[] array)
    {
        var maxSum = int.MinValue;
        var currentSum = 0;
        var currentStart = 0;
        var bestStart = 0;
        var bestEnd = 0;

        for (var i = 0; i < array.Length; i++)
        {
            currentSum += array[i];

            if (maxSum < currentSum)
            {
                maxSum = currentSum;
                bestEnd = i;
                bestStart = currentStart;
            }

            if (currentSum < 0)
            {
                currentStart = i;
                currentSum = 0;
            }
        }

        return (maxSum, bestStart + 1, bestEnd);
    }

    public class Solution
    {
        public int KConcatenationMaxSum(int[] arr, int k)
        {
            var modulo = (int)(Math.Pow(10, 9) + 7);

            long maxSum = 0;
            long currentSum = 0;

            long arraySum = 0;

            GetForArray(arr, ref currentSum, ref maxSum);
            if (k == 1)
            {
                return (int)(maxSum % modulo);
            }

            for (var i = 0; i < arr.Length; i++)
            {
                arraySum += arr[i];
            }

            GetForArray(arr, ref currentSum, ref maxSum);

            // If by doing another iteration (i.e. arraySum is positive), we should add as many as possible

            // This is due to the fact that adding the remainder will give us access to another (round of our max sum), asusming we can still loop enough times
            // At this point we know maxSum >= arraySum, otherwise the entire array would be maxSum
            if (arraySum > 0)
            {
                maxSum += (k - 2) * arraySum;
            }

            // If the remainder of the last iteration would be positive, it would have been added into the original sum
            return (int)(maxSum % modulo);
        }

        private void GetForArray(int[] arr, ref long currentSum, ref long maxSum)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                currentSum += arr[i];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }

                currentSum = Math.Max(0, currentSum);
            }
        }
    }
}

