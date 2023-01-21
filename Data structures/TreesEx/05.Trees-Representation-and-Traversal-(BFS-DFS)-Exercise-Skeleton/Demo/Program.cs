namespace Demo
{
    using System;
    using System.Linq;
    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            IntegerTreeFactory factory = new IntegerTreeFactory();
            var tree = factory.CreateTreeFromStrings(new string[] { "9 17", "9 4", "9 14", "4 36", "14 53", "14 59", "53 67", "53 73","17 96" });
            Console.WriteLine(String.Join(Environment.NewLine, tree.GetPathsWithGivenSum(26).Select(x => string.Join(", ", x))));
        }
    }
}
