﻿namespace MaximumTop;
class Program
{
    static void Main(string[] args)
    {
        var x = new Solution().MaximumTop(new[] { 5, 2, 2, 4, 0, 6 }, 4);
        var x2 = new Solution().MaximumTop(new[] { 5, 2, 2, 4, 0, 6 }, 20);
        var x22 = new Solution().MaximumTop(new[] { 5, 2, 2, 4, 0, 6 }, 5);
        var x222 = new Solution().MaximumTop(new[] { 5, 2, 2, 4, 0, 6 }, 6);
        var x3 = new Solution().MaximumTop(new[] { 91, 98, 17, 79, 15, 55, 47, 86, 4, 5, 17, 79, 68, 60, 60, 31, 72, 85, 25, 77, 8, 78, 40, 96, 76, 69, 95, 2, 42, 87, 48, 72, 45, 25, 40, 60, 21, 91, 32, 79, 2, 87, 80, 97, 82, 94, 69, 43, 18, 19, 21, 36, 44, 81, 99 }, 2);
        var x33 = new Solution().MaximumTop(new[] { 5 }, 1);
        var x333 = new Solution().MaximumTop(new[] { 35, 43, 23, 86, 23, 45, 84, 2, 18, 83, 79, 28, 54, 81, 12, 94, 14, 0, 0, 29, 94, 12, 13, 1, 48, 85, 22, 95, 24, 5, 73, 10, 96, 97, 72, 41, 52, 1, 91, 3, 20, 22, 41, 98, 70, 20, 52, 48, 91, 84, 16, 30, 27, 35, 69, 33, 67, 18, 4, 53, 86, 78, 26, 83, 13, 96, 29, 15, 34, 80, 16, 49 }, 15);
        var x334 = new Solution().MaximumTop(new[] { 3, 1, 2 }, 1);
        var x5 = new Solution().MaximumTop(new[] { 1, 0 }, 1);
        var x55 = new Solution().MaximumTop(new[] { 0, 1, 2 }, 3);
        Console.ReadLine();
    }

    public class Solution
    {
        public int MaximumTop(int[] nums, int k)
        {
            var n = nums.Length;

            if (n == 0)
            {
                return -1;
            }

            if (n == 1)
            {
                if (k % 2 == 1)
                {
                    return -1;
                }

                return nums[0];
            }

            var max = int.MinValue;
            for (var i = 0; i < n && i <= k; i++)
            {
                if (max < nums[i] && i != k - 1)
                {
                    max = nums[i];
                }
            }

            return max;
        }
    }
}

