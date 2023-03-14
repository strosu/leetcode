namespace _3._4.QueueViaStacks;
class Program
{
    static void Main(string[] args)
    {
        var queue = new MyQueue<int>();
        Enumerable.Range(1, 20).ToList().ForEach(x => queue.Enqueue(x));

        while (queue.TryPeek(out _))
        {
            Console.Write($"{queue.Dequeue()} ");
        }

        Console.ReadLine();
    }

    public class MyQueue<T>
    {
        private int currentStackId = 0;
        private Stack<T>[] stacks = new Stack<T>[2];

        private Stack<T> CurrentStack => stacks[currentStackId];
        private Stack<T> EmptyStack => stacks[(currentStackId + 1) % 2];

        private bool _reverted = false;

        public MyQueue()
        {
            stacks[0] = new Stack<T>();
            stacks[1] = new Stack<T>();
        }

        public bool TryPeek(out T item)
        {
            return CurrentStack.TryPeek(out item);
        }

        public void Enqueue(T item)
        {
            if (_reverted)
            {
                Spill();
            }

            CurrentStack.Push(item);
        }

        public T Dequeue()
        {
            if (!_reverted)
            {
                Spill();
            }

            return CurrentStack.Pop();
        }

        private void Spill()
        {
            while (CurrentStack.TryPop(out var lastItem))
            {
                EmptyStack.Push(lastItem);
            }

            currentStackId++;
            _reverted = !_reverted;
        }
    }
}

