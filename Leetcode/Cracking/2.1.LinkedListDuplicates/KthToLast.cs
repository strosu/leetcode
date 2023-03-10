using System;
namespace _2._1.LinkedListDuplicates
{
    public class KthToLast
    {
        public static MyLinkedListNode<int> Get(MyLinkedList<int> list, int k)
        {
            var ahead = list.Head;
            var counter = 0;

            for (counter = 0; counter < k && ahead != null; counter++)
            {
                ahead = ahead.Next;
            }

            if (counter < k - 1)
            {
                throw new ArgumentException("Insufficient elements");
            }

            var result = list.Head;
            while (ahead != null)
            {
                ahead = ahead.Next;
                result = result.Next;
            }

            return result;
        }
    }
}

