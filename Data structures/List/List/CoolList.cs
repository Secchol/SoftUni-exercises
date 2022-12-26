using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class CoolList<T>
    {
        private T[] array;
        private int index;
        public CoolList(int initialCapacity = 4)
        {
            array = new T[initialCapacity];
        }
        public int Count { get { return index; } }
        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                this.array[index] = value;
            }
        }
        public void Add(T element)
        {
            if (index == array.Length)
            {
                array = DoubleArraySize(array);
            }
            array[index++] = element;
        }

        private T[] DoubleArraySize(T[] array)
        {
            T[] newArray = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }
    }
}
