using System;

namespace SortingAlgorithms
{
    public static class Util
    {
        public static void Swap<T>(T[] array, int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        public static int FindSmallerIndex<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            T smaller = array[leftIndex];
            int smallerIndex = leftIndex;

            for (int i = leftIndex + 1; i <= rightIndex; i++)
            {
                if (array[i].CompareTo(smaller) < 0)
                {
                    smaller = array[i];
                    smallerIndex = i;
                }
            }

            return smallerIndex;
        }

        public static int FindBiggerIndex<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            T bigger = array[leftIndex];
            int biggerIndex = leftIndex;

            for (int i = leftIndex + 1; i <= rightIndex; i++)
            {
                if (array[i].CompareTo(bigger) > 0)
                {
                    bigger = array[i];
                    biggerIndex = i;
                }
            }

            return biggerIndex;
        }
    }
}
