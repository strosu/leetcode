using System;
namespace _2._1.LinkedListDuplicates
{
    public static class LoopDetection
    {
        public static MyLinkedListNode<int> GetCollision(this MyLinkedList<int> list)
        {
            var first = list.Head;
            var second = first;

            while (first != null && second != null)
            {
                first = first.Next;
                second = second.Next.Next;

                if (first == second)
                {
                    first = list.Head;
                    while (first != second)
                    {
                        first = first.Next;
                        second = second.Next;
                    }

                    return first;
                }
            }

            return null;
        }
    }
}

