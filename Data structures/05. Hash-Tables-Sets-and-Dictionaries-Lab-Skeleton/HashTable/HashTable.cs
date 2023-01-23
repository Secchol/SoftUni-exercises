namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private const int DefaultCapacity = 4;
        private LinkedList<KeyValue<TKey, TValue>>[] slots;
        private const float LoadFactor = 0.75f;
        public int Count { get; private set; }

        public int Capacity => this.slots.Length;

        public HashTable() : this(DefaultCapacity)
        {

        }

        public HashTable(int capacity)
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        }

        public void Add(TKey key, TValue value)
        {
            this.GrowIfNeeded();
            int index = Math.Abs(key.GetHashCode()) % this.Capacity;

            if (this.slots[index] == null)
            {
                this.slots[index] = new LinkedList<KeyValue<TKey, TValue>>();

            }

            foreach (var item in this.slots[index])
            {
                if (item.Key.Equals(key))
                {
                    throw new ArgumentException();

                }
            }

            var element = new KeyValue<TKey, TValue>(key, value);
            this.slots[index].AddLast(element);
            this.Count++;
        }

        private void GrowIfNeeded()
        {
            if ((float)(this.Count + 1) / this.Capacity >= LoadFactor)
            {
                var newTable = new HashTable<TKey, TValue>(this.Capacity * 2);
                foreach (var element in this)
                {
                    newTable.Add(element.Key, element.Value);
                }
                this.slots = newTable.slots;
                this.Count = newTable.Count;


            }
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            this.GrowIfNeeded();
            int index = Math.Abs(key.GetHashCode()) % this.Capacity;

            if (this.slots[index] == null)
            {
                this.slots[index] = new LinkedList<KeyValue<TKey, TValue>>();

            }

            foreach (var item in this.slots[index])
            {
                if (item.Key.Equals(key))
                {
                    item.Value = value;
                    return true;

                }
            }

            var element = new KeyValue<TKey, TValue>(key, value);
            this.slots[index].AddLast(element);
            this.Count++;
            return false;
        }

        public TValue Get(TKey key)
        {
            throw new NotImplementedException();
        }

        public TValue this[TKey key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                this.AddOrReplace(key, value);
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var element = this.Find(key);

            if (element != null)
            {
                value = element.Value;
                return true;
            }

            value = default;
            return false;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TKey> Keys => this.Select(kvp => kvp.Key);

        public IEnumerable<TValue> Values
        {
            get
            {
                return this.Select(kvp => kvp.Value);
            }
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var slot in this.slots)
            {
                if (slot != null)
                {
                    foreach (var element in slot)
                    {
                        yield return element;
                    }

                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
