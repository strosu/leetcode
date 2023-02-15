namespace JumpGameV;
class Program
{
    static void Main(string[] args)
    {
        var res1 = new Solution().MaxJumps(new[] { 6, 4, 14, 6, 8, 13, 9, 7, 10, 6, 12 }, 2); // 6
        var res2 = new Solution().MaxJumps(new[] { 3, 3, 3, 3 }, 1); // 1
        var res3 = new Solution().MaxJumps(new[] { 7, 6, 5, 4, 3, 2, 1 }, 1); // 7
        Console.ReadLine();
    }

    public class Solution
    {
        public int MaxJumps(int[] arr, int d)
        {
            var maxJumpsFrom = new int[arr.Length];

            var max = 1;

            for (var i = 0; i < arr.Length; i++)
            {
                var currentCandidate = Compute(arr, maxJumpsFrom, d, i);
                if (max < currentCandidate)
                {
                    max = currentCandidate;
                };
            }

            return max;
        }


        private int Compute(int[] arr, int[] maxJumpsFrom, int d, int currentPosition)
        {
            if (maxJumpsFrom[currentPosition] > 0)
            {
                return maxJumpsFrom[currentPosition];
            }

            var min = 0;
            for (var j = currentPosition - 1; j >= Math.Max(currentPosition - d, 0); j--)
            {
                if (arr[j] >= arr[currentPosition])
                {
                    break;
                }

                if (maxJumpsFrom[j] == 0)
                {
                    Compute(arr, maxJumpsFrom, d, j);
                }

                if (min < maxJumpsFrom[j])
                {
                    min = maxJumpsFrom[j];
                }
            }

            for (var j = currentPosition + 1; j <= Math.Min(currentPosition + d, arr.Length - 1); j++)
            {
                if (arr[j] >= arr[currentPosition])
                {
                    break;
                }

                if (maxJumpsFrom[j] == 0)
                {
                    Compute(arr, maxJumpsFrom, d, j);
                }

                if (min < maxJumpsFrom[j])
                {
                    min = maxJumpsFrom[j];
                }
            }

            maxJumpsFrom[currentPosition] = min + 1;

            return maxJumpsFrom[currentPosition];
        }
    }
}

