﻿using System;

namespace SortingAlgorithms
{
    public static class LinearTimeAlgorithms
    {
        public static void CountingSort(byte[] array, int leftIndex, int rightIndex)
        {
            if (array != null && leftIndex >= 0 && rightIndex < array.Length)
            {
                int smaller = array[Util.FindSmallerIndex(array, leftIndex, rightIndex)];
                int bigger = array[Util.FindBiggerIndex(array, leftIndex, rightIndex)];
                int[] counters = new int[bigger - smaller + 1];

                for (int i = leftIndex; i <= rightIndex; i++)
                    counters[array[i] - smaller]++;

                for (int i = 1; i < counters.Length; i++)
                    counters[i] += counters[i - 1];

                byte[] newArray = new byte[array.Length];

                for (int i = rightIndex; i >= leftIndex; i--)
                {
                    newArray[counters[array[i] - smaller] - 1] = array[i];
                    counters[array[i] - smaller]--;
                }

                for (int i = leftIndex; i <= rightIndex; i++)
                    array[i] = newArray[i];
            }
        }

        public static void RadixSort(byte[] array, int leftIndex, int rightIndex)
        {
            if (array != null && leftIndex >= 0 && rightIndex < array.Length)
            {
                int maximum = array[Util.FindBiggerIndex(array, leftIndex, rightIndex)];
                int expBase = 10;

                for (int exponent = 1; maximum / exponent > 0; exponent *= expBase)
                    CountingSortByExponent(array, leftIndex, rightIndex, exponent, expBase);
            }
        }

        public static void CountingSortByExponent(byte[] array, int leftIndex, int rightIndex, int exponent, int expBase)
        {
            int[] counters = new int[expBase];

            for (int i = leftIndex; i <= rightIndex; i++)
                counters[array[i] / exponent % expBase]++;

            for (int i = 1; i < counters.Length; i++)
                counters[i] += counters[i - 1];

            byte[] newArray = new byte[array.Length];

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
