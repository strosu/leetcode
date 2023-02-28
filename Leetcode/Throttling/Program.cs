namespace Throttling;
class Program
{
    private static int MaxPerSecond = 3;
    private static int MaxPer10Seconds = 20;
    private static int MaxPerMinute = 60;

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var res = CountDroppedRequests(new[] { 1, 1, 1, 1 }); // 1
        var res2 = CountDroppedRequests(new[] { 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7, 7, 11, 11, 11, 11 }); // 7
        var res3 = CountDroppedRequests(new[] { 1, 1, 1, 1, 2, 2, 2, 5, 5, 5, 6, 6, 6, 7, 7, 7, 7, 11, 11, 11, 11, 61, 121, 121 }); // 3

        Console.ReadLine();
    }

    static int CountDroppedRequests(int[] arrivalTimes)
    {
        var dropped = 0;

        for (var i = 0; i < arrivalTimes.Length; i++)
        {
            if (i >= MaxPerSecond && arrivalTimes[i] == arrivalTimes[i - MaxPerSecond])
            {
                dropped++;
                continue;
            }

            if (i >= MaxPer10Seconds && arrivalTimes[i] < arrivalTimes[i - MaxPer10Seconds] + 10)
            {
                dropped++;
                continue;
            }

            if (i >= MaxPerMinute && arrivalTimes[i] < arrivalTimes[i - MaxPerMinute] + 60)
            {
                dropped++;
            }
        }

        return dropped;
    }

    static int CountDroppedRequests3(int[] arrivalTimes)
    {
        var dropped = 0;

        var lastSecond = -1;
        var last10Seconds = 0;
        var lastMinute = 0;

        var currentIndex = 0;
        while (currentIndex < arrivalTimes.Length)
        {
            var currentTime = arrivalTimes[currentIndex];
            while (currentIndex < arrivalTimes.Length - 1 && arrivalTimes[currentIndex] == arrivalTimes[currentIndex + 1])
            {
                currentIndex++;
            }

            var thisSecond = currentIndex - lastSecond;
            var droppedThisSecond = (thisSecond - MaxPerSecond);
            dropped += droppedThisSecond;
            lastSecond = currentIndex;

            last10Seconds = FindFirstGreaterThan(last10Seconds, currentIndex, arrivalTimes[currentIndex] - 10, arrivalTimes);
            var this10SecInterval = currentIndex - last10Seconds + 1;
            var dropped10Seconds = Math.Max(0, this10SecInterval - MaxPer10Seconds);
            dropped += Math.Max(0, dropped10Seconds - droppedThisSecond);

            lastMinute = FindFirstGreaterThan(lastMinute, currentIndex, arrivalTimes[currentIndex] - 60, arrivalTimes);
            var thisMinuteInterval = currentIndex - lastMinute + 1;
            var droppedThisMinute = Math.Max(0, thisMinuteInterval - MaxPerMinute);
            dropped += Math.Max(0, droppedThisMinute - dropped10Seconds - droppedThisSecond);

            currentIndex++;
        }

        return dropped;
    }

    static int FindFirstGreaterThan(int startIndex, int endIndex, int minValue, int[] values)
    {
        if (values[endIndex] <= minValue)
        {
            return endIndex + 1;
        }

        if (values[startIndex] > minValue)
        {
            return startIndex;
        }

        // We're searching within the array
        if (startIndex == endIndex)
        {
            return endIndex;
        }

        var median = (startIndex + endIndex + 1) / 2;
        if (values[median] > minValue)
        {
            return FindFirstGreaterThan(startIndex, median - 1, minValue, values);
        }

        return FindFirstGreaterThan(median, endIndex, minValue, values);
    }


    static int CountDroppedRequestsInitial(int[] arrivalTimes)
    {
        var dropped = 0;

        var lastSecond = -1;
        var last10Seconds = 0;
        var lastMinute = 0;

        var currentIndex = 0;
        while (currentIndex < arrivalTimes.Length)
        {
            var currentTime = arrivalTimes[currentIndex];
            while (currentIndex < arrivalTimes.Length - 1 && arrivalTimes[currentIndex] == arrivalTimes[currentIndex + 1])
            {
                currentIndex++;
            }

            var thisSecond = currentIndex - lastSecond;
            var droppedThisSecond = (thisSecond - MaxPerSecond);
            dropped += droppedThisSecond;
            lastSecond = currentIndex;

            while (arrivalTimes[currentIndex] - arrivalTimes[last10Seconds] >= 10)
            {
                last10Seconds++;
            }

            var this10SecInterval = currentIndex - last10Seconds + 1;
            var dropped10Seconds = Math.Max(0, this10SecInterval - MaxPer10Seconds);
            dropped += Math.Max(0, dropped10Seconds - droppedThisSecond);

            while (arrivalTimes[currentIndex] - arrivalTimes[lastMinute] >= 60)
            {
                lastMinute++;
            }

            var thisMinuteInterval = currentIndex - lastMinute + 1;
            var droppedThisMinute = Math.Max(0, thisMinuteInterval - MaxPerMinute);
            dropped += Math.Max(0, droppedThisMinute - dropped10Seconds - droppedThisSecond);

            currentIndex++;
        }

        return dropped;
    }
}

