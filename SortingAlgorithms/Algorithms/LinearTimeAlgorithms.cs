using System;

namespace SortingAlgorithms
{
    public static class LinearTimeAlgorithms
    {
        public static void CountingSort(byte[] array, int leftIndex, int rightIndex)
        {
            int smaller = array[Util.FindSmallerIndex(array, leftIndex, rightIndex)];
            int bigger = array[Util.FindBiggerIndex(array, leftIndex, rightIndex)];
            int[] counters = new int[bigger - smaller + 1];

            for (int i = leftIndex; i <= rightIndex; i++)
                counters[array[i] - smaller]++;

            for (int i = 1; i < counters.Length; i++)
                counters[i] += counters[i - 1];

            byte[] newArray = new byte[array.Length];

            for (int i = leftIndex; i <= rightIndex; i++)
            {
                newArray[counters[array[i] - smaller] - 1] = array[i];
                counters[array[i] - smaller]--;
            }

            for (int i = leftIndex; i <= rightIndex; i++)
                array[i] = newArray[i];
        }
    }
}
