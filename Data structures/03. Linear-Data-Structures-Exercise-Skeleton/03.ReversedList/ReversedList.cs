namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;
        private int index;
        private T[] items;

        public ReversedList()
            : this(DefaultCapacity)
        {

        }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));
            this.index = 0;
            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return items[this.Count - 1 - index];
            }
            set
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                Grow();
            }
            this.items[index++] = item;
            this.Count++;
        }



        public bool Contains(T item)
        {
            if (this.IndexOf(item) == -1)
                return false;
            return true;
        }

        public int IndexOf(T item)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (items[i].Equals(item))
                {
                    return this.Count - 1 - i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
        private void Grow()
        {
            T[] biggerArr = new T[this.items.Length * 2];
            for (int i = 0; i < this.Count; i++)
            {
                biggerArr[i] = this.items[i];
            }
            this.items = biggerArr;
        }
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {

                throw new InvalidOperationException();
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}