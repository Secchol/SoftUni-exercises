using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        public List<T> Elements { get; set; }
        public int Count { get; private set; }
        public Box()
        {
            this.Elements = new List<T>();
            Count = 0;


        }
        public void Add(T element)
        {
            this.Elements.Add(element);
            Count++;


        }
        public T Remove()
        {
            T removedElement = Elements[Count - 1];
            Elements.RemoveAt(--Count);

            return removedElement;


        }

    }
}
