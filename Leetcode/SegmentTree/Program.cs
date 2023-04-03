namespace SegmentTree;
class Program
{
    static void Main(string[] args)
    {

        //["NumArray","update","update","update","sumRange","update","sumRange","update","sumRange","sumRange","update"]
        //[[[7,2,7,2,0]],[4,6],[0,2],[0,9],[4,4],[3,8],[0,4],[4,1],[0,3],[0,4],[0,4]]

        var tree = new NumArray(new[] { 7, 2, 7, 2, 0 });
        tree.Update(4, 6);
        tree.Update(0, 2);
        tree.Update(0, 9);

        var s = tree.SumRange(4, 4);
        tree.Update(3, 8);
        var s2 = tree.SumRange(0, 4);

        tree.Update(4, 1);

        var s3 = tree.SumRange(0, 3);
        var s4 = tree.SumRange(0, 4);

        tree.Update(0, 4);

        Console.ReadLine();
    }

    public class NumArray
    {
        private readonly int[] _values;
        private readonly SegmentNode[] _sums;

        public NumArray(int[] nums)
        {
            _values = nums.ToArray();
            _sums = new SegmentNode[2 * _values.Length];
            Construct(0, _values.Length - 1, 0);
        }

        private int GetSumRecursively(int start, int end, int currentPosition)
        {
            var currentNode = _sums[currentPosition];

            if (currentNode.Start >= start && currentNode.End <= end)
            {
                return currentNode.Sum;
            }

            if (currentNode.End < start || currentNode.Start > end)
            {
                return 0;
            }

            return GetSumRecursively(start, end, GetLeft(currentPosition)) +
                GetSumRecursively(start, end, GetRight(currentPosition));
        }

        public void Update(int index, int val)
        {
            UpdateRecursively(index, val - _values[index], 0);
            _values[index] = val;
        }

        private void UpdateRecursively(int index, int delta, int currentPosition)
        {
            var currentNode = _sums[currentPosition];
            currentNode.Sum += delta;

            if (currentNode.Start == currentNode.End && currentNode.Start == index)
            {
                return;
            }

            var leftPos = GetLeft(currentPosition);
            var left = _sums[leftPos];
            if (left.End >= index)
            {
                UpdateRecursively(index, delta, leftPos);
            }
            else
            {
                UpdateRecursively(index, delta, GetRight(currentPosition));
            }
        }

        public int SumRange(int left, int right)
        {
            return GetSumRecursively(left, right, 0);
        }

        private class SegmentNode
        {
            public int Start { get; set; }

            public int End { get; set; }

            public int Sum { get; set; }
        }

        private int GetParentPosition(int current) => (current - 1) / 2;
        private int GetLeft(int current) => 2 * current + 1;
        private int GetRight(int current) => 2 * current + 2;

        private void Construct(int left, int right, int currentPosition)
        {
            if (left == right)
            {
                _sums[currentPosition] = new SegmentNode
                {
                    Start = left,
                    End = left,
                    Sum = _values[left]
                };
                return;
            }

            var median = (left + right) / 2;
            var leftChild = GetLeft(currentPosition);
            var rightChild = GetRight(currentPosition);

            Construct(left, median, leftChild);
            Construct(median + 1, right, rightChild);

            _sums[currentPosition] = new SegmentNode
            {
                Start = left,
                End = right,
                Sum = _sums[leftChild].Sum + _sums[rightChild].Sum
            };
        }
    }
}

