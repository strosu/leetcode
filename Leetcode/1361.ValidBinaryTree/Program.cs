namespace _1361.ValidBinaryTree;
class Program
{
    static void Main(string[] args)
    {
        var r112 = new Solution().ValidateBinaryTreeNodes(4, new[] { 1, -1, 3, -1 }, new[] { 2, -1, -1, -1 }); // true
        var r11 = new Solution().ValidateBinaryTreeNodes(4, new[] { 1, 0, 3, -1 }, new[] { -1, -1, -1, -1 }); // false
        var r1 = new Solution().ValidateBinaryTreeNodes(4, new[] { 1, -1, 3, -1 }, new[] { 2, -1, -1, -1 }); // true
        var r2 = new Solution().ValidateBinaryTreeNodes(4, new[] { 1, -1, 3, -1 }, new[] { 2, 3, -1, -1 }); // false
        var r3 = new Solution().ValidateBinaryTreeNodes(2, new[] { 1, 0 }, new[] { 0, 1 }); // false

        Console.ReadLine();
    }

    public class Solution
    {
        public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
        {
            var areLeftChildren = new HashSet<int>(leftChild);
            var areRightChildren = new HashSet<int>(rightChild);

            var roots = new List<int>();

            for (var i = 0; i < n; i++)
            {
                if (!leftChild.Contains(i) && !areRightChildren.Contains(i))
                {
                    roots.Add(i);
                }
            }

            if (roots.Count() != 1)
            {
                return false;
            }

            var visited = new HashSet<int>();
            var nodeQueue = new Queue<int>();
            nodeQueue.Enqueue(roots[0]);

            while (nodeQueue.Any())
            {
                var currentNode = nodeQueue.Dequeue();

                if (visited.Contains(currentNode))
                {
                    return false;
                }

                visited.Add(currentNode);

                var left = leftChild[currentNode];
                var right = rightChild[currentNode];

                AddIfValid(nodeQueue, left);
                AddIfValid(nodeQueue, right);
            }

            return visited.Count == n;
        }

        private void AddIfValid(Queue<int> queue, int current)
        {
            if (current >= 0)
            {
                queue.Enqueue(current);
            }
        }

    }
}

