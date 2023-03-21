namespace _8._5.RecursiveMultiply;

class Program
{
    static void Main(string[] args)
    {
        var result = Multiply(10, 5); // 50
        var result2 = Multiply(12, 12); // 144
        var result3 = Multiply(27, 27); // 729

        var result1 = Multiply2(10, 5); // 50
        var result22 = Multiply2(12, 12); // 144
        var result33 = Multiply2(27, 27); // 729

        Console.ReadLine();
    }

    static long Multiply2(int baseValue, int multiplier)
    {
        return Multiply2Recuse(Math.Min(baseValue, multiplier), Math.Max(baseValue, multiplier));
    }

    static long Multiply2Recuse(int smaller, int larger)
    {
        if (smaller == 0)
        {
            return 0;
        }

        if (smaller == 1)
        {
            return larger;
        }

        var half = Multiply2Recuse(smaller >> 1, larger);

        var result = half << 1;

        if (smaller % 2 == 1)
        {
            return result + larger;
        }

        return result;
    }

    static long Multiply(int baseValue, int multiplier)
    {
        if (multiplier == 0)
        {
            return 0;
        }

        if (multiplier == 1)
        {
            return baseValue;
        }

        var lower = 1;
        var upper = 2;
        var power = 0;

        while (upper <= multiplier)
        {
            lower = lower << 1;
            upper = upper << 1;
            power++;
        }

        var lowerDiff = multiplier - lower;
        var upperDiff = upper - multiplier;

        if (lowerDiff < upperDiff)
        {
            return MultiplyPowerOfTwo(baseValue, power) + Multiply(baseValue, lowerDiff);
        }

        return MultiplyPowerOfTwo(baseValue, power + 1) - Multiply(baseValue, upperDiff);
    }

    static long MultiplyPowerOfTwo(int baseValue, int power)
    {
        var result = baseValue << power;
        return result;
    }
}

