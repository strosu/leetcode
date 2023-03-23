namespace _5.LongestPalindrome;
class Program
{
    static void Main(string[] args)
    {
        var res = new Solution().LongestPalindrome("babab");
        var res2 = new Solution().LongestPalindrome("bccb");

        Console.ReadLine();
    }

    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            var maxPalindrome = new Substring
            {
                Start = 0,
                End = 0
            };

            for (var i = 0; i < s.Length; i++)
            {
                var maxFromHere = GetMax(s, i);

                if (maxFromHere.Length > maxPalindrome.Length)
                {
                    maxPalindrome = maxFromHere;
                }
            }

            return s.Substring(maxPalindrome.Start, maxPalindrome.Length);
        }

        private Substring GetMax(string s, int position)
        {
            var maxEven = GetMax(s, position, position + 1);
            var maxOdd = GetMax(s, position, position);

            if (maxEven == null)
            {
                return maxOdd;
            }

            return maxEven.Length > maxOdd.Length ? maxEven : maxOdd;
        }

        private Substring GetMax(string s, int prefixPosition, int suffixPosition)
        {
            while (prefixPosition >= 0 && suffixPosition < s.Length && s[prefixPosition] == s[suffixPosition])
            {
                prefixPosition--;
                suffixPosition++;
            }

            prefixPosition++;
            suffixPosition--;

            return new Substring()
            {
                Start = prefixPosition,
                End = suffixPosition
            };
        }

        public class Substring
        {
            public int Start { get; set; }

            public int End { get; set; }

            public int Length => End - Start + 1;
        }
    }
}

