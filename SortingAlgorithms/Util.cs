namespace SortingAlgorithms
{
    public static class Util
    {
        public static void Swap(byte[] array, int index1, int index2)
        {
            byte temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        public static int FindSmallerIndex(byte[] array, int leftIndex, int rightIndex)
        {
            int smaller = array[leftIndex];
            int smallerIndex = leftIndex;

            for (int i = leftIndex + 1; i <= rightIndex; i++)
            {
                if (array[i] < smaller)
                {
                    smaller = array[i];
                    smallerIndex = i;
                }
            }

            return smallerIndex;
        }

        public static int FindBiggerIndex(byte[] array, int leftIndex, int rightIndex)
        {
            int bigger = array[leftIndex];
            int biggerIndex = leftIndex;

            for (int i = leftIndex + 1; i <= rightIndex; i++)
            {
                if (array[i] > bigger)
                {
                    bigger = array[i];
                    biggerIndex = i;
                }
            }

            return biggerIndex;
        }
    }
}
