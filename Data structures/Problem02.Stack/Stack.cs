namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection.Metadata.Ecma335;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> head;

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

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();

            }

            return this.head.Value;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            Node<T> oldHead = this.head;
            this.head = this.head.Next;
            this.Count--;
            return oldHead.Value;
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item);
            Node<T> oldHead = this.head;
            this.head = newNode;
            this.head.Next = oldHead;
            this.Count++;
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