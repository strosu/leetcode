namespace _1657.StringsAreClose;
class Program
{
    static void Main(string[] args)
    {
        var res4 = new Solution().CloseStrings("uau", "ssx"); // false

        var res1 = new Solution().CloseStrings("abc", "bca"); // true
        var res2 = new Solution().CloseStrings("a", "aa"); // false
        var res3 = new Solution().CloseStrings("cabbba", "abbccc"); // true

        Console.ReadLine();
    }

    public class Solution
    {
        public bool CloseStrings(string word1, string word2)
        {
            if (word1.Length != word2.Length)
            {
                return false;
            }

            var firstMap = new int[26];
            var secondMap = new int[26];

            for (var i = 0; i < word1.Length; i++)
            {
                firstMap[word1[i] - 'a']++;
                secondMap[word2[i] - 'a']++;
            }

            for (var i = 0; i < 26; i++)
            {
                if (firstMap[i] == secondMap[i])
                {
                    continue;
                }

                if (firstMap[i] == 0 || secondMap[i] == 0)
                {
                    return false;
                }

                bool foundSwap = false;

                for (var j = i + 1; j < 26; j++)
                {
                    if (secondMap[j] == firstMap[i])
                    {
                        var tmp = secondMap[i];
                        secondMap[i] = secondMap[j];
                        secondMap[j] = tmp;
                        foundSwap = true;
                        break;
                    }
                }

                if (!foundSwap)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

