namespace _1._3Urlify;
class Program
{
    static void Main(string[] args)
    {
        var res = ReplaceSpaces("Mr John Smith    ".ToCharArray(), 13);
        var res2 = ReplaceSpaces("Mr A   John Smith          ".ToCharArray(), 17);

        Console.ReadLine();
    }

    static string ReplaceSpaces(char[] input, int textLength)
    {
        var positionsToMove = new int[textLength]; // Will store how many positions to the right each initial character needs to shift
        var currentSpaceCount = 0;

        for (var i = 0; i < textLength; i++)
        {
            positionsToMove[i] = currentSpaceCount * 2;

            if (input[i] == ' ')
            {
                currentSpaceCount++;
            }
        }

        for (var i = textLength - 1; i >= 0; i--)
        {
            var newPosition = i + positionsToMove[i];

            if (input[i] != ' ')
            {
                input[newPosition] = input[i];
                continue;
            }

            input[newPosition] = '%';
            input[newPosition + 1] = '2';
            input[newPosition + 2] = '0';
        }

        return new string(input);
    }
}

