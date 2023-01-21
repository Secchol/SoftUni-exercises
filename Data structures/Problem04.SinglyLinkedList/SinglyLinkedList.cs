namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (this.head == null)
            {
                this.tail = newNode;
                this.head = newNode;
            }
            else
            {

                Node<T> oldNode = this.head;
                this.head = newNode;
                this.head.Next = oldNode;
            }
        }

        public void AddLast(T item)
        {
            Node<T> lastEl = new Node<T>(item);
            if (this.tail == null)
            {
                this.head = lastEl;
            }

            this.tail.Next = lastEl;
            this.tail = lastEl;
        }

        public T GetFirst()
        {
            return this.head.Value;
        }

        public T GetLast()
        {
            return this.tail.Value;
        }

        public T RemoveFirst()
        {
            T oldHead = this.head.Value;
            this.head = this.head.Next;
            return oldHead;
        }

        public T RemoveLast()
        {
            throw new NotImplementedException();
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