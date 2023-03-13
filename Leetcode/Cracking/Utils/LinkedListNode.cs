using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public static class Models
    {
        public static MyLinkedList<int> GetList()
        {
            var list = new MyLinkedList<int>();
            list.Add(0);
            list.Add(1);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(2);
            list.Add(4);
            list.Add(1);
            list.Add(5);
            list.Add(5);

            return list;
        }

        public static MyLinkedList<int> GetList2()
        {
            var list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(10);
            list.Add(5);
            list.Add(8);
            list.Add(5);
            list.Add(3);

            return list;
        }
    }
}

public class MyLinkedListNode<T>
{
    public T Item { get; set; }

    public MyLinkedListNode<T> Next { get; set; }

    public MyLinkedListNode<T> Prev { get; set; }
}

public class MyLinkedList<T>
{
    public string Representation
    {
        get
        {
            var builder = new StringBuilder();
            var current = Head;
            while (current != null)
            {
                builder.Append(current.Item + " ");
                current = current.Next;
            }

            return builder.ToString();
        }
    }

    public MyLinkedListNode<T> Head { get; set; }

    public MyLinkedListNode<T> Last { get; set; }

    public int Length { get; private set; }

    public MyLinkedList()
    {
    }

    public MyLinkedList(T[] values)
    {
        foreach (var value in values)
        {
            Add(value);
        }
    }

    public void Append(MyLinkedList<T> otherList)
    {
        if (Last == null)
        {
            Head = Last = otherList.Head;
            return;
        }

        Last.Next = otherList.Head;

        Length += otherList.Length;
    }

    public void Print()
    {
        var current = Head;
        while (current != null)
        {
            Console.Write($"{current.Item} ");
            current = current.Next;
        }
    }

    public void AddFirst(T item)
    {
        Length++;

        var node = new MyLinkedListNode<T>
        {
            Item = item
        };

        if (Head != null)
        {
            node.Next = Head;
            Head.Prev = node;
            Head = node;
            return;
        }

        Head = Last = node;
    }

    public void Add(T item)
    {
        Length++;

        var node = new MyLinkedListNode<T>
        {
            Item = item
        };

        if (Last != null)
        {
            node.Prev = Last;

            Last.Next = node;

            Last = node;
        }
        else
        {
            Head = Last = node;
        }
    }

    public void Remove(MyLinkedListNode<T> node)
    {
        Length--;

        if (node == Head)
        {
            Head = node.Next;
            return;
        }

        node.Prev.Next = node.Next;

        if (node.Next != null)
        {
            node.Next.Prev = node.Prev;
        }
    }
}

