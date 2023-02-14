namespace NonDecreasingArray;
class Program
{
    static void Main(string[] args)
    {
        var result = new Solution().CheckPossibility(new[] { 4, 2, 3 });
        var result2 = new Solution().CheckPossibility(new[] { 4, 2, 1 });
        var result3 = new Solution().CheckPossibility(new[] { -1, 4, 2, 3 });
        var result4 = new Solution().CheckPossibility(new[] { 3, 4, 2, 3 });
        var result5 = new Solution().CheckPossibility(new[] { 1, 1, 1 });
        var result6 = new Solution().CheckPossibility(new[] { 5, 7, 1, 8 });
        Console.ReadLine();
    }

    public class Solution
    {
        public bool CheckPossibility(int[] nums)
        {
            var minValue = int.MinValue;

            for (var i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    var prevValue = i == 0 ? nums[i + 1] : nums[i - 1];
                    return IsNotDescending(nums, i + 1, prevValue) || IsNotDescending(nums, i + 2, nums[i]);
                }

                minValue = nums[i];
            }

            return true;
        }

        private bool IsNotDescending(int[] nums, int startIndex, int minRequired)
        {
            if (startIndex > nums.Length - 1)
            {
                return true;
            }

            if (nums[startIndex] < minRequired)
            {
                return false;
            }

            for (var i = startIndex; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
