using _4.TreesAndGraphs;

namespace _10._10.StreamSearch;
class Program
{
    static void Main(string[] args)
    {
        var tree = new BinaryTree();
        tree.Add(5);
        tree.Add(1);
        tree.Add(4);
        tree.Add(4);
        tree.Add(5);
        tree.Add(9);
        tree.Add(13);
        tree.Add(3);

        var res = tree.GetSmallerThan(1);
        var res2 = tree.GetSmallerThan(3);
        var res3 = tree.GetSmallerThan(4);

        Console.ReadLine();
    }
}

