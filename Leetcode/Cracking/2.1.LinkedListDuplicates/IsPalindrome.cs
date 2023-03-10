using System;
namespace _2._1.LinkedListDuplicates
{
    public static class IsPalindromeExtensions
    {
        public static bool IsPalindrome<T>(this MyLinkedList<T> list) where T : IEquatable<T>
        {
            var stack = new Stack<T>();

            var current = list.Head;

            while (current != null)
            {
                stack.Push(current.Item);

                current = current.Next;
            }

            current = list.Head;

            for (var i = 0; i < (list.Length + 1) / 2; i++)
            {
                var prefix = current.Item;
                current = current.Next;

                var suffix = stack.Pop();

                if (!prefix.Equals(suffix))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

