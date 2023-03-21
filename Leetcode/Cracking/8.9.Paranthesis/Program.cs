using System.Collections.Generic;
using System.Text;

namespace _8._9.Paranthesis;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            Generate(new StringBuilder(), 0, result, n);

            return result;
        }

        public void Generate(StringBuilder current, int currentOpen, List<string> results, int n)
        {
            if (current.Length == 2 * n)
            {
                results.Add(current.ToString());
                return;
            }

            if (currentOpen < n)
            {
                current.Append("(");
                Generate(current, currentOpen + 1, results, n);
                current.Length--;
            }

            if (current.Length - currentOpen < currentOpen)
            {
                current.Append(")");
                Generate(current, currentOpen, results, n);
                current.Length--;
            }
        }
    }
}

