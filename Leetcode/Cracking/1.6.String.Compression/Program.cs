using System.Text;

namespace _1._6.String.Compression;
class Program
{
    static void Main(string[] args)
    {
        var res1 = GetCompressed("abcd"); // abcd
        var res2 = GetCompressed("aaaa"); // a4
        var res3 = GetCompressed("aaaabcccd"); // a4bc3s
        var res4 = GetCompressed("aabcccccaaa"); // a2bc5a2

        Console.ReadLine();
    }

    static string GetCompressed(string input)
    {
        var builder = new StringBuilder();

        var currentIndex = 0;
        while (currentIndex < input.Length)
        {
            var counter = 1;

            while (currentIndex < input.Length - 1 && input[currentIndex] == input[currentIndex + 1])
            {
                currentIndex++;
                counter++;
            }

            if (counter > 1)
            {
                builder.Append($"{input[currentIndex]}{counter}");
            }
            else
            {
                builder.Append(input[currentIndex]);
            }

            currentIndex++;
        }

        return builder.ToString();
    }
}

