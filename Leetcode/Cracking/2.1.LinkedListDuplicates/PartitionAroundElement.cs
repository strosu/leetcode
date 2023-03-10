using System;
namespace _2._1.LinkedListDuplicates
{
    public static class PartitionAroundElement
    {
        public static void Partition(this MyLinkedList<int> list, int pivot)
        {
            var last = list.Last;

            var current = list.Head;
            while (current != null)
            {
                if (current.Item >= pivot)
                {
                    list.Remove(current);
                    list.Add(current.Item);
                }

                if (current == last)
                {
                    break;
                }

                current = current.Next;
            }
        }
    }
}

