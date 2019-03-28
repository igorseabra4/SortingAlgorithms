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

        // Perform a test of multiple sorting algorithms on the same array of random bytes.
        static void DoTest(int arrayLength)
        {
            Random r = new Random();
            byte[] array = new byte[arrayLength];
            r.NextBytes(array);

            Console.WriteLine("Array with " + array.Length + " numbers:");

            // Linear algorithms
            Console.WriteLine(OperationResult(LinearTimeAlgorithms.CountingSort, array));

            // Recursive algorithms
            Console.WriteLine(OperationResult(RecursiveAlgorithms.QuickSort, array));
            Console.WriteLine(OperationResult(RecursiveAlgorithms.MergeSort, array));

            // Selection sorts
            Console.WriteLine(OperationResult(SimpleAlgorithms.SelectionSort, array));
            Console.WriteLine(OperationResult(OtherAlgorithms.RecursiveSelectionSort, array));

            // Insertion sorts
            Console.WriteLine(OperationResult(SimpleAlgorithms.InsertionSort, array));
            Console.WriteLine(OperationResult(OtherAlgorithms.RecursiveInsertionSort, array));

            // Bubble sorts
            Console.WriteLine(OperationResult(SimpleAlgorithms.BubbleSort, array));
            Console.WriteLine(OperationResult(OtherAlgorithms.RecursiveBubbleSort, array));
            Console.WriteLine(OperationResult(OtherAlgorithms.OddEvenBubbleSort, array));

            // Other n squared algorithms
            Console.WriteLine(OperationResult(SimpleAlgorithms.CombSort, array));

            Console.WriteLine();
        }

        private delegate void OperationDelegate<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable;

        static string OperationResult<T>(OperationDelegate<T> operationDelegate, T[] array) where T : IComparable
        {
            T[] newArray = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
                newArray[i] = array[i];
            T[] testArray = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
                testArray[i] = array[i];

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            operationDelegate(newArray, 0, newArray.Length - 1);
            stopWatch.Stop();

            Array.Sort(testArray);
            return "Algorithm: " + operationDelegate.Method.Name + ", Time: " + stopWatch.ElapsedMilliseconds.ToString() + " ms, Assert: " + AssertAreEqual(testArray, newArray);
        }

        static bool AssertAreEqual<T>(T[] array1, T[] array2) where T : IComparable
        {
            if (array1.Length != array2.Length)
                return false;

            for (int i = 0; i < array1.Length; i++)
                if (array1[i].CompareTo(array2[i]) != 0)
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
