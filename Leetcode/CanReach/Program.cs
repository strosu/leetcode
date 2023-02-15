namespace CanReach;
class Program
{
    static void Main(string[] args)
    {
        var res = new Solution().CanReach("011010", 2, 3); // true
        var res2 = new Solution().CanReach("01101110", 2, 3); // false
        var res3 = new Solution().CanReach("0111111111111111111111111111111101111101111111111111111110", 5, 26); // false
        var res4 = new Solution().CanReach("01", 1, 1); // false
        var res5 = new Solution().CanReach("0000000000", 1, 1); // true
        var res6 = new Solution().CanReach("00111010", 3, 5); // false
        var res7 = new Solution().CanReach("01111111011110", 1, 9); // true
        var res8 = new Solution().CanReach("011101101110", 3, 4); // true
        var res9 = new Solution().CanReach("01101110", 2, 3); // false
        Console.ReadLine();
    }

    public class Solution
    {
        public bool CanReach(string s, int minJump, int maxJump)
        {
            if (s[s.Length - 1] == '1')
            {
                return false;
            }

            if (maxJump >= s.Length - 1)
            {
                return true;
            }

            var positions = s.ToCharArray();
            positions[0] = '2';

            var currentOptionCount = 0;

            for (var i = minJump; i <= maxJump; i++)
            {
                if (positions[i] == '0')
                {
                    positions[i] = '2';
                }
            }

            var intervalEnd = maxJump - minJump + 1;
            var intervalStart = 1;

            for (var i = 0; i < intervalEnd; i++)
            {
                if (positions[i] == '2')
                {
                    currentOptionCount++;
                }
            }

            for (var i = maxJump + 1; i < s.Length; i++, intervalStart++, intervalEnd++)
            {
                if (positions[intervalStart - 1] == '2')
                {
                    currentOptionCount--;
                }

                if (positions[intervalEnd] == '2')
                {
                    currentOptionCount++;
                }

                if (currentOptionCount > 0 && positions[i] == '0')
                {
                    positions[i] = '2';
                }
            }

            return positions[positions.Length - 1] == '2';
        }
    }


    public class TakeTwo
    {
        public bool CanReach3(string s, int minJump, int maxJump)
        {
            if (s[s.Length - 1] == '1')
            {
                return false;
            }

            if (maxJump >= s.Length - 1)
            {
                return true;
            }

            var usableSteps = new int[s.Length];
            usableSteps[0] = 1;

            var usable = 1;

            for (var i = minJump; i <= maxJump; i++)
            {
                if (s[i] == '1')
                {
                    continue;
                }

                usableSteps[i] = usable;
                usable++;
            }

            for (var i = maxJump + 1; i < s.Length; i++)
            {
                if (s[i] == '1')
                {
                    continue;
                }

                usableSteps[i] = Math.Max(usableSteps[i - maxJump], usableSteps[i - minJump]);
            }

            return usableSteps[s.Length - 1] > 0;
        }

        public bool CanReach(string s, int minJump, int maxJump)
        {
            if (s[s.Length - 1] == '1')
            {
                return false;
            }

            if (maxJump >= s.Length - 1)
            {
                return true;
            }

            var positions = s.ToCharArray();
            var reachable = new bool[s.Length];
            reachable[0] = true;

            for (var i = 0; i < s.Length; i++)
            {
                if (positions[i] == '1')
                {
                    continue;
                }

                if (!reachable[i])
                {
                    continue;
                }

                for (var j = i + minJump; j <= i + maxJump && j < s.Length; j++)
                {
                    if (positions[j] == '1' || reachable[j])
                    {
                        continue;
                    }

                    reachable[j] = true;
                }
            }

            return reachable[s.Length - 1];
        }
    }
}
