namespace NumberOfCombinations;

partial class Program
{
    static void Main(string[] args)
    {
        var x1 = new Solution().NumberOfCombinations("1023"); // 3

        var x2 = new Solution().NumberOfCombinations("9999999999999"); // 101

        //var x1 = new Solution().NumberOfCombinations("181599706296201533688444310698720506149731032417146774186256527047743490211586938068687937416089");
        //var x2 = new Solution().NumberOfCombinations("092");
        //var x3 = new Solution().NumberOfCombinations("0");

        Console.ReadLine();
    }
}
