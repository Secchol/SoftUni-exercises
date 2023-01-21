namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] array;
        private int startIndex;
        private int endIndex;
        public int Count { get; private set; }

        public CircularQueue(int capacity = 4)
        {
            this.array = new T[capacity];
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T result = this.array[startIndex];
            this.array[startIndex] = default;
            startIndex = (this.startIndex + 1) % this.array.Length;
            this.Count--;
            return result;


        }

        public void Enqueue(T item)
        {
            if (this.Count >= this.array.Length)
            {
                Grow();
            }
            this.array[endIndex] = item;
            this.endIndex = (this.endIndex + 1) % this.array.Length;
            this.Count++;
        }

        private void Grow()
        {
            this.array = this.CopyAllElementsTo(new T[2 * this.array.Length]);
            this.startIndex = 0;
            this.endIndex = this.Count;

        }



        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();

            }
            return this.array[startIndex];
        }

        public T[] ToArray()
        {
            return this.CopyAllElementsTo(new T[this.Count]);
        }
        public IEnumerator<T> GetEnumerator()
        {
            int sourceIndex = this.startIndex;
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[(sourceIndex + i) % this.array.Length];

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();

        private T[] CopyAllElementsTo(T[] resultArr)
        {
            int sourceIndex = this.startIndex;
            for (int i = 0; i < this.Count; i++)
            {
                resultArr[i] = this.array[sourceIndex];
                sourceIndex = (sourceIndex + 1) % this.array.Length;
            }

            return resultArr;
        }
    }

}
