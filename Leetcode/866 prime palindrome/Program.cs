namespace _866_prime_palindrome;
class Program
{
    static void Main(string[] args)
    {
        var r154 = new Solution().PrimePalindrome(9989900); // 11
        var r15 = new Solution().PrimePalindrome(10); // 11
        var r1 = new Solution().PrimePalindrome(6); // 7
        var r12 = new Solution().PrimePalindrome(8); // 11
        var r13 = new Solution().PrimePalindrome(13); // 101

        Console.ReadLine();
    }

    public class Solution
    {
        private char[] BadFirstDigits = new[] { '2', '4', '5', '6', '8' };

        public int PrimePalindrome(int n)
        {
            for (var i = n; i < int.MaxValue; i++)
            {
                if (DigitsOk(i) && IsPlaindrome(i) && IsPrime(i))
                {
                    return i;
                }
            }

            return -1;
        }

        private bool DigitsOk(int n)
        {
            if (n < 10)
            {
                return true;
            }

            var stringNum = n.ToString();

            if (BadFirstDigits.Contains(stringNum[0]))
            {
                return false;
            }

            if (stringNum.Last() == '0')
            {
                return false;
            }

            var sumDigit = stringNum.ToCharArray().Select(x => x - '0').Sum();

            if (sumDigit % 3 == 0)
            {
                return false;
            }

            return true;
        }

        private bool IsPlaindrome(int n)
        {
            var stringNum = n.ToString();
            for (var i = 0; i <= stringNum.Length / 2; i++)
            {
                if (stringNum[i] != stringNum[stringNum.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsPrime(int n)
        {
            if (n < 2)
            {
                return false;
            }

            for (var i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

