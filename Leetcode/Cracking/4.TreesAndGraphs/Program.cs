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

        var deps = BuildSome().GetOrder();

        //var deconstructed = binary.Root.GetComposingLists();

        CheckSubTree();
        PathsWithSum();

        Console.ReadLine();
    }

    static void PathsWithSum()
    {
        var root = new TreeNode<int>
        {
            Value = 1,
            Left = new TreeNode<int>
            {
                Value = 2,
                Left = new TreeNode<int>
                {
                    Value = 7
                },
                Right = new TreeNode<int>
                {
                    Value = 5,
                    Left = new TreeNode<int>
                    {
                        Value = 8
                    }
                }
            },
            Right = new TreeNode<int>
            {
                Value = 3,
                Left = new TreeNode<int>
                {
                    Value = 5
                }
            }
        };

        var result = root.GetNumberOfPaths(8); // 3
    }

    static void CheckSubTree()
    {
        var large = new TreeNode<int>
        {
            Value = 1,
            Left = new TreeNode<int>
            {
                Value = 3,
                Right = new TreeNode<int>
                {
                    Value = 4
                }
            },
            Right = new TreeNode<int>
            {
                Value = 3,
                Right = new TreeNode<int>
                {
                    Value = 5
                }
            }
        };

        var small = new TreeNode<int>
        {
            Value = 5
        };

        var small2 = new TreeNode<int>
        {
            Value = 3,
            Right = new TreeNode<int>
            {
                Value = 6
            }
        };

        var small3 = new TreeNode<int>
        {
            Value = 3,
            Left = new TreeNode<int>
            {
                Value = 4
            }
        };

        var small4 = new TreeNode<int>
        {
            Value = 1,
            Right = new TreeNode<int>
            {
                Value = 3,
                Right = new TreeNode<int>
                {
                    Value = 5
                }
            }
        };

        var r1 = large.IsSubTree(small); // true
        var r12 = large.IsSubTree(small2); // false
        var r13 = large.IsSubTree(small3); // false
        var r14 = large.IsSubTree(small4); // true
    }

    static Graph<string> BuildSome()
    {
        var result = new Graph<string>();

        var a = new GraphNode<string>("a");
        var b = new GraphNode<string>("b");
        var c = new GraphNode<string>("c");
        var d = new GraphNode<string>("d");
        var e = new GraphNode<string>("e");
        var f = new GraphNode<string>("f");

        result.Nodes.Add(a);
        result.Nodes.Add(b);
        result.Nodes.Add(c);
        result.Nodes.Add(d);
        result.Nodes.Add(e);
        result.Nodes.Add(f);

        a.AddEdge(d);
        f.AddEdge(b);
        b.AddEdge(d);
        f.AddEdge(a);
        d.AddEdge(c);

        return result;
    }
}

