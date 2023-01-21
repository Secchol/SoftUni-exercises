using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using _01.BinaryTree;
using _02.BinarySearchTree;
using _03.MaxHeap;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(5);
            bst.Insert(4);
            bst.Insert(20);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(19);
            bst.Insert(22);
            bst.Search(23123123);

        }
    }
}