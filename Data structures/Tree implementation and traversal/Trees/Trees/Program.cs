using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace Trees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>(7,
                new Tree<int>(19, new Tree<int>(1), new Tree<int>(12), new Tree<int>(31)),
                new Tree<int>(21),
                new Tree<int>(14, new Tree<int>(23), new Tree<int>(6)));
            //BFS
            BFS(tree);
            Console.WriteLine();
            Swap(tree, 19, 14);
            BFS(tree);
            Console.WriteLine();


            Console.WriteLine("---------------------------------");
            //DFS
            DFSWithStack(tree);
            //Add by given value


        }

        private static void Swap(Tree<int> tree, int v1, int v2)
        {
            if (v1 == tree.Value || v2 == tree.Value)
            {
                throw new ArgumentException();

            }
            Queue<Tree<int>> nums = new Queue<Tree<int>>();
            Tree<int> firstNode = null;
            Tree<int> secondNode = null;
            nums.Enqueue(tree);
            while (nums.Count != 0)
            {
                Tree<int> currentEl = nums.Dequeue();
                foreach (var child in currentEl.Children)
                {
                    if (child.Value == v1)
                    {
                        firstNode = child;
                    }
                    else if (child.Value == v2)
                    {
                        secondNode = child;

                    }
                    nums.Enqueue(child);

                }
            }

            if (firstNode == null || secondNode == null)
            {
                throw new ArgumentNullException();


            }
            var firstParent = firstNode.Parent;
            var secondParent = secondNode.Parent;
            int firstIndex = firstParent.Children.IndexOf(firstNode);
            int secondIndex = secondParent.Children.IndexOf(secondNode);

            if (firstParent == null || secondParent == null)
            {
                throw new ArgumentException();

            }

            firstParent.Children[firstIndex] = secondNode;
            secondNode.Parent = firstParent;
            secondParent.Children[secondIndex] = firstNode;
            firstNode.Parent = secondParent;




        }

        private static void Remove(Tree<int> tree, int value)
        {
            if (tree.Value == value)
            {
                throw new ArgumentException();

            }
            Queue<Tree<int>> nums = new Queue<Tree<int>>();
            nums.Enqueue(tree);
            bool found = false;
            while (nums.Count != 0)
            {
                Tree<int> currentEl = nums.Dequeue();

                foreach (var child in currentEl.Children)
                {
                    if (child.Value != value)
                    {
                        nums.Enqueue(child);
                    }
                    else
                    {
                        found = true;
                    }
                }
                if (found)
                {
                    currentEl.Children.RemoveAll(x => x.Value == value);

                }
            }
            if (!found)
            {
                throw new ArgumentNullException();

            }
        }

        private static void Add(Tree<int> tree, int value)
        {
            Queue<Tree<int>> nums = new Queue<Tree<int>>();
            nums.Enqueue(tree);
            bool found = false;
            while (nums.Count != 0)
            {
                Tree<int> currentEl = nums.Dequeue();
                if (currentEl.Value == value)
                {
                    found = true;
                    currentEl.Children.Add(new Tree<int>(10));
                }
                foreach (var child in currentEl.Children)
                {
                    nums.Enqueue(child);

                }

            }
            if (!found)
            {
                throw new ArgumentNullException();
            }
        }

        private static void DFS(Tree<int> tree)
        {
            Console.Write(tree.Value + " ");
            foreach (Tree<int> child in tree.Children)
            {
                DFS(child);

            }
        }

        private static IEnumerable<int> DFSWithStack(Tree<int> tree)
        {
            var result = new Stack<int>();
            var stack = new Stack<Tree<int>>();
            stack.Push(tree);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                foreach (var child in node.Children)
                {
                    stack.Push(child);

                }

                result.Push(node.Value);


            }
            return result;
        }

        private static void BFS(Tree<int> tree)
        {
            Queue<Tree<int>> nums = new Queue<Tree<int>>();
            nums.Enqueue(tree);
            while (nums.Count != 0)
            {
                Tree<int> currentEl = nums.Dequeue();
                Console.Write(currentEl.Value + " ");
                foreach (var child in currentEl.Children)
                {
                    nums.Enqueue(child);

                }

            }

        }
    }
}
