namespace _3._2.StackMin;
class Program
{
    static void Main(string[] args)
    {
        var myStack = new StackWithMin();

        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);
        myStack.Push(4);
        myStack.Push(5);

        Console.WriteLine(myStack.GetMin());

        myStack.Push(0);
        Console.WriteLine(myStack.GetMin());

        myStack.Pop();
        Console.WriteLine(myStack.GetMin());

        myStack.Pop();
        myStack.Pop();
        myStack.Pop();
        myStack.Pop();

        Console.WriteLine(myStack.GetMin());

        myStack.Pop();
        Console.WriteLine(myStack.GetMin());

        myStack.Push(0);
    }

    public class StackWithMin
    {
        private Stack<int> _items = new Stack<int>();
        private Stack<int> _mins = new Stack<int>();

        public void Push(int item)
        {
            _items.Push(item);

            if (item <= GetMin())
            {
                _mins.Push(item);
            }
        }

        public int Pop()
        {
            if (!_items.TryPop(out var result))
            {
                throw new ArgumentException();
            }

            if (result == GetMin())
            {
                _mins.Pop();
            }

            return result;
        }

        public int GetMin()
        {
            if (_mins.TryPeek(out var result))
            {
                return result;
            }

            return int.MaxValue;
        }
    }
}

