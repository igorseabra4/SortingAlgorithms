namespace SortingAlgorithms
{
    public static class OtherAlgorithms
    {
        public static void RecursiveBubbleSort(byte[] array, int leftIndex, int rightIndex)
        {
            for (int i = leftIndex; i <= rightIndex - 1; i++)
                if (array[i] > array[i + 1])
                    Util.Swap(array, i, i + 1);

            if (rightIndex - 1 > leftIndex)
                RecursiveBubbleSort(array, leftIndex, rightIndex - 1);
        }

        public static void RecursiveSelectionSort(byte[] array, int leftIndex, int rightIndex)
        {
            Util.Swap(array, leftIndex, Util.FindSmallerIndex(array, leftIndex, rightIndex));

            if (leftIndex + 1 < rightIndex)
                RecursiveSelectionSort(array, leftIndex + 1, rightIndex);
        }

        public static void OddEvenBubbleSort(byte[] array, int leftIndex, int rightIndex)
        {
            bool sorted;

            do
            {
                sorted = true;

                for (int j = leftIndex; j <= rightIndex - 1; j += 2)
                    if (array[j] > array[j + 1])
                    {
                        sorted = false;
                        Util.Swap(array, j, j + 1);
                    }

                for (int j = leftIndex + 1; j <= rightIndex - 1; j += 2)
                    if (array[j] > array[j + 1])
                    {
                        sorted = false;
                        Util.Swap(array, j, j + 1);
                    }
            }
            while (!sorted);
        }
    }
}
