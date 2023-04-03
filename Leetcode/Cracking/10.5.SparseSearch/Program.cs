namespace _10._5.SparseSearch;
class Program
{
    static void Main(string[] args)
    {
        var res = GetPosition(new[] { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "" }, "ball"); // 4

        Console.ReadLine();
    }

    static int GetPosition(string[] words, string target)
    {
        return GetPosition(words, target, 0, words.Length - 1);
    }

    static int GetPosition(string[] words, string target, int startPos, int endPos)
    {
        startPos = IncreaseUpTo(startPos, endPos, words);
        endPos = DecreaseTo(endPos, startPos, words);

        if (startPos == endPos)
        {
            return words[startPos] == target ? startPos : -1;
        }

        if (startPos > endPos)
        {
            return -1;
        }

        var median = (startPos + endPos) / 2;

        if (words[median] == target)
        {
            return median;
        }

        var leftBound = DecreaseTo(median, startPos, words);
        var rightBound = IncreaseUpTo(median, endPos, words);

        if (leftBound >= startPos && words[leftBound].CompareTo(target) >= 0)
        {
            return GetPosition(words, target, startPos, leftBound);
        }

        if (rightBound <= endPos && words[rightBound].CompareTo(target) <= 0)
        {
            return GetPosition(words, target, rightBound, endPos);
        }

        return -1;
    }

    static int DecreaseTo(int startPos, int lowerBound, string[] words)
    {
        while (startPos >= lowerBound && words[startPos] == string.Empty)
        {
            startPos--;
        }

        return startPos;
    }

    static int IncreaseUpTo(int startPos, int upperBound, string[] words)
    {
        while (startPos <= upperBound && words[startPos] == string.Empty)
        {
            startPos++;
        }

        return startPos;
    }
}

