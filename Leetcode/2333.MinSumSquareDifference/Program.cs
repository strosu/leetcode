namespace _2333.MinSumSquareDifference;
class Program
{
    static void Main(string[] args)
    {
        var res1234 = new Solution().MinSumSquareDiff(new[] { 10, 10, 10, 11, 5 }, new[] { 1, 0, 6, 6, 1 }, 11, 27); // 0
        var res123 = new Solution().MinSumSquareDiff(new[] { 1, 4, 10, 12 }, new[] { 5, 8, 6, 9 }, 11, 27); // 0
        var res12 = new Solution().MinSumSquareDiff(new[] { 1, 2, 3, 3, 4 }, new[] { 2, 10, 20, 20, 19 }, 2, 4);
        var res1 = new Solution().MinSumSquareDiff(new[] { 1, 2, 3, 4 }, new[] { 2, 10, 20, 19 }, 0, 0); // 579
        var res2 = new Solution().MinSumSquareDiff(new[] { 1, 4, 10, 12 }, new[] { 5, 8, 6, 9 }, 1, 1); // 43
        var res22 = new Solution().MinSumSquareDiff(new[] { 1, 4, 10, 12 }, new[] { 5, 8, 6, 9 }, 1, 1); // 43

        Console.ReadLine();
    }

    public class Solution
    {
        public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
        {
            var diffs = new long[nums1.Length];

            for (var i = 0; i < nums1.Length; i++)
            {
                diffs[i] = Math.Abs(nums1[i] - nums2[i]);
            }

            Array.Sort(diffs);
            Array.Reverse(diffs);

            // Decrease the diffs by manipulating the 2 arrays
            long toModify = k1 + k2;

            var previousValue = diffs[0];
            var nextIndex = 1;

            while (nextIndex < diffs.Length && toModify > 0)
            {
                if (diffs[nextIndex] == previousValue)
                {
                    nextIndex++;
                    continue;
                }

                var candDecreaseBy = (previousValue - diffs[nextIndex]) * nextIndex;

                if (toModify < candDecreaseBy)
                {
                    break;
                }

                toModify -= candDecreaseBy;
                previousValue = diffs[nextIndex];
                nextIndex++;
            }

            Processs(diffs, toModify, nextIndex, previousValue);

            // Once the diffs array is decreased, just do the sum of squares
            return diffs.Select(x => x * x).Sum();
        }

        private void Processs(long[] diffs, long toModify, int nextIndex, long previousValue)
        {
            var divisor = toModify / nextIndex;
            for (var i = 0; i < nextIndex; i++)
            {
                diffs[i] = Math.Max(previousValue - divisor, 0);
            }

            var modulo = toModify % nextIndex;
            for (var i = 0; i < modulo && diffs[i] > 0; i++)
            {
                diffs[i]--;
            }
        }
    }


}

public class Solution2
{
    public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
    {
        var heap = new Heap(nums1.Length);

        for (var i = 0; i < nums1.Length; i++)
        {
            var diff = Math.Abs(nums1[i] - nums2[i]);

            heap.Add(diff);
        }

        long toModify = k1 + k2;

        while (toModify > 0 && heap.PeekTop() > 0)
        {
            var diff = heap.GetDiffTillNext();

            if (toModify <= diff + 1)
            {
                heap.DecreaseTop((int)toModify);
                return heap.Result;
            }

        }

        return -1;
    }

    public class Heap
    {
        private readonly int _maxSize;
        private int currentSize;
        private readonly int[] _values;

        public long Result => _values.Select(x => x * x).Sum();

        public long GetDiffTillNext()
        {
            if (currentSize == 1)
            {
                return _values[0];
            }

            if (currentSize == 2)
            {
                return _values[0] - _values[1];
            }

            return _values[0] - Math.Max(_values[1], _values[2]);
        }

        public void DecreaseTop(int value)
        {
            if (currentSize == 0)
            {
                throw new ArgumentException();
            }

            // This should be called with values that still match
            _values[0] -= value;
            HeapifyDown(0);
        }

        public Heap(int maxSize)
        {
            _maxSize = maxSize;
            _values = new int[_maxSize];
        }

        public int PeekTop()
        {
            if (currentSize == 0)
            {
                throw new ArgumentException();
            }

            return _values[0];
        }

        public int GetTop()
        {
            if (currentSize == 0)
            {
                throw new ArgumentException();
            }

            var value = _values[0];

            Swap(0, currentSize);
            currentSize--;

            HeapifyDown(0);

            return value;
        }

        public void Add(int value)
        {
            _values[currentSize] = value;
            currentSize++;

            HeapifyUp(currentSize);
        }

        private void HeapifyUp(int currentPosition)
        {
            if (currentPosition == 0)
            {
                return;
            }

            var parentPosition = currentSize / 2;
            if (CanBeParent(_values[currentPosition], _values[parentPosition]))
            {
                return;
            }

            Swap(parentPosition, currentPosition);
            HeapifyUp(parentPosition);
        }

        private void HeapifyDown(int currentPosition)
        {
            var leftChild = currentSize * 2 + 1;
            var rightChild = currentSize * 2 + 2;

            if (leftChild > currentSize)
            {
                return;
            }

            var leftChildValue = _values[leftChild];
            var currentValue = _values[currentPosition];

            if (rightChild > currentSize)
            {
                if (CanBeParent(currentValue, leftChildValue))
                {
                    return;
                }

                Swap(currentPosition, leftChild);
                HeapifyDown(leftChild);
            }
            else
            {
                var rightChildValue = _values[rightChild];

                if (CanBeParent(currentValue, leftChildValue)
                    && CanBeParent(currentValue, rightChildValue))
                {
                    return;
                }

                if (CanBeParent(leftChildValue, rightChildValue))
                {
                    // Left can be a parent of right
                    Swap(currentPosition, leftChild);
                    HeapifyDown(leftChild);
                }
                else
                {
                    Swap(currentPosition, rightChild);
                    HeapifyDown(rightChild);
                }
            }
        }

        private bool CanBeParent(int parent, int child)
        {
            return parent >= child;
        }

        private void Swap(int firstPos, int secondPos)
        {
            var tmp = _values[firstPos];
            _values[firstPos] = _values[secondPos];
            _values[secondPos] = tmp;
        }
    }
}

