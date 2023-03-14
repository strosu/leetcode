using System;
namespace _4.TreesAndGraphs
{
    public static class BuildBalancedBinary
    {
        public static Tree<int> BuildBalancedBinaryTree(this int[] input)
        {
            var rootNode = BuildRecursively(input, 0, input.Length - 1);
            return new Tree<int>
            {
                Root = rootNode
            };
        }

        private static TreeNode<int> BuildRecursively(int[] input, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            var medianPosition = (start + end) / 2;

            var median = input[medianPosition];
            return new TreeNode<int>
            {
                Value = median,
                Left = BuildRecursively(input, start, medianPosition - 1),
                Right = BuildRecursively(input, medianPosition + 1, end)
            };
        }
    }
}

