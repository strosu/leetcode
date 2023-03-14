using System;
namespace _4.TreesAndGraphs
{
    public static class BuildBalancedBinary
    {
        public static Tree<int> BuildBalancedBinaryTree(this int[] input)
        {
            var rootNode = BuildRecursively(input, 0, input.Length - 1, null);
            return new Tree<int>
            {
                Root = rootNode
            };
        }

        private static TreeNode<int> BuildRecursively(int[] input, int start, int end, TreeNode<int> parent)
        {
            if (start > end)
            {
                return null;
            }

            var medianPosition = (start + end) / 2;

            var median = input[medianPosition];

            var node = new TreeNode<int>
            {
                Value = median,
                Parent = parent
            };

            node.Left = BuildRecursively(input, start, medianPosition - 1, node);
            node.Right = BuildRecursively(input, medianPosition + 1, end, node);

            return node;
        }
    }
}

