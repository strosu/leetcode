namespace _10._3.SearchRotateArray;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    /// <summary>
    /// Problem 33 leetcode
    /// </summary>
    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            return Search(nums, target, 0, nums.Length - 1);
        }

        public int Search(int[] nums, int target, int start, int end)
        {
            if (end < start || start < 0)
            {
                return -1;
            }

            if (start == end)
            {
                return nums[start] == target ? start : -1;
            }

            var median = (start + end) / 2;

            if (nums[median] == target)
            {
                return median;
            }

            if (IsBetween(target, nums[start], nums[median]))
            {
                return Search(nums, target, start, median - 1);
            }

            return Search(nums, target, median + 1, end);
        }

        private bool IsBetween(int target, int first, int second)
        {
            // return Math.Min(first, second) <= target
            //    && target <= Math.Max(first, second);

            if (first <= second)
            {
                return first <= target && target <= second;
            }

            return target >= first || target <= second;
        }
    }
}

