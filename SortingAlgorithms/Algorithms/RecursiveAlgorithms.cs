namespace SortingAlgorithms
{
    public static class RecursiveAlgorithms
    {
        public static void MergeSort(byte[] array, int leftIndex, int rightIndex)
        {
            int middle = (leftIndex + rightIndex) / 2;

            if (leftIndex < rightIndex)
            {
                MergeSort(array, leftIndex, middle);
                MergeSort(array, middle + 1, rightIndex);
            }

            Merge(array, leftIndex, middle, rightIndex);
        }

        private static void Merge(byte[] array, int leftIndex, int middle, int rightIndex)
        {
            int leftIterator = leftIndex;
            int rightIterator = middle + 1;

            byte[] newList = new byte[array.Length];

            for (int newIterator = leftIndex; newIterator <= rightIndex; newIterator++)
            {
                if (leftIterator <= middle && rightIterator <= rightIndex)
                {
                    if (array[leftIterator] < array[rightIterator])
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
                else if (rightIterator <= rightIndex)
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

        public static void QuickSort(byte[] array, int leftIndex, int rightIndex)
        {
            if (rightIndex > leftIndex)
            {
                int rightIterator = leftIndex;

                for (int i = leftIndex; i < rightIndex; i++)
                {
                    if (array[i] < array[rightIndex]) // pivot = rightIndex
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
    }
}
