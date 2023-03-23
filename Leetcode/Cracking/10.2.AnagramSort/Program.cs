namespace _10._2.AnagramSort;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    public class Solution
    {
        // Does a group instead of a sort, but it's the same problem
        // Ran against leetcode, problem 49
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var map = new Dictionary<string, IList<string>>();

            foreach (var word in strs)
            {
                var key = ComputeKey(word);
                if (map.ContainsKey(key))
                {
                    map[key].Add(word);
                }
                else
                {
                    map.Add(key, new List<string> { word });
                }
            }

            return map.Select(x => x.Value).ToList();
        }

        private string ComputeKey(string word)
        {
            var chars = word.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
}

