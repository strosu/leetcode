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

        //var list = Models.GetList2();
        //list.Partition(5);
        //list.Print();

        var list1 = new MyLinkedList<int>(new[] { 7, 1, 6 });
        var list2 = new MyLinkedList<int>(new[] { 5, 9, 2 });

        var result = list1.Sum(list2);
        result.Print(); // 2 1 9

        Console.WriteLine();

        var list11 = new MyLinkedList<int>(new[] { 6, 1, 7 });
        var list22 = new MyLinkedList<int>(new[] { 1, 2, 9, 5 });
        var result2 = list11.SumReverse(list22);
        result2.Print(); // 912

        var pal = new MyLinkedList<int>(new[] { 1, 2, 3, 4, 3, 2, 1 }).IsPalindrome();
        var pal2 = new MyLinkedList<int>(new[] { 1, 2, 3, 4, 4, 3, 2, 1 }).IsPalindrome();
        var pal3 = new MyLinkedList<int>(new[] { 1, 2, 3, 5, 4, 3, 2, 1 }).IsPalindrome();

        var l1 = new MyLinkedList<int>(new int[] { 1, 2, 3 });
        var l2 = new MyLinkedList<int>(new int[] { 4, 5, 6 });
        l1.Append(l2);
        var l3 = new MyLinkedList<int>(new int[] { 11, 22, 33 });
        l3.Append(l2);

        var intersects = l1.Intersects(l2); // true
        var intersects2 = l1.IntersectsConstantSpace(l3); // true

        var ll1 = new MyLinkedList<int>(Enumerable.Range(1, 10).ToArray());

        ll1.Last.Next = ll1.Head.Next.Next.Next.Next;
        var loop = ll1.GetCollision(); // true

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

