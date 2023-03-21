using System.Collections.Generic;

namespace _8._8.PermutationsDuplicates;
class Program
{
    static void Main(string[] args)
    {
        var res = new Solution().PermuteUnique(new[] { 1, 1, 2 });

        Console.ReadLine();
    }
}

public class Solution
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        var counter = new Dictionary<int, int>();

        // How many times does the number show up previously
        var predecessorCount = new int[nums.Length];

        for (var i = 0; i < nums.Length; i++)
        {
            if (counter.ContainsKey(nums[i]))
            {
                predecessorCount[i] = counter[nums[i]];
                counter[nums[i]]++;
            }
            else
            {
                predecessorCount[i] = 0;
                counter.Add(nums[i], 1);
            }
        }

        var result = new List<IList<int>>();
        GetPermutations(nums, predecessorCount, new LinkedList<int>(), new Dictionary<int, int>(), result, new HashSet<int>());

        return result;
    }

    public void GetPermutations(int[] nums, int[] prevs, LinkedList<int> current, Dictionary<int, int> dict, List<IList<int>> result, HashSet<int> positions)
    {
        if (current.Count == nums.Length)
        {
            result.Add(current.ToList());
            return;
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if (positions.Contains(i))
            {
                continue;
            }

            var minPrev = prevs[i];
            var currentValue = nums[i];

            if (dict.ContainsKey(currentValue) && dict[currentValue] < minPrev)
            {
                continue;
            }

            current.AddLast(currentValue);
            positions.Add(i);

            if (!dict.ContainsKey(currentValue))
            {
                dict.Add(currentValue, 1);
            }
            else
            {
                dict[currentValue]++;
            }

            GetPermutations(nums, prevs, current, dict, result, positions);

            dict[currentValue]--;
            positions.Remove(i);
            current.RemoveLast();
        }
    }
}

