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
            int smallerIndex = leftIndex;

            for (int i = leftIndex + 1; i <= rightIndex; i++)
                if (array[i].CompareTo(array[smallerIndex]) < 0)
                    smallerIndex = i;

            return smallerIndex;
        }

        public static int FindBiggerIndex<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            int biggerIndex = leftIndex;

            for (int i = leftIndex + 1; i <= rightIndex; i++)
                if (array[i].CompareTo(array[biggerIndex]) > 0)
                    biggerIndex = i;

            return biggerIndex;
        }

        public static (int, int) FindSmallerAndBiggerIndices<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
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

            return (smallerIndex, biggerIndex);
        }
    }
}
