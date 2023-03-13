using System;
namespace _2._1.LinkedListDuplicates
{
    public static class ListIntersection
    {
        public static bool Intersects(this MyLinkedList<int> list1, MyLinkedList<int> list2)
        {
            var set = new HashSet<MyLinkedListNode<int>>();

            var first = list1.Head;

            while (first != null)
            {
                set.Add(first);
                first = first.Next;
            }

            var second = list2.Head;

            while (second != null && !set.Contains(second))
            {
                second = second.Next;
            }

            return second != null;
        }

        public static bool IntersectsConstantSpace(this MyLinkedList<int> list1, MyLinkedList<int> list2)
        {
            var firstLength = list1.Length;
            var secondLength = list2.Length;

            var firstIndex = list1.Head;
            var secondIndex = list2.Head;

            MoveIndex(ref firstIndex, firstLength - secondLength);
            MoveIndex(ref secondIndex, secondLength - firstLength);

            while (firstIndex != null)
            {
                if (firstIndex == secondIndex)
                {
                    return true;
                }

                firstIndex = firstIndex.Next;
                secondIndex = secondIndex.Next;
            }

            return false;
        }

        public static void MoveIndex(ref MyLinkedListNode<int> current, int positions)
        {
            for (var i = 0; i < positions; i++)
            {
                current = current.Next;
            }
        }
    }
}

