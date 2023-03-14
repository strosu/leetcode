using System;
namespace _4.TreesAndGraphs
{
    public static class HasPathExtensions
    {
        public static bool HasPath(this GraphNode<int> from, GraphNode<int> to)
        {
            var visited = new HashSet<GraphNode<int>>();

            var queue = new Queue<GraphNode<int>>();
            queue.Enqueue(from);

            while (queue.Any())
            {
                var current = queue.Dequeue();
                visited.Add(current);

                if (current == to)
                {
                    return true;
                }

                foreach (var child in current.Children)
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                    }
                }
            }

            return false;
        }
    }
}

