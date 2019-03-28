namespace SortingAlgorithms
{
    public static class SimpleAlgorithms
    {
        public static void BubbleSort(byte[] array, int leftIndex, int rightIndex)
        {
            for (int i = leftIndex; i <= rightIndex; i++)
                for (int j = leftIndex; j <= rightIndex - i - 1; j++)
                    if (array[j] > array[j + 1])
                        Util.Swap(array, j, j + 1);
        }

        public static void InsertionSort(byte[] array, int leftIndex, int rightIndex)
        {
            for (int i = leftIndex + 1; i <= rightIndex; i++)
            {
                for (int j = i; j > leftIndex; j--)
                    if (array[j] < array[j - 1])
                        Util.Swap(array, j, j - 1);
            }
        }

        public static void SelectionSort(byte[] array, int leftIndex, int rightIndex)
        {
            int j;

            for (int i = leftIndex; i <= rightIndex; i++)
            {
                j = Util.FindSmallerIndex(array, i, rightIndex);
                Util.Swap(array, i, j);
            }
        }

        public static void CombSort(byte[] array, int leftIndex, int rightIndex)
        {
            int comb = (int)((rightIndex - leftIndex) / 1.3f);

            while (comb >= 1)
            {
                for (int i = leftIndex; i + comb <= rightIndex; i++)
                    if (array[i] > array[i + comb])
                        Util.Swap(array, i, i + comb);

                comb--;
            }
        }
    }
}
