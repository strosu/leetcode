using System;
namespace _4.TreesAndGraphs
{
    public static class SubTrees
    {
        public static bool IsSubTree(this TreeNode<int> first, TreeNode<int> second)
        {
            if (second == null)
            {
                return true;
            }

            if (first == null)
            {
                return false;
            }

            if (first.Value == second.Value)
            {
                if (IsSubTree(first.Left, second.Left) && IsSubTree(first.Right, second.Right))
                {
                    return true;
                }
            }

            return IsSubTree(first.Left, second) || IsSubTree(first.Right, second);
        }
    }
}

