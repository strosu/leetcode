
using System;
namespace _4.TreesAndGraphs
{
    public static class CheckBalanced
    {
        public static bool IsBalanced(this Tree<int> tree)
        {
            return IsBalanced(tree.Root, out _);
        }

        private static bool IsBalanced(TreeNode<int> node, out int height)
        {
            if (node == null)
            {
                height = 0;
                return true;
            }

            var leftBalanced = IsBalanced(node.Left, out var leftHeight);

            if (!leftBalanced)
            {
                height = int.MinValue;
                return false;
            }

            var rightBalanced = IsBalanced(node.Right, out var rightHeight);

            if (!rightBalanced)
            {
                height = int.MinValue;
                return false;
            }

            height = Math.Max(leftHeight, rightHeight) + 1;

            return Math.Abs(leftHeight - rightHeight) <= 1;
        }
    }
}

