namespace _10._1.MergeBackwards;
class Program
{
    static void Main(string[] args)
    {
        var second = new char[6];
        second[0] = 'b';
        second[1] = 'c';
        second[2] = 'z';

        Merge(new[] { 'a', 'f', 'm' }, second, 3);

        Console.ReadLine();
    }

    static void Merge(char[] first, char[] second, int secondChars)
    {
        var indexFirst = first.Length - 1;
        var indexSecond = secondChars - 1;

        var indexToWrite = second.Length - 1;

        while (indexFirst >= 0 && indexSecond >= 0)
        {
            if (first[indexFirst] < second[indexSecond])
            {
                second[indexToWrite] = second[indexSecond];
                indexSecond--;
            }
            else
            {
                second[indexToWrite] = first[indexFirst];
                indexFirst--;
            }

            indexToWrite--;
        }

        while (indexFirst >= 0)
        {
            second[indexToWrite] = first[indexFirst];
            indexFirst--;
        }

        while (indexSecond >= 0)
        {
            second[indexToWrite] = second[indexSecond];
            indexSecond--;
        }
    }
}

