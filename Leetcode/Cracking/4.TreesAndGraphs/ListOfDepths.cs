using System;
using System.Net.WebSockets;

namespace _4.TreesAndGraphs
{
    public static class ListOfDepths
    {
        public static List<List<int>> GetLists(this Tree<int> tree)
        {
            var result = new List<List<int>>();

            var currentQueue = new Queue<TreeNode<int>>();
            var nextLevelQueue = new Queue<TreeNode<int>>();

            currentQueue.Enqueue(tree.Root);

            var currentList = new List<int>();

            while (currentQueue.Any())
            {
                var current = currentQueue.Dequeue();
                currentList.Add(current.Value);

                if (current.Left != null)
                {
                    nextLevelQueue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    nextLevelQueue.Enqueue(current.Right);
                }

                if (!currentQueue.Any())
                {
                    result.Add(currentList);
                    currentQueue = nextLevelQueue;

                    nextLevelQueue = new Queue<TreeNode<int>>();
                    currentList = new List<int>();
                }
            }

            return result;
        }

        public static void Print(this List<List<int>> lists)
        {
            foreach (var list in lists)
            {
                foreach (var element in list)
                {
                    Console.Write($"{element} ");
                }

                Console.WriteLine();
            }
        }
    }
}

