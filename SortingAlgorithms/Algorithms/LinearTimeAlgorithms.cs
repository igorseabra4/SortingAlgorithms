using System;

namespace SortingAlgorithms
{
    public static class LinearTimeAlgorithms
    {
        public static void MiniCountingSort(byte[] array, int leftIndex, int rightIndex)
        {
            if (array != null && leftIndex >= 0 && rightIndex < array.Length)
            {
                int bigger = array[Util.FindBiggerIndex(array, leftIndex, rightIndex)];
                int[] counters = new int[bigger + 1];

                for (int i = leftIndex; i <= rightIndex; i++)
                    counters[array[i]]++;

                for (int i = 1; i < counters.Length; i++)
                    counters[i] += counters[i - 1];

                byte[] newArray = new byte[array.Length];

                for (int i = rightIndex; i >= leftIndex; i--)
                {
                    newArray[counters[array[i]] - 1] = array[i];
                    counters[array[i]]--;
                }

                for (int i = leftIndex; i <= rightIndex; i++)
                    array[i] = newArray[i];
            }
        }

        public static void CountingSortWithoutTuples(int[] array, int leftIndex, int rightIndex)
        {
            if (array != null && leftIndex >= 0 && rightIndex < array.Length)
            {
                int smallerIndex = leftIndex;
                int biggerIndex = leftIndex;

                for (int i = leftIndex + 1; i <= rightIndex; i++)
                {
                    if (array[i].CompareTo(array[smallerIndex]) < 0)
                        smallerIndex = i;
                    if (array[i].CompareTo(array[biggerIndex]) > 0)
                        biggerIndex = i;
                }

                int smaller = array[smallerIndex];
                int[] counters = new int[array[biggerIndex] - smaller + 1];

                for (int i = leftIndex; i <= rightIndex; i++)
                    counters[array[i] - smaller]++;

                for (int i = 1; i < counters.Length; i++)
                    counters[i] += counters[i - 1];

                int[] newArray = new int[array.Length];

                for (int i = rightIndex; i >= leftIndex; i--)
                {
                    newArray[counters[array[i] - smaller] - 1] = array[i];
                    counters[array[i] - smaller]--;
                }

                for (int i = leftIndex; i <= rightIndex; i++)
                    array[i] = newArray[i];
            }
        }

        public static void CountingSort(int[] array, int leftIndex, int rightIndex)
        {
            if (array != null && leftIndex >= 0 && rightIndex < array.Length)
            {
                (int, int) smallerAndBigger = Util.FindSmallerAndBiggerIndices(array, leftIndex, rightIndex);

                int smaller = array[smallerAndBigger.Item1];
                int bigger = array[smallerAndBigger.Item2];
                int[] counters = new int[bigger - smaller + 1];

                for (int i = leftIndex; i <= rightIndex; i++)
                    counters[array[i] - smaller]++;

                for (int i = 1; i < counters.Length; i++)
                    counters[i] += counters[i - 1];

                int[] newArray = new int[array.Length];

                for (int i = rightIndex; i >= leftIndex; i--)
                {
                    newArray[counters[array[i] - smaller] - 1] = array[i];
                    counters[array[i] - smaller]--;
                }

                for (int i = leftIndex; i <= rightIndex; i++)
                    array[i] = newArray[i];
            }
        }

        // note: this implementation of radix sort only works with arrays containing only positive values!
        public static void RadixSort(int[] array, int leftIndex, int rightIndex)
        {
            if (array != null && leftIndex >= 0 && rightIndex < array.Length)
            {
                int maximum = array[Util.FindBiggerIndex(array, leftIndex, rightIndex)];
                int expBase = 256;

                for (int exponent = 1; maximum / exponent > 0; exponent *= expBase)
                    CountingSortByExponent(array, leftIndex, rightIndex, exponent, expBase);
            }
        }

        public static void CountingSortByExponent(int[] array, int leftIndex, int rightIndex, int exponent, int expBase)
        {
            int[] counters = new int[expBase];

            for (int i = leftIndex; i <= rightIndex; i++)
                counters[array[i] / exponent % expBase]++;

            for (int i = 1; i < counters.Length; i++)
                counters[i] += counters[i - 1];

            int[] newArray = new int[array.Length];

            // right to left is what keeps it stable
            for (int i = rightIndex; i >= leftIndex; i--)
            {
                newArray[counters[array[i] / exponent % expBase] - 1] = array[i];
                counters[array[i] / exponent % expBase]--;
            }

            for (int i = leftIndex; i <= rightIndex; i++)
                array[i] = newArray[i];
        }
    }
}
