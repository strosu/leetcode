namespace _3._5.SortStack;
class Program
{
    static void Main(string[] args)
    {
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);
        stack.Push(6);
        stack.Push(7);

        var res = SortStack(stack);

        while (res.TryPop(out var item))
        {
            Console.WriteLine($"{item} ");
        }

        Console.ReadLine();
    }

    static Stack<int> SortStack(Stack<int> input)
    {
        var result = new Stack<int>();

        while (input.Count > 0)
        {
            var toInsert = input.Pop();

            var movedCount = MoveUntilInsertable(result, input, toInsert);

            result.Push(toInsert);

            MoveBack(input, result, movedCount);
        }

        return result;
    }

    static void MoveBack(Stack<int> source, Stack<int> dest, int elementCount)
    {
        for (var i = 0; i < elementCount; i++)
        {
            dest.Push(source.Pop());
        }
    }

    static int MoveUntilInsertable(Stack<int> source, Stack<int> dest, int toInsert)
    {
        var result = 0;

        while (dest.Count > 0 && dest.Peek() > toInsert)
        {
            result++;
            source.Push(dest.Pop());
        }

        return result;
    }
}

