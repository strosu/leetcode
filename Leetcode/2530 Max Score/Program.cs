namespace _2530_Max_Score;
class Program
{
    static void Main(string[] args)
    {
        var res = new Solution().MaxKelements(new[] { 10, 10, 10, 10, 10 }, 5); // 50
        var res2 = new Solution().MaxKelements(new[] { 1, 10, 3, 3, 3 }, 3); // 17
        var res3 = new Solution().MaxKelements(new[] { 672579538, 806947365, 854095676, 815137524 }, 3); // 2476180565

        var res4 = new Solution().MaxKelements(new[] { 917628420, 483728758, 673264035, 83895989, 440720108, 302865322, 554670352, 720693782, 251711673, 62636995, 694490734, 636659578, 315533758, 664102187, 248346623, 643449760, 216066951, 627830153, 797367918, 241070111, 945595415, 182424468, 426755126, 724504248, 492692625, 702198276, 680118854, 983787198, 530547268, 746563389, 850224474, 205025816, 43406647, 310884023, 620586148, 867334412, 702157518, 402339577, 832288317, 700062237, 116946942, 233442821, 735199053, 141779262, 989691336, 40255223, 751306711, 446303334, 234514432, 371061905 }, 71);
        // 31692814010

        Console.ReadLine();
    }

    public class Solution
    {
        public long MaxKelements(int[] nums, int k)
        {
            var heap = new Heap(nums.Length);
            foreach (var element in nums)
            {
                heap.Add(element);
            }

            long sum = 0;

            for (var i = 0; i < k; i++)
            {
                var top = heap.GetTop();
                sum += top;

                int third = (int)Math.Ceiling((double)top / 3);
                heap.Add(third);
            }

            return sum;
        }

        public class Heap
        {
            private int[] itemList;
            private int lastPosition;

            public Heap(int maxSize)
            {
                itemList = new int[maxSize];
                lastPosition = -1;
            }

            public int Peek()
            {
                if (lastPosition == 0)
                {
                    throw new ArgumentException();
                }

                return itemList[0];
            }

            public int GetTop()
            {
                var tmp = itemList[0];
                itemList[0] = itemList[lastPosition];

                lastPosition--;
                HeapifyDown(0);

                return tmp;
            }

            public void Add(int element)
            {
                lastPosition++;
                itemList[lastPosition] = element;

                HeapifyUp(lastPosition);
            }

            private void HeapifyDown(int position)
            {
                var left = position * 2 + 1;
                var right = position * 2 + 2;

                // Either not enough nodes, or it's in the right place already
                if (left > lastPosition || ShouldBeHigher(itemList[position], itemList[left]))
                {
                    return;
                }

                if (right > lastPosition)
                {
                    var temp = itemList[position];
                    itemList[position] = itemList[left];
                    itemList[left] = temp;
                    HeapifyDown(left);
                    return;
                }

                if (ShouldBeHigher(itemList[left], itemList[right]))
                {
                    var temp = itemList[position];
                    itemList[position] = itemList[left];
                    itemList[left] = temp;
                    HeapifyDown(left);
                }
                else
                {
                    var temp = itemList[position];
                    itemList[position] = itemList[right];
                    itemList[right] = temp;
                    HeapifyDown(right);
                }
            }

            private void HeapifyUp(int position)
            {
                if (position == 0)
                {
                    return;
                }

                var parent = position / 2;

                if (ShouldBeHigher(itemList[parent], itemList[position]))
                {
                    return;
                }

                var temp = itemList[position];
                itemList[position] = itemList[parent];
                itemList[parent] = temp;
                HeapifyUp(parent);
            }

            private bool ShouldBeHigher(int first, int second)
            {
                return first > second;
            }
        }
    }
}

