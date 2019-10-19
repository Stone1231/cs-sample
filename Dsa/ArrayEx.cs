using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Dsa
{
    [TestClass]
    public class ArrayEx
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Creates and initializes a new integer array and a new Object array.
            int[] myIntArray = new int[5] { 1, 2, 3, 4, 5 };
            Object[] myObjArray = new Object[5] { 26, 27, 28, 29, 30 };

            // Prints the initial values of both arrays.
            Debug.WriteLine("Initially,");
            Debug.Write("integer array:");
            PrintValues(myIntArray);
            Debug.WriteLine("Object array: ");
            PrintValues(myObjArray);

            // Copies the first two elements from the integer array to the Object array.
            System.Array.Copy(myIntArray, myObjArray, 2);

            // Prints the values of the modified arrays.
            Debug.WriteLine("\nAfter copying the first two elements of the integer array to the Object array,");
            Debug.Write("integer array:");
            PrintValues(myIntArray);
            Debug.WriteLine("Object array: ");
            PrintValues(myObjArray);

            // Copies the last two elements from the Object array to the integer array.
            System.Array.Copy(myObjArray, myObjArray.GetUpperBound(0) - 1, myIntArray, myIntArray.GetUpperBound(0) - 1, 2);

            // Prints the values of the modified arrays.
            Debug.WriteLine("\nAfter copying the last two elements of the Object array to the integer array,");
            Debug.Write("integer array:");
            PrintValues(myIntArray);
            Debug.Write("Object array: ");
            PrintValues(myObjArray);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Creates and initializes a new three-dimensional Array of type Int32.
            Array myArr = Array.CreateInstance(typeof(Int32), 2, 3, 4);
            for (int i = myArr.GetLowerBound(0); i <= myArr.GetUpperBound(0); i++)
            {
                for (int j = myArr.GetLowerBound(1); j <= myArr.GetUpperBound(1); j++)
                {
                    for (int k = myArr.GetLowerBound(2); k <= myArr.GetUpperBound(2); k++)
                    {
                        myArr.SetValue((i * 100) + (j * 10) + k, i, j, k);
                    }
                }
            }

            // Displays the properties of the Array.
            Debug.WriteLine("The Array has {0} dimension(s) and a total of {1} elements.", myArr.Rank, myArr.Length);
            Debug.WriteLine("\tLength\tLower\tUpper");
            for (int i = 0; i < myArr.Rank; i++)
            {
                Debug.Write($"{i}:\t{myArr.GetLength(i)}");
                Debug.WriteLine("\t{0}\t{1}", myArr.GetLowerBound(i), myArr.GetUpperBound(i));
            }

            // Displays the contents of the Array.
            Debug.WriteLine("The Array contains the following values:");
            PrintValues(myArr);
        }

        void PrintValues(Object[] myArr)
        {
            foreach (Object i in myArr)
            {
                Debug.Write($"\t{i}");
            }
            Debug.WriteLine("");
        }

        void PrintValues(int[] myArr)
        {
            foreach (int i in myArr)
            {
                Debug.Write($"\t{i}");
            }
            Debug.WriteLine("");
        }

        void PrintValues(Array myArr)
        {
            System.Collections.IEnumerator myEnumerator = myArr.GetEnumerator();
            int i = 0;
            int cols = myArr.GetLength(myArr.Rank - 1);
            while (myEnumerator.MoveNext())
            {
                if (i < cols)
                {
                    i++;
                }
                else
                {
                    Debug.WriteLine("");
                    i = 1;
                }
                Debug.Write($"\t{myEnumerator.Current}");
            }
            Debug.WriteLine("");
        }

    }
}