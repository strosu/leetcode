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
        public T Value { get; set; }
        public List<GraphNode<T>> OutGoing { get; } = new List<GraphNode<T>>();

        public List<GraphNode<T>> Incoming { get; } = new List<GraphNode<T>>();

        public GraphNode(T item)
        {
            Value = item;
        }

        public void AddEdge(GraphNode<T> child)
        {
            OutGoing.Add(child);
            child.Incoming.Add(this);
        }
    }

    public class Graph<T>
    {
        public List<GraphNode<T>> Nodes { get; set; } = new List<GraphNode<T>>();

        public void RemoveEdge(GraphNode<T> from, GraphNode<T> to)
        {
            from.OutGoing.Remove(to);
            to.Incoming.Remove(from);
        }

        public void RemoveNode(GraphNode<T> node)
        {
            Nodes.Remove(node);
            foreach (var to in node.Incoming)
            {
                to.OutGoing.Remove(node);
            }

            foreach (var from in node.OutGoing)
            {
                from.Incoming.Remove(node);
            }
        }
    }


    public class TreeNode<T>
    {
        public T Value { get; set; }

        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }

        public TreeNode<T> Parent { get; set; }

        public int LeftChildren { get; set; }
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

    public class BinaryTree : Tree<int>
    {
        public int GetSmallerThan(int value)
        {
            return GetSmallerThanRecursively(Root, value);
        }

        private int GetSmallerThanRecursively(TreeNode<int> currentNode, int value)
        {
            if (currentNode == null)
            {
                return 0;
            }

            if (currentNode.Value == value)
            {
                return currentNode.LeftChildren;
            }

            if (currentNode.Value > value)
            {
                return GetSmallerThanRecursively(currentNode.Left, value);
            }

            return currentNode.LeftChildren + 1 + GetSmallerThanRecursively(currentNode.Right, value);
        }

        public void Add(int value)
        {
            if (Root == null)
            {
                Root = new TreeNode<int>
                {
                    Value = value
                };

                return;
            }

            AddRecursively(Root, value);
        }

        private void AddRecursively(TreeNode<int> currentNode, int value)
        {
            if (currentNode.Value > value)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = new TreeNode<int>
                    {
                        Value = value,
                        Parent = currentNode
                    };

                    return;
                }

                currentNode.LeftChildren++;
                AddRecursively(currentNode.Left, value);
                return;
            }

            if (currentNode.Right == null)
            {
                currentNode.Right = new TreeNode<int>
                {
                    Value = value,
                    Parent = currentNode
                };

                return;
            }

            AddRecursively(currentNode.Right, value);
        }
    }
}

