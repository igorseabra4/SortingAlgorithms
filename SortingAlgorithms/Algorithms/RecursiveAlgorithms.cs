using System;

namespace SortingAlgorithms
{
    public static class RecursiveAlgorithms
    {
        public static void MergeSort<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            if (leftIndex >= 0 && rightIndex < array.Length)
            {
                int middle = (leftIndex + rightIndex) / 2;

                if (leftIndex < rightIndex)
                {
                    MergeSort(array, leftIndex, middle);
                    MergeSort(array, middle + 1, rightIndex);
                }

                Merge(array, leftIndex, middle, rightIndex);
            }
        }

        private static void Merge<T>(T[] array, int leftIndex, int middle, int rightIndex) where T : IComparable
        {
            int leftIterator = leftIndex;
            int rightIterator = middle + 1;

            T[] newList = new T[array.Length];

            for (int newIterator = leftIndex; newIterator <= rightIndex; newIterator++)
            {
                if (leftIterator <= middle && rightIterator <= rightIndex)
                {
                    if (array[leftIterator].CompareTo(array[rightIterator]) < 0)
                    {
                        newList[newIterator] = array[leftIterator];
                        leftIterator++;
                    }
                    else
                    {
                        newList[newIterator] = array[rightIterator];
                        rightIterator++;
                    }
                }
                else if (leftIterator <= middle)
                {
                    newList[newIterator] = array[leftIterator];
                    leftIterator++;
                }
                else
                {
                    newList[newIterator] = array[rightIterator];
                    rightIterator++;
                }
            }

            for (int i = leftIndex; i <= rightIndex; i++)
            {
                array[i] = newList[i];
            }
        }
        
        public static void QuickSort<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            if (rightIndex > leftIndex && leftIndex >= 0 && rightIndex < array.Length)
            {
                int rightIterator = leftIndex;

                int pivot = new Random().Next(leftIndex, rightIndex + 1); // random pivot
                Util.Swap(array, pivot, rightIndex); // which is placed at rightIndex

                for (int i = leftIndex; i < rightIndex; i++)
                {
                    if (array[i].CompareTo(array[rightIndex]) < 0) // pivot = rightIndex
                    {
                        Util.Swap(array, i, rightIterator);
                        rightIterator++;
                    }
                }

                Util.Swap(array, rightIterator, rightIndex); // place pivot at its position

                QuickSort(array, leftIndex, rightIterator - 1);
                QuickSort(array, rightIterator + 1, rightIndex);
            }
        }
        
        public static void ThreeWayQuickSort<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            if (rightIndex > leftIndex && leftIndex >= 0 && rightIndex < array.Length)
            {
                int equal = 0;
                for (int i = leftIndex; i < rightIndex - equal; i++)
                {
                    if (array[i].Equals(array[rightIndex]))
                    {
                        Util.Swap(array, i, rightIndex - equal - 1);
                        equal++;
                    }
                }
                
                int rightIterator = leftIndex;

                for (int i = leftIndex; i < rightIndex; i++)
                {
                    if (array[i].CompareTo(array[rightIndex]) < 0) // pivot = rightIndex
                    {
                        Util.Swap(array, i, rightIterator);
                        rightIterator++;
                    }
                }

                for (int i = 0; i <= equal; i++)
                    Util.Swap(array, rightIterator + i, rightIndex - i);
                
                ThreeWayQuickSort(array, leftIndex, rightIterator - 1);
                ThreeWayQuickSort(array, rightIterator + equal + 1, rightIndex);
            }
        }
    }
}
