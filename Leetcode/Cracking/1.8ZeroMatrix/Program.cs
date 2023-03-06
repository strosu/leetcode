namespace _1._8ZeroMatrix;
class Program
{
    static void Main(string[] args)
    {
        var matrix = new int[5][];
        matrix[0] = new int[] { 1, 2, 3, 4, 5 };
        matrix[1] = new int[] { 6, 7, 8, 9, 10 };
        matrix[2] = new int[] { 11, 0, 13, 14, 15 };
        matrix[3] = new int[] { 16, 17, 18, 19, 20 };
        matrix[4] = new int[] { 21, 22, 23, 24, 0 };

        MakeZeros(matrix);

        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                Console.Write($"{matrix[i][j]} ");
            }

            Console.WriteLine();
        }

        Console.ReadLine();
    }

    static void MakeZeros(int[][] matrix)
    {
        var rowsToMakeZero = new HashSet<int>();
        var colsToMakeZero = new HashSet<int>();

        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 0)
                {
                    rowsToMakeZero.Add(i);
                    colsToMakeZero.Add(j);
                }
            }
        }

        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                if (rowsToMakeZero.Contains(i) || colsToMakeZero.Contains(j))
                {
                    matrix[i][j] = 0;
                }
            }
        }
    }
}

