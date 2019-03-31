using System;

namespace SortingAlgorithms
{
    public static class OtherStuff
    {
        // returns k-th smallest value of array after doing a partial selection sort on it.
        public static T OrderStatistic<T>(T[] array, int leftIndex, int rightIndex, int k) where T : IComparable
        {
            if (leftIndex >= 0)
                throw new ArgumentException("Error: make sure leftIndex is bigger than 0");
            if (rightIndex < array.Length)
                throw new ArgumentException("Error: make sure rightIndex is smaller than array.Length");
            if (k <= rightIndex - leftIndex)
                throw new ArgumentException("Error: make sure k is smaller than the analyzed section of array");

            int j = leftIndex;

            for (int i = leftIndex; i <= leftIndex + k; i++) // check above will guarantee leftIndex + k is never bigger than rightIndex, at most equal
            {
                j = Util.FindSmallerIndex(array, i, rightIndex);
                Util.Swap(array, i, j);
            }

            return array[leftIndex + k];
        }

        // recieves ordered array and returns the biggest element of it which is still smaller than value by performing a recursive binary search
        public static T FloorThroughBinarySearch<T>(T[] array, int leftIndex, int rightIndex, T value) where T : IComparable
        {
            int middleIndex = (leftIndex + rightIndex) / 2;

            if (array[middleIndex].CompareTo(value) == 0) // i found the exact value in the array
                return array[middleIndex];
            
            else if (middleIndex == leftIndex || middleIndex == rightIndex) // i'm in doubt between only two values, no further recursive step needed
            {
                if (array[rightIndex].CompareTo(value) < 0)
                    return array[rightIndex]; // both are smaller than value, we return right which is the bigger of the two
                return array[leftIndex]; // right is bigger than value, we return left
            }
            else if (array[middleIndex].CompareTo(value) > 0)
                // my middle is bigger than value, we must look to the left
                return FloorThroughBinarySearch(array, leftIndex, middleIndex - 1, value);
            else
                // my middle is smaller than value, we must look from it to the right
                return FloorThroughBinarySearch(array, middleIndex, rightIndex, value);
        }

        // recieves ordered array and returns the smallest element of it which is still bigger than value by performing a recursive binary search
        public static T CeilingThroughBinarySearch<T>(T[] array, int leftIndex, int rightIndex, T value) where T : IComparable
        {
            int middleIndex = (leftIndex + rightIndex) / 2;

            if (array[middleIndex].CompareTo(value) == 0) // i found the exact value in the array
                return array[middleIndex];
            
            else if (middleIndex == leftIndex || middleIndex == rightIndex) // i'm in doubt between only two values, no further recursive step needed
            {
                if (array[leftIndex].CompareTo(value) > 0)
                    return array[leftIndex]; // both are bigger than value, we return left which is the smaller of the two
                return array[rightIndex]; // left is smaller than value, we return right
            }
            else if (array[middleIndex].CompareTo(value) < 0)
                // my middle is smaller than value, we must look to the right
                return CeilingThroughBinarySearch(array, middleIndex + 1, rightIndex, value);
            else
                // my middle is bigger than value, we must from left to it
                return CeilingThroughBinarySearch(array, leftIndex, middleIndex, value);
        }
    }
}
