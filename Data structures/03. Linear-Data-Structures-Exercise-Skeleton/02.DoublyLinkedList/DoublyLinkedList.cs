namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {

        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public Node(T value)
            {
                this.Value = value;

            }
        }

        public DoublyLinkedList()
        {
            this.Count = 0;
            this.tail = null;
            this.head = null;
        }
        private Node head;
        private Node tail;
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node newNode = new Node(item);
            if (this.Count == 0)
            {
                this.tail = this.head = newNode;
            }
            else
            {
                this.head.Previous = newNode;
                newNode.Next = this.head;
                this.head = newNode;

            }
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node newNode = new Node(item);
            if (this.Count == 0)
            {
                this.tail = this.head = null;

            }
            else
            {
                this.tail.Next = newNode;
                newNode.Previous = this.tail;
                this.tail = newNode;
            }
            this.Count++;
        }

        public T GetFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();

            }

            return this.head.Value;
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return this.tail.Value;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();

            }
            T result = this.head.Value;
            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.head = this.head.Next;
                this.head.Previous = null;
            }
            this.Count--;
            return result;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T result = this.tail.Value;
            if (this.Count == 1)
            {
                this.tail = this.head = null;

            }
            else
            {
                this.tail = this.tail.Previous;
                this.tail.Next = null;
            }
            this.Count--;
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
    }
}