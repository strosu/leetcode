namespace _3._3.StackOfStacks;
class Program
{
    static void Main(string[] args)
    {
        var set = new SetOfStacks<int>(3);
        Enumerable.Range(1, 20).Select(x =>
        {
            set.Push(x);
            return x;
        }).ToList();

        set.PopAt(1);
        set.PopAt(1);
        set.PopAt(1);

        while (set.TryPeek(out var item))
        {
            Console.Write($"{item} ");
            set.Pop();
        }

        Console.ReadLine();
    }

    public class SetOfStacks<T>
    {
        private readonly int _maxStackSize;
        private Stack<Stack<T>> _stackList = new Stack<Stack<T>>();

        public SetOfStacks(int maxStackSize)
        {
            _maxStackSize = maxStackSize;
        }

        public void Push(T item)
        {
            if (_stackList.TryPeek(out var currrentStack))
            {
                if (currrentStack.Count <= _maxStackSize)
                {
                    currrentStack.Push(item);
                    return;
                }
            }

            var newStack = new Stack<T>();
            newStack.Push(item);
            _stackList.Push(newStack);
        }

        public T Pop()
        {
            if (!_stackList.TryPeek(out var currentStack))
            {
                throw new ArgumentException("empty");
            }

            var item = currentStack.Pop();
            if (currentStack.Count == 0)
            {
                _stackList.Pop();
            }

            return item;
        }

        public bool TryPeek(out T item)
        {
            if (!_stackList.TryPeek(out var lastStack) || !lastStack.TryPeek(out var result))
            {
                item = default(T);
                return false;
            }

            item = result;
            return true;
        }

        public T PopAt(int stackIndex)
        {
            var popped = PopToIndex(stackIndex);
            var targetStack = _stackList.Peek();

            var result = targetStack.Pop();

            if (targetStack.Count == 0)
            {
                _stackList.Pop();
            }

            PushBack(popped);

            return result;
        }

        private void PushBack(Stack<Stack<T>> popped)
        {
            while (popped.TryPop(out var toPush))
            {
                _stackList.Push(toPush);
            }
        }

        private Stack<Stack<T>> PopToIndex(int targetStackIndex)
        {
            if (_stackList.Count < targetStackIndex)
            {
                throw new ArgumentException();
            }

            var popped = new Stack<Stack<T>>();
            while (_stackList.Count > targetStackIndex)
            {
                popped.Push(_stackList.Pop());
            }

            return popped;
        }
    }
}

