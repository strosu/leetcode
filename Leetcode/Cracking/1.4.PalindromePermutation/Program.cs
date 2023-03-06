namespace _1._4.PalindromePermutation;
class Program
{
    static void Main(string[] args)
    {
        var res1 = IsPalindromePermutation("Tact Coa"); // true
        var res2 = IsPalindromePermutation("Taco Cat"); // true
        var res3 = IsPalindromePermutation("Tactt"); // false

        var res111 = IsPalindromeBitVector("Ttact Coa"); // true
        var res11 = IsPalindromeBitVector("Tact Coa"); // true
        var res22 = IsPalindromeBitVector("Taco Cat"); // true
        var res33 = IsPalindromeBitVector("Tactt"); // false


        Console.ReadLine();
    }

    static bool IsPalindromeBitVector(string input)
    {
        var bitResult = GetBitVector(input.ToLower());
        return CheckAtMostOne(bitResult);
    }

    static bool CheckAtMostOne(int vector)
    {
        return (((vector - 1) & vector) == 0);
    }

    static int GetBitVector(string input)
    {
        var checker = 0;
        foreach (var current in input)
        {
            if (current < 'a' || current > 'z')
            {
                continue;
            }

            var power = current - 'a';
            var shifted = 1 << power;
            checker = checker ^ shifted;
        }

        return checker;
    }

    static bool IsPalindromePermutation(string input)
    {
        var charMap = new Dictionary<char, int>();

        foreach (var currentChar in input.ToLower())
        {
            if (currentChar < 'a' || currentChar > 'z')
            {
                continue;
            }

            if (!charMap.ContainsKey(currentChar))
            {
                charMap.Add(currentChar, 1);
                continue;
            }

            charMap[currentChar]++;
        }

        var oddCount = charMap.Where(x => x.Value % 2 == 1).Count();

        return oddCount <= 2;
    }
}

