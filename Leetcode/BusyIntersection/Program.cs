
namespace BusyIntersection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = GetResult(new[] { 0, 0, 1, 4 }, new[] { 0, 1, 1, 0 });
        }

        static int[] GetResult(int[] carArrivalTime, int[] direction)
        {
            var n = carArrivalTime.Length;
            var result = new int[n];

            var index = 0;
            var currentTime = carArrivalTime[0];
            var lastPassTime = currentTime - 2;
            var lastPassDirection = 0;

            var mainAvenueQueue = new Queue<int>();
            var firstAvenueQueue = new Queue<int>();

            while (index < n || mainAvenueQueue.Any() || firstAvenueQueue.Any())
            {
                // Enqueue all cars arriving during the current time event
                while (index < n && carArrivalTime[index] == currentTime)
                {
                    if (direction[index] == 0)
                    {
                        mainAvenueQueue.Enqueue(index);
                    }
                    else
                    {
                        firstAvenueQueue.Enqueue(index);
                    }

                    index++;
                }

                lastPassDirection = ProcessNextCar(mainAvenueQueue, firstAvenueQueue, result, currentTime, lastPassTime, lastPassDirection);

                lastPassTime = currentTime;

                if (mainAvenueQueue.Any() || firstAvenueQueue.Any())
                {
                    // If any cars are queued, the next second also needs to be used for cars to pass
                    currentTime++;
                    continue;
                }

                if (index == n)
                {
                    break; // We're done
                }

                // The next processing time should be whenever the next car arrives at the intersection
                currentTime = carArrivalTime[index];
            }

            return result;
        }

        private static int ProcessNextCar(Queue<int> mainAvenueQueue, Queue<int> firstAvenueQueue, int[] result, int currentTime, int lastPassTime, int lastPassDirection)
        {
            if (currentTime == lastPassTime + 1)
            {
                // We had a car pass a second ago, keeping the same direction has priority
                if (lastPassDirection == 0)
                {
                    return TakeMainFirst(mainAvenueQueue, firstAvenueQueue, result, currentTime);
                }
                else
                {
                    return TakeFirstFirst(mainAvenueQueue, firstAvenueQueue, result, currentTime);
                }
            }
            else
            {
                return TakeFirstFirst(mainAvenueQueue, firstAvenueQueue, result, currentTime);
            }
        }

        private static int TakeMainFirst(Queue<int> mainAvenueQueue, Queue<int> firstAvenueQueue, int[] result, int currentTime)
        {
            // Try to take from Main
            if (TryTakeFromQueue(mainAvenueQueue, result, currentTime))
            {
                return 0;
            }

            // Otherwise, take the first car on First
            TryTakeFromQueue(firstAvenueQueue, result, currentTime);
            return 1;
        }

        private static int TakeFirstFirst(Queue<int> mainAvenueQueue, Queue<int> firstAvenueQueue, int[] result, int currentTime)
        {
            // Try to take from First
            if (TryTakeFromQueue(firstAvenueQueue, result, currentTime))
            {
                return 1;
            }

            // Otherwise, take the first car on First
            TryTakeFromQueue(mainAvenueQueue, result, currentTime);
            return 0;
        }

        private static bool TryTakeFromQueue(Queue<int> queue, int[] result, int currentTime)
        {
            if (queue.TryDequeue(out var nextCarId))
            {
                ProcessPassingCar(nextCarId, result, currentTime);
                return true;
            }

            return false;
        }

        static void ProcessPassingCar(int index, int[] result, int currentTime)
        {
            result[index] = currentTime;
        }
    }
}