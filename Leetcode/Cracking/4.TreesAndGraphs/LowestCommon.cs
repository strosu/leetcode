using System;
namespace _4.TreesAndGraphs
{
    public static class LowestCommon
    {
        public static TreeNode<int> GetLowestCommonAncestor(this TreeNode<int> first, TreeNode<int> second)
        {
            var set = new HashSet<TreeNode<int>>();

            var current = first;

            while (current != null)
            {
                set.Add(current);
                current = current.Parent;
            }

            while (!set.Contains(second) && second != null)
            {
                second = second.Parent;
            }

            if (second == null)
            {
                throw new ArgumentException("no ancestor");
            }

            return second;
        }

        public static TreeNode<int> GetLowestCommonAncestor2(this TreeNode<int> first, TreeNode<int> second)
        {
            var firstDepth = GetDistanceToRoot(first);
            var secondDepth = GetDistanceToRoot(second);

            var firstIterator = MoveUpToPositon(first, firstDepth - secondDepth);
            var secondIterator = MoveUpToPositon(second, secondDepth - firstDepth);

            while (firstIterator != secondIterator && firstIterator != null)
            {
                firstIterator = firstIterator.Parent;
                secondIterator = secondIterator.Parent;
            }

            if (firstIterator == null)
            {
                throw new ArgumentException("no ancestor");
            }

            return firstIterator;
        }

        private static TreeNode<int> MoveUpToPositon(this TreeNode<int> node, int steps)
        {
            var result = node;

            for (var i = 0; i < steps; i++)
            {
                result = result.Parent;
            }

            return result;
        }

        private static int GetDistanceToRoot(TreeNode<int> node)
        {
            var distance = 0;
            while (node != null)
            {
                distance++;
                node = node.Parent;
            }

            return distance;
        }
    }
}

