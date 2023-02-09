namespace StepsArrayNonDecreasing;
class Program
{
    static void Main(string[] args)
    {
        var x4 = new Solution().TotalSteps(new[] { 7, 11, 1 });
        var x3 = new Solution().TotalSteps(new[] { 10, 6, 5, 10, 15 });
        var x = new Solution().TotalSteps(new[] { 10, 1, 2, 3, 4, 5, 6, 1, 2, 3 });
        var x2 = new Solution().TotalSteps(new[] { 5, 3, 4, 4, 7, 3, 6, 11, 8, 5, 11 });

        Console.ReadLine();
    }

    public class Solution
    {
        public int TotalSteps(int[] nums)
        {
            var maxSequence = 0;

            for (var i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] <= nums[i + 1])
                {
                    continue;
                }

                if (i == nums.Length - 1)
                {
                    continue;
                }

                var j = i + 1;

                while (j < nums.Length - 1)
                {
                    if (nums[j] > nums[j + 1] || nums[j + 1] >= nums[i])
                    {
                        break;
                    }

                    j++;
                }

                if (j - i > maxSequence)
                {
                    maxSequence = j - i;
                }
            }

            return maxSequence;
        }
    }
}