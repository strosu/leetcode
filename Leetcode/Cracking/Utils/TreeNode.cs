using System;
namespace _4.TreesAndGraphs
{
    public static class GraphModels
    {
        public static Graph<int> GetSomeGraph()
        {
            var first = new GraphNode<int>(10);
            var first1 = new GraphNode<int>(20);
            var first2 = new GraphNode<int>(30);
            var first3 = new GraphNode<int>(40);
            var first4 = new GraphNode<int>(50);
            var first5 = new GraphNode<int>(60);

            first.AddEdge(first1);
            first.AddEdge(first2);
            first.AddEdge(first3);

            first2.AddEdge(first4);
            first3.AddEdge(first5);

            return new Graph<int>
            {
                Nodes = new List<GraphNode<int>> { first, first1, first2, first3, first4, first5 }
            };
        }

        public static Tree<int> GetBalancedTree()
        {
            return new Tree<int>
            {
                Root = new TreeNode<int>
                {
                    Value = 10,
                    Left = new TreeNode<int>
                    {
                        Value = 11,
                        Left = new TreeNode<int>
                        {
                            Value = 123
                        },
                        Right = new TreeNode<int>
                        {
                            Value = 1234
                        }
                    },
                    Right = new TreeNode<int>
                    {
                        Value = 22
                    }
                }
            };
        }

        public static Tree<int> GetUnbalancedTree()
        {
            return new Tree<int>
            {
                Root = new TreeNode<int>
                {
                    Left = new TreeNode<int>
                    {
                        Left = new TreeNode<int>(),
                        Right = new TreeNode<int>()
                    }
                }
            };
        }
    }

    public class GraphNode<T>
    {
        private T _value;
        public List<GraphNode<T>> Children { get; } = new List<GraphNode<T>>();

        public GraphNode(T item)
        {
            _value = item;
        }

        public void AddEdge(GraphNode<T> child)
        {
            Children.Add(child);
        }
    }

    public class Graph<T>
    {
        public List<GraphNode<T>> Nodes { get; set; }
    }


    public class TreeNode<T>
    {
        public T Value { get; set; }

        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }

        public TreeNode<T> Parent { get; set; }
    }

    public class Tree<T>
    {
        public TreeNode<T> Root { get; set; }

        public void Print()
        {
            Print(Root);
        }

        private void Print(object root)
        {
            throw new NotImplementedException();
        }

        private void Print(TreeNode<T> current)
        {
            if (current == null)
            {
                return;
            }

            Print(current.Left);
            Console.Write($"{current.Value} ");
            Print(current.Right);
        }
    }
}

