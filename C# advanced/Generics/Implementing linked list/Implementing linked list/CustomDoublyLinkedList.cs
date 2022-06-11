using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class CustomDoublyLinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Count { get; private set; }  
        public void AddFirst(Node<T> node)
        {
            if (this.Head == null)
            {
                this.Head = node;
                this.Tail = node;


            }
            else
            {
                var oldHead = this.Head;
                this.Head = node;
                node.Next = oldHead;
                oldHead.Previous = node;



            }
            Count++;


        }
        public void AddLast(Node<T> node)
        {
            if (this.Tail == null)
            {
                this.Head = node;
                this.Tail = node;


            }
            else
            {
                var oldHead = this.Tail;
                this.Tail = node;
                node.Previous = oldHead;
                oldHead.Next = node;



            }
            Count++;


        }
        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                return default;

            }
            T removedValue = this.Head.Value;
            if (Head.Next != null)
            {
                this.Head = Head.Next;
                this.Head.Previous = null;

            }
            Count--;
            return removedValue;



        }
        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                return default;

            }
            T removedValue = this.Head.Value;
            if (Tail.Previous != null)
            {
                this.Tail = Tail.Previous;
                this.Tail.Next = null;

            }
            Count--;
            return removedValue;



        }
        public void ForEach(Action<Node<T>> action)
        {
            var node = Head;
            while (node != null)
            {
                action(node);

                node = node.Next;
            }


        }
        public Node<T>[] ToArray()
        {
            List<Node<T>> list = new List<Node<T>>();
            Node<T> node = this.Head;
            while (node != null)
            {
                list.Add(node);
                node = node.Next;


            }
            return list.ToArray();


        }
    }
}
