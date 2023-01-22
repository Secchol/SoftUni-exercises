using System;
using AVLTree;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            var tree = new AVL<int>();
            tree.Insert(2);
            tree.Insert(1);
            Console.WriteLine(tree.Contains(3));


        }
    }
}
