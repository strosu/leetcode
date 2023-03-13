namespace _3._1.ArrayThreeStacks;
class Program
{
    static void Main(string[] args)
    {
        var res = new TripleStack<int>(10);

        res.First.Push(1);
        res.First.Push(2);
        res.First.Push(3);
        res.First.Push(4);

        res.Second.Push(11);
        res.Second.Push(22);
        res.Second.Push(33);
        res.Second.Push(44);

        res.Third.Push(111);
        res.Third.Push(222);
        res.Third.Push(333);
        res.Third.Push(444);

        var x = res.Second.Pop(); // 44

        Console.ReadLine();
    }

    public class TripleStack<T>
    {
        public class MyStack
        {
            private T[] _backingArray;
            private int _startIndex;
            private int _endIndex;
            private int _itemCount;
            private int _lastItemPosition => _startIndex + _itemCount - 1;

            public MyStack(T[] array, int startIndex, int endIndex)
            {
                _backingArray = array;
                _startIndex = startIndex;
                _endIndex = endIndex;
            }

            public void Push(T item)
            {
                if (_lastItemPosition == _endIndex)
                {
                    throw new ArgumentException("too many elements");
                }

                _itemCount++;
                _backingArray[_lastItemPosition] = item;
            }

            public T Pop()
            {
                if (_itemCount < 0)
                {
                    throw new ArgumentException();
                }

                var item = _backingArray[_lastItemPosition];
                _itemCount--;

                return item;
            }
        }

        private T[] _backingArray;
        private readonly int _maxStackSize;

        public MyStack First { get; private set; }
        public MyStack Second { get; private set; }
        public MyStack Third { get; private set; }

        public TripleStack(int maxStackSize)
        {
            _maxStackSize = maxStackSize;
            _backingArray = new T[maxStackSize * 3];

            First = new MyStack(_backingArray, 0, maxStackSize);
            Second = new MyStack(_backingArray, maxStackSize + 1, 2 * maxStackSize);
            Third = new MyStack(_backingArray, 2 * maxStackSize + 1, 3 * maxStackSize);
        }
    }
}

