namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {

        public MaxHeap()
        {
            values = new List<T>();

        }
        private List<T> values;
        public int Size => values.Count;

        public void Add(T element)
        {
            values.Add(element);
            HeapifyUp(values.Count - 1);
        }
        private void HeapifyUp(int index)
        {
            if ((index - 1) / 2 < 0)
            {
                return;

            }
            if (values[index].CompareTo(values[(index - 1) / 2]) > 0)
            {
                Swap((index - 1) / 2, index);
                HeapifyUp((index - 1) / 2);


            }
        }
        public T Peek()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();

            }
            return values[0];
        }
        public T ExtractMax()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();

            }
            T biggestElement = values[0];
            Swap(0, this.values.Count - 1);
            this.values.RemoveAt(this.values.Count - 1);
            HeapifyDown(0);
            return biggestElement;
        }

        private void HeapifyDown(int currentIndex)
        {
            if (2 * currentIndex + 1 < this.values.Count && values[currentIndex].CompareTo(values[2 * currentIndex + 1]) < 0)
            {
                Swap(currentIndex, 2 * currentIndex + 1);
                HeapifyDown(2 * currentIndex + 1);

            }
            else if (2 * currentIndex + 2 < this.values.Count && values[currentIndex].CompareTo(values[2 * currentIndex + 2]) < 0)
            {
                Swap(currentIndex, 2 * currentIndex + 2);
                HeapifyDown(2 * currentIndex + 2);

            }

        }

        private void Swap(int parentIndex, int childIndex)
        {
            T temp = values[childIndex];
            values[childIndex] = values[parentIndex];
            values[parentIndex] = temp;

        }
    }

}
