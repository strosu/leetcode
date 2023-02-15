using System.Numerics;

namespace AppendKMinSum;
class Program
{
    static void Main(string[] args)
    {
        var res1 = new Solution().MinimalKSum(new[] { 1, 4, 25, 10, 25 }, 2);
        var res2 = new Solution().MinimalKSum(new[] { 1, 10, 25, 10, 25 }, 3);
        var res3 = new Solution().MinimalKSum(new[] { 1, 10, 25, 10, 25 }, 12);
        var res4 = new Solution().MinimalKSum(new[] { 1, 10 }, 12);
        var res5 = new Solution().MinimalKSum(new[] { 1, 2, 3, 4, 5, 6, 12, 10 }, 6); // 7+8+9+11+13+14 = 62
        var res6 = new Solution().MinimalKSum(new[] { 1, 2, 3, 4, 5, 6 }, 6); // 7+8+9+10+11+12 = 57

        Console.ReadLine();
    }

    public class Solution
    {
        public long MinimalKSum(int[] nums, int k)
        {
            Array.Sort(nums);

            var toAdd = k;
            var currentIndex = 0;
            var startValue = 1;
            var endValue = nums[0];

            long sum = 0;

            do
            {
                var currentlyAvailable = endValue - startValue;

                if (currentlyAvailable > 0)
                {
                    if (currentlyAvailable < toAdd)
                    {
                        toAdd -= currentlyAvailable;
                        sum += IncludingSumBetween(startValue, endValue - 1);
                        //for (var i = startValue; i < endValue; i++)
                        //{
                        //    sum += i;
                        //}
                    }
                    else
                    {
                        sum += IncludingSumBetween(startValue, startValue + toAdd - 1);
                        //for (var i = 0; i < toAdd; i++)
                        //{
                        //    sum += i + startValue;
                        //}

                        return sum;
                    }
                }

                currentIndex++;
                startValue = endValue + 1;

                if (currentIndex == nums.Length)
                {
                    break;
                }

                endValue = nums[currentIndex];
            }

            while (toAdd > 0);

            if (toAdd > 0)
            {
                sum += IncludingSumBetween(startValue, startValue + toAdd - 1);
                //for (var i = startValue; i < startValue + toAdd; i++)
                //{
                //    sum += i;
                //}
            }

            return sum;
        }

        private long IncludingSumBetween(int start, int end)
        {
            // Compute the sum between 1..end
            long largeSum = (end * (end + 1)) / 2;

            // Compute the sum between 1..start - 1
            long smallSum = (start * (start - 1)) / 2;

            return (long)(largeSum - smallSum);
        }
    }
}

