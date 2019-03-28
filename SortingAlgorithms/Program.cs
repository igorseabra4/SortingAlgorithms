using System;
using System.Diagnostics;
using System.Threading;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            DoTest(10);
            DoTest(100);
            DoTest(1000);
            DoTest(10000);
            DoTest(100000);
            DoTest(1000000);
            Console.ReadKey();
        }

        static void DoTest(int arrayLength)
        {
            Random r = new Random();
            byte[] array = new byte[arrayLength];
            r.NextBytes(array);

            Console.WriteLine(("Array with " + array.Length + " numbers:").PadRight(27));
            PerformOperationAndWriteResult(CountingSort, array);
            PerformOperationAndWriteResult(QuickSort, array);
            PerformOperationAndWriteResult(MergeSort, array);
            PerformOperationAndWriteResult(CombSort, array);
            PerformOperationAndWriteResult(InsertionSort, array);
            PerformOperationAndWriteResult(SelectionSort, array);
            PerformOperationAndWriteResult(BubbleSort, array);

            Console.WriteLine();
        }

        private delegate void OperationDelegate(byte[] array, int leftIndex, int rightIndex);

        static void PerformOperationAndWriteResult(OperationDelegate operationDelegate, byte[] array)
        {
            byte[] newArray = new byte[array.Length];
            for (int i = 0; i < array.Length; i++)
                newArray[i] = array[i];
            byte[] testArray = new byte[array.Length];
            for (int i = 0; i < array.Length; i++)
                testArray[i] = array[i];

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            operationDelegate(newArray, 0, newArray.Length - 1);
            stopWatch.Stop();

            Array.Sort(testArray);

            Console.Write(("Algorithm: " + operationDelegate.Method.Name + ", Time: " + stopWatch.ElapsedMilliseconds.ToString() + " ms, Assert: " + AssertAreEqual(testArray, newArray)).PadRight(27));
            //WriteArray(newArray);
            Console.WriteLine();
        }

        static bool AssertAreEqual(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
                return false;

            for (int i = 0; i < array1.Length; i++)
                if (array1[i] != array2[i])
                    return false;

            return true;
        }

        static void WriteArray(byte[] array)
        {
            foreach (byte i in array)
                Console.Write(i.ToString().PadLeft(3) + " ");
        }

        static void Swap(byte[] array, int index1, int index2)
        {
            byte temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        static void BubbleSort(byte[] array, int leftIndex, int rightIndex)
        {
            for (int i = leftIndex; i <= rightIndex; i++)
                for (int j = leftIndex; j <= rightIndex - i - 1; j++)
                    if (array[j] > array[j + 1])
                        Swap(array, j, j + 1);
        }

        static void InsertionSort(byte[] array, int leftIndex, int rightIndex)
        {
            for (int i = leftIndex + 1; i <= rightIndex; i++)
            {
                for (int j = i; j > leftIndex; j--)
                    if (array[j] < array[j - 1])
                        Swap(array, j, j - 1);
            }
        }

        static void SelectionSort(byte[] array, int leftIndex, int rightIndex)
        {
            int j;

            for (int i = leftIndex; i <= rightIndex; i++)
            {
                j = FindSmallerIndex(array, i, rightIndex);
                Swap(array, i, j);
            }
        }

        private static int FindSmallerIndex(byte[] array, int leftIndex, int rightIndex)
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

        static void MergeSort(byte[] array, int leftIndex, int rightIndex)
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

        static void QuickSort(byte[] array, int leftIndex, int rightIndex)
        {
            if (rightIndex > leftIndex)
            {
                int rightIterator = leftIndex;
                
                for (int i = leftIndex; i < rightIndex; i++)
                {
                    if (array[i] < array[rightIndex])
                    {
                        Swap(array, i, rightIterator);
                        rightIterator++;
                    }
                }

                Swap(array, rightIterator, rightIndex);

                QuickSort(array, leftIndex, rightIterator - 1);
                QuickSort(array, rightIterator + 1, rightIndex);
            }
        }
        
        static void CombSort(byte[] array, int leftIndex, int rightIndex)
        {
            int comb = (int)((rightIndex - leftIndex) / 1.3f);

            while (comb >= 1)
            {
                for (int i = leftIndex; i + comb <= rightIndex; i++)
                    if (array[i] > array[i + comb])
                        Swap(array, i, i + comb);

                comb--;
            }
        }

        static void CountingSort(byte[] array, int leftIndex, int rightIndex)
        {
            int smaller = array[FindSmallerIndex(array, leftIndex, rightIndex)];
            int bigger = array[FindBiggerIndex(array, leftIndex, rightIndex)];
            int[] counters = new int[bigger - smaller + 1];

            for (int i = leftIndex; i <= rightIndex; i++)
                counters[array[i] - smaller]++;

            for (int i = 1; i < counters.Length; i++)
                counters[i] += counters[i - 1];

            byte[] newArray = new byte[array.Length];

            for (int i = leftIndex; i <= rightIndex; i++)
            {
                newArray[counters[array[i] - smaller] - 1] = array[i];
                counters[array[i] - smaller]--;
            }

            for (int i = leftIndex; i <= rightIndex; i++)
                array[i] = newArray[i];
        }

        private static int FindBiggerIndex(byte[] array, int leftIndex, int rightIndex)
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
