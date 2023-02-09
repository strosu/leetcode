using System.Numerics;

namespace NumberOfCombinations;

partial class Program
{
    public class Solution2
    {
        private BigInteger _foundSoFar;

        public int NumberOfCombinations(string num)
        {
            if (num.StartsWith('0'))
            {
                return 0;
            }

            GetRecursive(0, 0, 0, num);

            BigInteger modulo = (BigInteger)(Math.Pow(10, 9) + 7);
            return (int)(_foundSoFar % modulo);
        }

        public void GetRecursive(BigInteger lastNumber, int lastNumberDigitCount, int currentIndex, string num)
        {
            if (currentIndex == num.Length)
            {
                _foundSoFar++;
                return;
            }

            if (lastNumberDigitCount > num.Length - currentIndex)
            {
                // The last number is too large to have another one after it
                //return;
            }

            var candidateDigit = num[currentIndex];

            if (candidateDigit == '0')
            {
                // The only thing we can do with a 0 is add it to the previous number
                //GetRecursive(lastNumber * 10, currentIndex + 1, num);
                return;
            }

            var nextCandidates = BuildNext(lastNumber, currentIndex, num);
            foreach (var (nextNum, digitCount, index) in nextCandidates)
            {
                GetRecursive(nextNum, digitCount, index, num);
            }
        }

        private IList<(BigInteger, int, int)> BuildNext(BigInteger lastNumber, int currentIndex, string num)
        {
            var result = new List<(BigInteger, int, int)>();
            BigInteger candidate = 0;

            var nextIndex = currentIndex;
            var digitCount = 0;

            do
            {
                candidate = candidate * 10 + (num[nextIndex] - '0');
                nextIndex++;
                digitCount++;
            }
            while (candidate < lastNumber && nextIndex < num.Length);

            if (candidate >= lastNumber)
            {
                result.Add((candidate, digitCount, nextIndex));
            }

            for (var i = nextIndex; i < num.Length; i++)
            {
                candidate = candidate * 10 + (num[nextIndex] - '0');
                nextIndex++;
                digitCount++;
                result.Add((candidate, digitCount, nextIndex));
            }

            return result;
        }
    }
}
