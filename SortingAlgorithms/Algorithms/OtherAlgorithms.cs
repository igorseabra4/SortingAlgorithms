using System;
using System.Linq;

namespace SortingAlgorithms
{
    public static class OtherAlgorithms
    {
        public static void RecursiveBubbleSort<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            if (leftIndex < rightIndex && array != null && leftIndex >= 0 && rightIndex < array.Length)
            {
                for (int i = leftIndex; i <= rightIndex - 1; i++)
                    if (array[i].CompareTo(array[i + 1]) > 0)
                        Util.Swap(array, i, i + 1);

                RecursiveBubbleSort(array, leftIndex, rightIndex - 1);
            }
        }

        public static void RecursiveInsertionSort<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            if (leftIndex < rightIndex && array != null && leftIndex >= 0 && rightIndex < array.Length)
            {
                RecursiveInsertionSort(array, leftIndex, rightIndex - 1);

                T current = array[rightIndex];
                int j = rightIndex;

                while (j > leftIndex && array[j - 1].CompareTo(current) > 0)
                {
                    array[j] = array[j - 1];
                    j--;
                }

                array[j] = current;
            }
        }

        public static void RecursiveSelectionSort<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            if (leftIndex < rightIndex && array != null && leftIndex >= 0 && rightIndex < array.Length)
            {
                Util.Swap(array, leftIndex, Util.FindSmallerIndex(array, leftIndex, rightIndex));

                RecursiveSelectionSort(array, leftIndex + 1, rightIndex);
            }
        }

        public static void OddEvenBubbleSort<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            if (array != null && leftIndex >= 0 && rightIndex < array.Length)
            {
                bool sorted;

                do
                {
                    sorted = true;

                    for (int j = leftIndex; j <= rightIndex - 1; j += 2)
                        if (array[j].CompareTo(array[j + 1]) > 0)
                        {
                            sorted = false;
                            Util.Swap(array, j, j + 1);
                        }

                    for (int j = leftIndex + 1; j <= rightIndex - 1; j += 2)
                        if (array[j].CompareTo(array[j + 1]) > 0)
                        {
                            sorted = false;
                            Util.Swap(array, j, j + 1);
                        }
                }
                while (!sorted);
            }
        }
    }
}
