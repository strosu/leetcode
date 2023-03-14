namespace _4.TreesAndGraphs;
class Program
{
    static void Main(string[] args)
    {
        var graph = GraphModels.GetSomeGraph();
        var result = graph.Nodes.First().HasPath(graph.Nodes.Last());

        var binary = Enumerable.Range(1, 20).ToArray().BuildBalancedBinaryTree();

        binary.Print();

        Console.WriteLine();

        var lists = binary.GetLists();
        lists.Print();

        Console.ReadLine();
    }
}

