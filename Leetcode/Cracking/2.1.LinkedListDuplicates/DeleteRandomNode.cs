using System;
namespace _2._1.LinkedListDuplicates
{
    public class DeleteRandomNode
    {
        public static void DeteleNode(MyLinkedListNode<int> middleNode)
        {
            middleNode.Item = middleNode.Next.Item;
            middleNode.Next = middleNode.Next.Next;
        }
    }
}

