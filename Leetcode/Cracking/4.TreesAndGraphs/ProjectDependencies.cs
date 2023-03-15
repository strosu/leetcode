using System;
namespace _4.TreesAndGraphs
{
    public static class ProjectDependencies
    {
        public static List<string> GetOrder(this Graph<string> graph)
        {
            var result = new List<GraphNode<string>>();

            while (graph.Nodes.Any())
            {
                var candidates = graph.Nodes.Where(x => x.Incoming.Count == 0).ToList();

                if (!candidates.Any())
                {
                    throw new ArgumentException("cannot");
                }

                result.AddRange(candidates);
                foreach (var candidate in candidates)
                {
                    graph.RemoveNode(candidate);
                }
            }

            return result.Select(x => x.Value).ToList();
        }
    }
}

