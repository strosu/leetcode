using Utils;

namespace _2._1.LinkedListDuplicates;
class Program
{
    static void Main(string[] args)
    {
        //var list = Models.GetList();
        //RemoveDuplicatesNoExtraSpace(list);
        //list.Print();

        //var list = Models.GetList();
        //var result = KthToLast.Get(list, 3).Item; // 1
        //var result2 = KthToLast.Get(list, 5).Item; // 2

        //DeleteRandomNode.DeteleNode(list.Head.Next.Next);
        //list.Print();

        var list = Models.GetList2();
        list.Partition(5);
        list.Print();

        Console.ReadLine();
    }

    static void RemoveDuplicates(MyLinkedList<int> list)
    {
        var set = new HashSet<int>();

        var currentNode = list.Head;
        while (currentNode != null)
        {
            if (set.Contains(currentNode.Item))
            {
                list.Remove(currentNode);
            }
            else
            {
                set.Add(currentNode.Item);
            }

            currentNode = currentNode.Next;
        }
    }

    static void RemoveDuplicatesNoExtraSpace(MyLinkedList<int> list)
    {
        var current = list.Head;

        while (current != null)
        {
            if (ValueShowsUpLater(current))
            {
                list.Remove(current);
            }

            current = current.Next;
        }
    }

    static bool ValueShowsUpLater(MyLinkedListNode<int> current)
    {
        var targetValue = current.Item;
        do
        {
            current = current.Next;
        }
        while (current != null && current.Item != targetValue);

        return current != null;
    }
}

