using System;

namespace SortingAlgorithms
{
    public class BinaryHeap
    {
        private int[] elements;
        private int size;

        private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
        private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

        public BinaryHeap()
        {
            elements = new int[8]; //a
            size = 0;
        }
        public BinaryHeap(int[] elements)
        {
            this.elements = elements;
            size = elements.Length;

            for (int i = GetParentIndex(size - 1); i >= 0; i++)
                Heapify(i);
        }

        public void Add(int element)
        {
            if (elements.Length == size - 1)
                IncreaseHeapSize();

            elements[size] = element;
            size++;

            var index = size - 1;
            while (index != 0 && elements[index] > elements[GetParentIndex(index)])
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }

        public int Pop()
        {
            if (size == 0)
                throw new IndexOutOfRangeException();

            var result = elements[0];
            elements[0] = elements[--size];

            Heapify(0);

            return result;
        }

        private void Heapify(int index)
        {
            int biggerIndex = GetLeftChildIndex(index);

            if (biggerIndex >= 0 && biggerIndex < size)
            {
                int rightChildIndex = GetRightChildIndex(index);
                if (rightChildIndex >= 0 && rightChildIndex < size && elements[rightChildIndex] > elements[biggerIndex])
                    biggerIndex = rightChildIndex;

                if (elements[biggerIndex] > elements[index])
                {
                    Swap(biggerIndex, index);
                    Heapify(biggerIndex);
                }
            }
        }
        
        public override string ToString()
        {
            return elements.ToString();
        }

        private void IncreaseHeapSize()
        {
            int[] array = new int[elements.Length * 2];
            for (int i = 0; i < elements.Length; i++)
                array[i] = elements[i];
            elements = array;
        }

        private void Swap(int i, int j)
        {
            int temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }
    }
}
