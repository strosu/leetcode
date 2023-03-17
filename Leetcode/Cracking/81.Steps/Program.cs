namespace _81.Steps;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    static int CountSteps(int targetStep)
    {
        var counts = new int[targetStep];
        counts[0] = 1;

        for (var i = 1; i < targetStep; i++)
        {
            counts[i] = counts[i - 1];

            if (i >= 2)
            {
                counts[i] += counts[i - 2];
            }

            if (i >= 3)
            {
                counts[i] += counts[i - 2];
            }
        }

        return counts.Last();
    }

    static int CountStepsRecursively(int currentStep, int targetStep)
    {
        if (currentStep > targetStep)
        {
            return 0;
        }

        if (currentStep == targetStep)
        {
            return 1;
        }

        return CountStepsRecursively(currentStep + 1, targetStep)
            + CountStepsRecursively(currentStep + 2, targetStep)
            + CountStepsRecursively(currentStep + 3, targetStep);
    }
}

