using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _2._1.LinkedListDuplicates
{
    public static class LinkedSum
    {
        public static MyLinkedList<int> SumReverse(this MyLinkedList<int> first, MyLinkedList<int> second)
        {
            // Most significant firs

            var result = new MyLinkedList<int>();
            Add(result, first.Head, second.Head, first.Length, second.Length, out var carry);

            if (carry > 0)
            {
                result.Add(carry);
            }

            return result;
        }

        private static void Add(MyLinkedList<int> result, MyLinkedListNode<int> first, MyLinkedListNode<int> second, int firstCount, int secondCount, out int carry)
        {
            if (first == null && second == null)
            {
                carry = 0;
                return;
            }

            if (firstCount > secondCount)
            {
                Add(result, first.Next, second, firstCount - 1, secondCount, out carry);
                var current = first.Item + carry;

                result.AddFirst(current % 10);
                carry = current / 10;

                return;
            }

            if (secondCount > firstCount)
            {
                Add(result, first, second.Next, firstCount, secondCount - 1, out carry);
                var current = second.Item + carry;

                result.AddFirst(current % 10);
                carry = current / 10;

                return;
            }

            Add(result, first.Next, second.Next, firstCount - 1, secondCount - 1, out carry);
            var sum = first.Item + second.Item + carry;
            result.AddFirst(sum % 10);
            carry = sum / 10;
        }

        public static MyLinkedList<int> Sum(this MyLinkedList<int> first, MyLinkedList<int> second)
        {
            // Leasst signficant digit is first
            var carry = 0;

            var result = new MyLinkedList<int>();

            var firstCurrent = first.Head;
            var secondCurrent = second.Head;

            while (firstCurrent != null && secondCurrent != null)
            {
                var sum = firstCurrent.Item + secondCurrent.Item + carry;
                result.Add(sum % 10);

                carry = sum / 10;

                firstCurrent = firstCurrent.Next;
                secondCurrent = secondCurrent.Next;
            }

            Append(firstCurrent, result, carry);
            Append(secondCurrent, result, carry);

            if (carry > 0)
            {
                result.Add(carry);
            }

            return result;
        }

        private static void Append(MyLinkedListNode<int>? current, MyLinkedList<int> result, int carry)
        {
            if (current == null)
            {
                return;
            }

            while (current != null)
            {
                var sum = current.Item + carry;
                result.Add(sum % 10);

                carry = sum / 10;

                current = current.Next;
            }

            result.Add(carry);
        }
    }
}

