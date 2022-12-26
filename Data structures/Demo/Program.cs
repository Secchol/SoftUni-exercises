using Problem01.List;
using Problem02.Stack;
using Problem03.Queue;
using System;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine(queue.Peek());

        }
    }
}
