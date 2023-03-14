using System;
namespace _4.TreesAndGraphs
{
    public static class GetSuccessor
    {
        public static TreeNode<T> GetInOrderSuccessor<T>(this TreeNode<T> current)
        {
            if (current.Right != null)
            {
                current = current.Right;

                while (current.Left != null)
                {
                    current = current.Left;
                }

                return current;
            }

            while (current != null)
            {
                var parent = current.Parent;

                if (parent == null)
                {
                    return null;
                }

                if (current == parent.Left)
                {
                    return parent;
                }

                current = parent;
            }

            return null;
        }
    }
}

