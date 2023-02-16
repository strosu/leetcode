namespace _1237_Min_Swaps_to_Equalize;
class Program
{
    static void Main(string[] args)
    {
        var res = new Solution().MinimumSwap("xx", "yy"); // 1
        var res2 = new Solution().MinimumSwap("xy", "yx"); // 2
        var res3 = new Solution().MinimumSwap("xx", "xy"); // -1

        Console.ReadLine();
    }

    public class Solution
    {
        public int MinimumSwap(string s1, string s2)
        {
            var xy = 0;
            var yx = 0;
            var minMoves = 0;

            for (var i = 0; i < s1.Length; i++)
            {
                if (s1[i] == s2[i])
                {
                    continue;
                }

                if (s1[i] == 'x')
                {
                    xy++;
                }
                else
                {
                    yx++;
                }
            }

            if ((xy + yx) % 2 == 1)
            {
                return -1;
            }

            // We have an even number of positions mismatched in total. This means both xySwaps and yxSwaps are odd, or both are even
            // We spend 1 operation to make both sets even
            if (xy % 2 == 1)
            {
                xy--;
                yx++;
                minMoves = 1;
            }

            var xySwaps = xy / 2;
            minMoves += xySwaps; // Each pair of xx/yy can be normalized with 1 operations

            var yxSwaps = yx / 2;
            minMoves += yxSwaps; // Same for each pair of yy/xx, it takes a single opration

            return minMoves;
        }
    }
}

