using System;

namespace SortingAlgorithms
{
    public static class SimpleAlgorithms
    {
        public static void BubbleSort<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            if (leftIndex >= 0 && rightIndex < array.Length)
            {
                for (int i = leftIndex; i <= rightIndex; i++)
                    for (int j = leftIndex; j <= rightIndex - i - 1; j++)
                        if (array[j].CompareTo(array[j + 1]) > 0)
                            Util.Swap(array, j, j + 1);
            }
        }

        public static void InsertionSort<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            if (leftIndex >= 0 && rightIndex < array.Length)
            {
                for (int i = leftIndex + 1; i <= rightIndex; i++)
                {
                    T current = array[i];
                    int j = i;

                    while (j > leftIndex && array[j - 1].CompareTo(current) > 0)
                    {
                        array[j] = array[j - 1];
                        j--;
                    }

                    array[j] = current;
                }
            }
        }

        public static void SelectionSort<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            if (leftIndex >= 0 && rightIndex < array.Length)
            {
                int j;

                for (int i = leftIndex; i <= rightIndex; i++)
                {
                    j = Util.FindSmallerIndex(array, i, rightIndex);
                    Util.Swap(array, i, j);
                }
            }
        }

        public static void SimultaneousSelectionSort<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            if (leftIndex >= 0 && rightIndex < array.Length)
            {
                int iterations = (int)Math.Ceiling((rightIndex - leftIndex) / 2.0);

                for (int i = 0; i < iterations; i++)
                {
                    (int, int) smallerAndBigger = Util.FindSmallerAndBiggerIndices(array, leftIndex + i, rightIndex - i);
                    Util.Swap(array, leftIndex + i, smallerAndBigger.Item1);
                    Util.Swap(array, rightIndex - i, smallerAndBigger.Item2);
                }
            }
        }

        public static void CombSort<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            if (leftIndex >= 0 && rightIndex < array.Length)
            {
                int comb = (int)((rightIndex - leftIndex) / 1.3f);

                while (comb >= 1)
                {
                    for (int i = leftIndex; i + comb <= rightIndex; i++)
                        if (array[i].CompareTo(array[i + comb]) > 0)
                            Util.Swap(array, i, i + comb);

                    comb--;
                }
            }
        }
    }
}
