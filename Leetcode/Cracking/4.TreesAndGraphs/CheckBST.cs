using System;
namespace _4.TreesAndGraphs
{
    public static class CheckBST
    {
        public static bool IsBinarySearchTree2(this Tree<int> root)
        {
            return IsBST(root.Root, int.MinValue, int.MaxValue);
        }

        private static bool IsBST(TreeNode<int> current, int minAllowed, int maxAllowed)
        {
            if (current == null)
            {
                return true;
            }

            if (current.Value < minAllowed || current.Value > maxAllowed)
            {
                return false;
            }

            return IsBST(current.Left, minAllowed, current.Value) && IsBST(current.Right, current.Value, maxAllowed);
        }

        public static bool IsBinarySearchTree(this Tree<int> root)
        {
            return IsBST(root.Root, out _);
        }

        private static bool IsBST(TreeNode<int> current, out MinMax minMax)
        {
            minMax = null;

            if (current == null)
            {
                return true;
            }

            var leftBst = IsBST(current.Left, out var leftMinMax);
            if (!leftBst)
            {
                return false;
            }

            var rightBst = IsBST(current.Right, out var rightMinMax);
            if (!rightBst)
            {
                return false;
            }

            minMax = new MinMax
            {
                Min = leftMinMax != null ? leftMinMax.Min : current.Value,
                Max = rightMinMax != null ? rightMinMax.Max : current.Value
            };

            var result = true;
            if (leftMinMax != null)
            {
                result = result && current.Value > leftMinMax.Max;
            }

            if (rightMinMax != null)
            {
                result = result && current.Value < rightMinMax.Min;
            }

            return result;
        }
    }

    public class MinMax
    {
        public int Min { get; set; }

        public int Max { get; set; }
    }
}

