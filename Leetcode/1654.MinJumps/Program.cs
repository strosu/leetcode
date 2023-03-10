using System.ComponentModel;

namespace _1654.MinJumps;
class Program
{
    static void Main(string[] args)
    {
        var r11 = new Solution().MinimumJumps3(new[] { 162, 118, 178, 152, 167, 100, 40, 74, 199, 186, 26, 73, 200, 127, 30, 124, 193, 84, 184, 36, 103, 149, 153, 9, 54, 154, 133, 95, 45, 198, 79, 157, 64, 122, 59, 71, 48, 177, 82, 35, 14, 176, 16, 108, 111, 6, 168, 31, 134, 164, 136, 72, 98 },
            29, 98, 80); // 121
        var r1 = new Solution().MinimumJumps3(new[] { 14, 4, 18, 1, 15 }, 3, 15, 9); // 3
        var r2 = new Solution().MinimumJumps3(new[] { 8, 3, 16, 6, 12, 20 }, 15, 13, 11); // -1
        var r3 = new Solution().MinimumJumps3(new[] { 1, 6, 2, 14, 5, 17, 4 }, 16, 9, 7); // 2

        Console.ReadLine();
    }

    public class Solution
    {
        public int MinimumJumps3(int[] forbidden, int a, int b, int x)
        {
            var maxIndex = 4000;
            var visitingQueue = new Queue<VisitNode>();
            visitingQueue.Enqueue(new VisitNode(0, 0, true));

            // Will hold the key
            var visitedWithAllowBack = new Dictionary<int, bool>();
            for (var i = 0; i < forbidden.Length; i++)
            {
                visitedWithAllowBack.Add(forbidden[i], true);
            }

            while (visitingQueue.Any())
            {
                var currentElement = visitingQueue.Dequeue();

                if (currentElement.Position == x)
                {
                    return currentElement.StepsSoFar;
                }

                var visitAhead = true;

                if (!visitedWithAllowBack.ContainsKey(currentElement.Position))
                {
                    // If it's the first time visiting, mark it with the current permissions
                    visitedWithAllowBack.Add(currentElement.Position, currentElement.AllowJumpingBack);
                }
                else
                {
                    if (visitedWithAllowBack[currentElement.Position])
                    {
                        // If we've seen this with max permissions, no need to dig further
                        continue;
                    }

                    // Getting here means we've visited but with reduced permissions
                    if (!currentElement.AllowJumpingBack)
                    {
                        // No permissions now, no need to continue
                        continue;
                    }

                    visitedWithAllowBack[currentElement.Position] = true;
                    visitAhead = false;
                }


                var aheadPos = currentElement.Position + a;
                var behindPos = currentElement.Position - b;

                if (aheadPos <= maxIndex && visitAhead)
                {
                    visitingQueue.Enqueue(new VisitNode(aheadPos, currentElement.StepsSoFar + 1, true));
                }

                if (behindPos >= 0 && currentElement.AllowJumpingBack)
                {
                    visitingQueue.Enqueue(new VisitNode(behindPos, currentElement.StepsSoFar + 1, false));
                }
            }

            return -1;
        }

        public class VisitNode
        {
            public int Position { get; set; }

            public int StepsSoFar { get; set; }

            public bool AllowJumpingBack { get; set; }

            public VisitNode(int position, int stepsSoFar, bool allowBack)
            {
                Position = position;
                StepsSoFar = stepsSoFar;
                AllowJumpingBack = allowBack;
            }
        }
    }
}

