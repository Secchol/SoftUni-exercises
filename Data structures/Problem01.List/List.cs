namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] array;
        private int index;

        public List()
            : this(DEFAULT_CAPACITY)
        {

        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            array = new T[DEFAULT_CAPACITY];
        }

        public T this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }
                return this.array[index];
            }
            set
            {
                if (!IsValidIndex(index))
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }
                this.array[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (index == array.Length)
            {
                Grow(array);
            }
            this.array[index++] = item;
            this.Count++;
        }



        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (array[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }


        public int IndexOf(T item)
        {

            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (!IsValidIndex(index))
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            if (index == this.array.Length - 1)
            {
                Grow(array);

            }
            for (int i = this.Count - 1; i >= index; i--)
            {
                array[i + 1] = array[i];
            }
            array[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (array[i].Equals(item))
                {
                    this.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (!IsValidIndex(index))
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            for (int i = index + 1; i < this.Count; i++)
            {
                this.array[i - 1] = this.array[i];
            }
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
        private void Grow(T[] array)
        {
            T[] newArray = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            this.array = newArray;
        }
        private bool IsValidIndex(int index)
        {
            return index >= 0 && index < array.Length;
        }
    }
}