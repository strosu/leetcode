using System.Numerics;

namespace SumIntervals;
class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine(new Solution().MinimumDifference(new[] { 7772197, 4460211, -7641449, -8856364, 546755, -3673029, 527497, -9392076, 3130315, -5309187, -4781283, 5919119, 3093450, 1132720, 6380128, -3954678, -1651499, -7944388, -3056827, 1610628, 7711173, 6595873, 302974, 7656726, -2572679, 0, 2121026, -5743797, -8897395, -9699694 }));
        Console.WriteLine(new Solution().MinimumDifference(new[] { 25, 49, 39, 42, 57, 35 }));
        Console.ReadLine();
    }
}

class Solution
{
    public int MinimumDifference(int[] nums)
    {
        var orderedNums = nums.OrderBy(x => x).ToArray();
        var totalSum = nums.Sum();
        var sum = int.MaxValue;
        var targetElementCount = nums.Length / 2;
        bool stop = false;
        SumRecursive(orderedNums, new Stack<int>(), 0, 0, ref totalSum, ref sum, ref targetElementCount, ref stop);

        return sum;
    }

    void SumRecursive(int[] nums, Stack<int> current, int position, int currentSum, ref int totalSum, ref int minSum, ref int targetElementCount, ref bool stop)
    {
        if (current.Count == targetElementCount)
        {
            var otherSum = totalSum - currentSum;
            var newSum = Math.Abs(currentSum - otherSum);
            if (newSum < minSum)
            {
                minSum = newSum;
            }
            else
            {
                stop = true;
            }

            return;
        }

        for (var i = position; i < nums.Length; i++)
        {
            current.Push(nums[i]);

            var shouldBreak = false;
            SumRecursive(nums, current, i + 1, currentSum + nums[i], ref totalSum, ref minSum, ref targetElementCount, ref shouldBreak);

            current.Pop();

            if (shouldBreak)
            {
                break;
            }
        }
    }
}

