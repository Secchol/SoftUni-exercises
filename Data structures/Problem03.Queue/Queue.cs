namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> currentNode = this.head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;

        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T item = this.head.Value;
            this.head = this.head.Next;
            this.Count--;
            return item;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (this.head == null)
            {
                this.head = newNode;
                this.tail = newNode;

            }
            else
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }
            this.Count++;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return this.head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = this.head;
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