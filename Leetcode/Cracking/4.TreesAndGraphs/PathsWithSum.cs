using System;
using System.Data;

namespace _4.TreesAndGraphs
{
    public static class PathsWithSum
    {
        public static int GetNumberOfPaths(this TreeNode<int> root, int targetSum)
        {
            return GetRecursively(root, new Dictionary<int, int>(), targetSum, 0);
        }

        private static int GetRecursively(TreeNode<int> current, Dictionary<int, int> pathsToRoot, int targetSum, int currentSum)
        {
            if (current == null)
            {
                return 0;
            }

            var result = 0;

            currentSum += current.Value;
            var toLook = currentSum - targetSum;

            if (pathsToRoot.ContainsKey(toLook))
            {
                result += pathsToRoot[toLook];
            }

            if (current.Value == targetSum)
            {
                result++;
            }

            Increment(pathsToRoot, currentSum, 1);
            result += GetRecursively(current.Left, pathsToRoot, targetSum, currentSum);
            result += GetRecursively(current.Right, pathsToRoot, targetSum, currentSum);
            Increment(pathsToRoot, currentSum, -1);

            return result;
        }

        private static void Increment(Dictionary<int, int> map, int key, int delta)
        {
            if (!map.ContainsKey(key))
            {
                map.Add(key, delta);
                return;
            }

            var newValue = map[key] + delta;
            if (newValue == 0)
            {
                map.Remove(key);
                return;
            }

            map[key] = newValue;
        }

        public static int GetNumberOfPaths2(this TreeNode<int> root, int targetSum)
        {
            return GetRecursively2(root, new List<int>(), targetSum);
        }

        private static int GetRecursively2(TreeNode<int> current, List<int> pathsToHere, int targetSum)
        {
            if (current == null)
            {
                return 0;
            }

            var result = 0;

            var newPathList = pathsToHere.Select(x => x + current.Value).ToList();
            newPathList.Add(current.Value);

            result += newPathList.Count(x => x == targetSum);

            result += GetRecursively2(current.Left, newPathList, targetSum);
            result += GetRecursively2(current.Right, newPathList, targetSum);

            return result;
        }
    }
}

