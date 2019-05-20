using System;
using System.Diagnostics;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>(null);

            while (true)
            {
                string entry = Console.ReadLine();

                if (entry.StartsWith("a"))
                    binaryTree.Add(int.Parse(entry.Split(' ')[1]));
                else if (entry.StartsWith("r"))
                    binaryTree.Remove(int.Parse(entry.Split(' ')[1]));
                else if (entry.StartsWith("f"))
                    Console.WriteLine(binaryTree.Find(int.Parse(entry.Split(' ')[1])).ToString());
                else if (entry.StartsWith("ub"))
                    Console.WriteLine(binaryTree.UpperBound().ToString());
                else if (entry.StartsWith("lb"))
                    Console.WriteLine(binaryTree.LowerBound().ToString());
                else if (entry.StartsWith("su"))
                    Console.WriteLine(binaryTree.Successor().ToString());
                else if (entry.StartsWith("pr"))
                    Console.WriteLine(binaryTree.Predecessor().ToString());
                else if (entry.StartsWith("m"))
                    Console.WriteLine(binaryTree.Data.ToString());

                Console.WriteLine(binaryTree.ToString());
            }
        }

        /* Coisas que aprendi com esse programa:
         * - Os algoritmos n^2 nao servem pra nada
         * - As versoes recursivas deles conseguem ser piores que eles
         * - Radix sort comeca a ser melhor que counting sort quando a amplitude dos valores do array aumenta
         * */
        static void Main2(string[] args)
        {
            int maxValue = 10000000;
            Console.WriteLine("Maximum value in array (amplitude de valores): " + maxValue);
            Console.WriteLine(); // we're not working with negative values since radix sort (and the mini counting sort) doesn't like that, but the rest can do it

            DoTest(10, maxValue);
            DoTest(50, maxValue);
            DoTest(100, maxValue);
            DoTest(500, maxValue);
            DoTest(1000, maxValue);
            DoTest(10000, maxValue);
            DoTest(100000, maxValue);
            //DoTest(1000000, maxValue);
            //DoTest(10000000, maxValue);
            //DoTest(100000000, maxValue);
            Console.ReadKey();
        }

        // Perform a test of multiple sorting algorithms on the same array of random integers, array length and maximum value of array value are parameters
        static void DoTest(int arrayLength, int maxValue)
        {
            Random r = new Random((int)DateTime.Now.ToBinary());
            int[] array = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
                array[i] = r.Next(0, maxValue + 1);

            Console.WriteLine("Array with " + array.Length + " numbers:");

            //Linear algorithms - they only work on integer arrays! bucket sort is supposed to work on float arrays too
            Console.WriteLine(OperationResult(LinearTimeAlgorithms.CountingSort, array));
            Console.WriteLine(OperationResult(LinearTimeAlgorithms.RadixSort, array));
            //Console.WriteLine(OperationResult(LinearTimeAlgorithms.BucketSort, array)); // no bucket sort implemented yet

            ////Recursive algorithms
            //Console.WriteLine(OperationResult(RecursiveAlgorithms.QuickSort, array));
            //Console.WriteLine(OperationResult(RecursiveAlgorithms.MergeSort, array));

            //// Selection sorts
            //Console.WriteLine(OperationResult(SimpleAlgorithms.SelectionSort, array));
            //if (arrayLength < 10000)
            //    Console.WriteLine(OperationResult(OtherAlgorithms.RecursiveSelectionSort, array));
            //Console.WriteLine(OperationResult(SimpleAlgorithms.SimultaneousSelectionSort, array));

            //// Insertion sorts
            //Console.WriteLine(OperationResult(SimpleAlgorithms.InsertionSort, array));
            //if (arrayLength < 10000)
            //    Console.WriteLine(OperationResult(OtherAlgorithms.RecursiveInsertionSort, array));

            //// Bubble sorts
            //Console.WriteLine(OperationResult(SimpleAlgorithms.BubbleSort, array));
            //if (arrayLength < 10000)
            //    Console.WriteLine(OperationResult(OtherAlgorithms.RecursiveBubbleSort, array));
            //Console.WriteLine(OperationResult(OtherAlgorithms.OddEvenBubbleSort, array));

            //// Other n squared algorithms
            //Console.WriteLine(OperationResult(SimpleAlgorithms.CombSort, array));

            Console.WriteLine();
        }

        // yay functional programming, i can pass each sorting function as a parameter to OperationResult
        private delegate void OperationDelegate<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable;

        // this function runs the sorting function, measuring its time and returning a string which says the method name,
        // the time it took in milliseconds and the result of the assertion
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

        public static void WriteArray(byte[] array)
        {
            foreach (byte i in array)
                Console.Write(i.ToString() + " ");
        }

        public static void WriteArray(int[] array)
        {
            foreach (int i in array)
                Console.Write(i.ToString() + " ");
        }
    }
}
