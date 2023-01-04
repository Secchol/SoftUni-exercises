using System;
using _02.BinarySearchTree;
using _03.MinHeap;
using _04.CookiesProblem;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree<int>();
            tree.Insert(10);
            tree.Insert(15);
            tree.Insert(11);
            tree.Insert(20);
            tree.DeleteMin();

        }
    }
}
