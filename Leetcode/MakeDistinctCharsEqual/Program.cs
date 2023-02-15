using System.ComponentModel.Design;

namespace MakeDistinctCharsEqual;
class Program
{
    static void Main(string[] args)
    {
        var res1 = new Solution().IsItPossible("ac", "b"); // false
        var res2 = new Solution().IsItPossible("abcc", "aab"); // true
        var res3 = new Solution().IsItPossible("abcde", "fghij"); // true
        var res4 = new Solution().IsItPossible("ab", "abcc"); // false
        var res5 = new Solution().IsItPossible("aa", "ab"); // false

        Console.ReadLine();
    }

    public class Solution
    {
        public bool IsItPossible(string word1, string word2)
        {
            var first = Parse(word1);
            var second = Parse(word2);

            foreach (var firstKvp in first.CharMap)
            {
                foreach (var secondKvp in second.CharMap)
                {
                    var firstLetter = firstKvp.Key;
                    var secondLetter = secondKvp.Key;

                    var candidateUnique1 = first.DistinctChars;
                    var candidateUnique2 = second.DistinctChars;

                    if (firstLetter == secondLetter)
                    {
                        // Swapping the same letter does nothing
                        // If they have the same number of distinct chars, we're done
                        if (first.DistinctChars == second.DistinctChars)
                        {
                            return true;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (firstKvp.Value)
                    {
                        // By removing it, we reduce the number of uniquer characters
                        candidateUnique1--;
                    }

                    if (secondKvp.Value)
                    {
                        candidateUnique2--;
                    }

                    if (!first.CharMap.ContainsKey(secondLetter))
                    {
                        candidateUnique1++;
                    }

                    if (!second.CharMap.ContainsKey(firstLetter))
                    {
                        candidateUnique2++;
                    }

                    if (candidateUnique1 == candidateUnique2)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private ParseResult Parse(string word)
        {
            var dict = new Dictionary<char, bool>(); // Maps if a certain character is unique within the current word

            short distinct = 0;

            for (var i = 0; i < word.Length; i++)
            {
                var currentChar = word[i];
                if (!dict.ContainsKey(currentChar))
                {
                    dict.Add(currentChar, true);
                    distinct++;
                }
                else
                {
                    dict[currentChar] = false;
                }
            }

            return new ParseResult
            {
                CharMap = dict,
                DistinctChars = distinct
            };
        }

        public class ParseResult
        {
            public Dictionary<char, bool> CharMap { get; set; }

            public short DistinctChars { get; set; }
        }
    }
}

