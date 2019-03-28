using System;
using System.Diagnostics;

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
            PerformOperationAndWriteResult(LinearTimeAlgorithms.CountingSort, array);
            PerformOperationAndWriteResult(RecursiveAlgorithms.QuickSort, array);
            PerformOperationAndWriteResult(RecursiveAlgorithms.MergeSort, array);
            //PerformOperationAndWriteResult(SimpleAlgorithms.CombSort, array);
            PerformOperationAndWriteResult(SimpleAlgorithms.InsertionSort, array);
            PerformOperationAndWriteResult(SimpleAlgorithms.SelectionSort, array);
            PerformOperationAndWriteResult(OtherAlgorithms.RecursiveSelectionSort, array);
            PerformOperationAndWriteResult(SimpleAlgorithms.BubbleSort, array);
            PerformOperationAndWriteResult(OtherAlgorithms.OddEvenBubbleSort, array);
            //PerformOperationAndWriteResult(OtherAlgorithms.RecursiveBubbleSort, array);

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
                Console.Write(i.ToString() + " ");
        }
    }
}
