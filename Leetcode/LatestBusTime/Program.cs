namespace LatestBusTime;
class Program
{
    static void Main(string[] args)
    {
        var time = new Solution().LatestTimeCatchTheBus(new[] { 10, 20 }, new[] { 2, 17, 18, 19 }, 2);
        var time2 = new Solution().LatestTimeCatchTheBus(new[] { 20, 30, 10 }, new[] { 19, 13, 26, 4, 25, 11, 21 }, 2);
        var time3 = new Solution().LatestTimeCatchTheBus(new[] { 3 }, new[] { 2, 4 }, 2);
        var time4 = new Solution().LatestTimeCatchTheBus(new[] { 3 }, new[] { 4 }, 1);
        var time5 = new Solution().LatestTimeCatchTheBus(new[] { 18, 8, 3, 12, 9, 2, 7, 13, 20, 5 }, new[] { 13, 10, 8, 4, 12, 14, 18, 19, 5, 2, 30, 34 }, 1);
        var time6 = new Solution().LatestTimeCatchTheBus(new[] { 6, 8, 18, 17 }, new[] { 6, 8, 17 }, 1);

        Console.ReadLine();
    }

    public class Solution
    {
        public int LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity)
        {
            var passengerCount = passengers.Count();
            var busCount = buses.Count();

            Array.Sort(buses);
            Array.Sort(passengers);

            //var buses = Enumerable.Order<int>(buses).ToList();
            //var passengers = Enumerable.Order<int>(passengers).ToList();

            //var busTotake = new int[sortedPassengers.Count()];

            var waiting = 0;
            var busIndex = 0;
            var lastOn = -1;
            bool roomOnLastBus = false;

            for (var currentPassenger = 0; currentPassenger < passengerCount && busIndex < busCount;)
            {
                while (currentPassenger < passengerCount && passengers[currentPassenger] <= buses[busIndex])
                {
                    //if (waiting < capacity)
                    //{
                    //    //busTotake[currentPassenger] = busIndex;
                    //    lastOn = currentPassenger;
                    //}

                    waiting++;
                    currentPassenger++;
                }

                busIndex++;

                if (waiting < capacity)
                {
                    lastOn += waiting;
                    roomOnLastBus = true;
                    waiting = 0;
                }
                else
                {
                    lastOn += capacity;
                    roomOnLastBus = false;
                    waiting = waiting - capacity;
                }
            }

            if (lastOn == -1 || busIndex < busCount)
            {
                // Everyone else arrived after the last bus
                return buses.Last();
            }

            // If there's room on the last bus, arrive just as it does (assuming nobody else does)
            // Otherwise, you need to arrive before the last person to get in
            if (roomOnLastBus && passengers[lastOn] < buses.Last())
            {
                return buses.Last();
            }

            // lastOn is the last one to get on a bus; try to get in right before he arrived
            for (var i = lastOn; i > 0; i--)
            {
                if (passengers[i - 1] < passengers[i] - 1)
                {
                    return passengers[i] - 1;
                }
            }

            return passengers[0] - 1;
        }
    }
}

