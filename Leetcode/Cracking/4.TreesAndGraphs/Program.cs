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

        var res1 = GraphModels.GetBalancedTree().IsBalanced(); // true
        var res2 = GraphModels.GetUnbalancedTree().IsBalanced(); // false

        var res11 = GraphModels.GetBalancedTree().IsBinarySearchTree(); // false
        var res111 = binary.IsBinarySearchTree(); // true

        var res112 = GraphModels.GetBalancedTree().IsBinarySearchTree2(); // false
        var res1112 = binary.IsBinarySearchTree2(); // true

        var next = binary.Root.Left.GetInOrderSuccessor();
        var next2 = binary.Root.Left.Right.GetInOrderSuccessor();
        var next3 = binary.Root.Right.Right.GetInOrderSuccessor();
        var next4 = binary.Root.Right.Right.Right.GetInOrderSuccessor();
        var next5 = binary.Root.Right.Right.Right.Right.GetInOrderSuccessor();

        Console.ReadLine();
    }
}

