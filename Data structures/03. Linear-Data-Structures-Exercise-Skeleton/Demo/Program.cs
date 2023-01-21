using Problem01.CircularQueue;
using Problem02.DoublyLinkedList;
using Problem03.ReversedList;
using System;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReversedList<int> list = new ReversedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Console.WriteLine(list.IndexOf(2));
        }
    }
}
