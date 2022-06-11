using System;

namespace CustomDoublyLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomDoublyLinkedList<string> list = new CustomDoublyLinkedList<string>();
            list.AddFirst(new Node<string>("sdfsdf"));
            Node<string>[] arr = list.ToArray();

        }
    }
}
